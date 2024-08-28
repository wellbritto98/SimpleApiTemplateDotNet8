using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SimpleApiTemplateDotNet8.Data;
using SimpleApiTemplateDotNet8.Models.Base;
using System.Reflection;

namespace SimpleApiTemplateDotNet8.Repository.GenericRepository;

/// <summary>
/// Classe genérica para repositórios que implementa operações CRUD.
/// </summary>
/// <typeparam name="T">O tipo da entidade que herda de BaseEntity.</typeparam>
public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly DataContext _context;

    public GenericRepository(DataContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Adiciona os joins dinâmicos no banco de dados para carregar propriedades virtuais aninhadas.
    /// </summary>
    /// <typeparam name="T">O tipo da entidade.</typeparam>
    /// <param name="query">A consulta sobre a qual os includes serão aplicados.</param>
    /// <param name="property">A propriedade que deve ser incluída na consulta.</param>
    /// <param name="currentPath">O caminho atual da propriedade, usado para incluir aninhamentos.</param>
    /// <returns>A consulta com as propriedades virtuais incluídas.</returns>
    private IQueryable<T> IncludeNestedProperties<T>(IQueryable<T> query, PropertyInfo property, string currentPath = null) where T : class
    {
        // Verificar se a propriedade é virtual, se é uma classe e não é uma string
        if (property.GetMethod.IsVirtual && property.PropertyType.IsClass && property.PropertyType != typeof(string))
        {
            // Construir o caminho de inclusão
            var includePath = currentPath != null ? $"{currentPath}.{property.Name}" : property.Name;

            // Adicionar o include para a propriedade atual usando lambda-based include
            query = query.Include(includePath);

            // Recursivamente adicionar includes para propriedades virtuais dentro desta propriedade
            var nestedVirtualProperties = property.PropertyType.GetProperties()
                .Where(p => p.GetMethod.IsVirtual && p.PropertyType.IsClass && p.PropertyType != typeof(string))
                .ToList();

            foreach (var nestedProperty in nestedVirtualProperties)
            {
                // Use lambda-based include for nested properties
                query = IncludeNestedProperties(query, nestedProperty, includePath);
            }
        }

        return query;
    }
    /// <summary>
    /// Obtém uma lista de propriedades virtuais de uma entidade, exceto coleções.
    /// </summary>
    /// <param name="entityType">O tipo da entidade.</param>
    /// <returns>Uma lista de propriedades virtuais da entidade.</returns>
    private List<PropertyInfo> GetVirtualFields(Type entityType)
    {
        var entityProperties = entityType.GetProperties();

        var virtualProperties = entityProperties
            .Where(p => p.GetMethod.IsVirtual && p.PropertyType.IsClass)
            .ToList();

        // Remove ICollection properties
        virtualProperties.RemoveAll(p => p.PropertyType.GetInterfaces()
            .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICollection<>)));

        return virtualProperties;
    }


    /// <summary>
    /// Obtém todas as entidades do banco de dados.
    /// </summary>
    /// <returns>Uma lista de todas as entidades.</returns>
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        try
        {
            var entityType = _context.Model.FindEntityType(typeof(T));
            var virtualProperties = GetVirtualFields(typeof(T));

            if (virtualProperties.Count == 0)
            {
                // fazer apenas o ToListAsync
                return await _context.Set<T>().ToListAsync();
            }
            else
            {
                // Para cada atributo virtual que seja uma classe,
                // adicionar includes para carregar os dados relacionados
                var query = _context.Set<T>().AsQueryable();
                foreach (var property in virtualProperties)
                {
                    query = IncludeNestedProperties(query, property);
                }
                return await query.ToListAsync();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    /// <summary>
    /// Obtém uma entidade por seus valores chave.
    /// </summary>
    /// <param name="keyValues">Os valores chave da entidade.</param>
    /// <returns>A entidade correspondente ou null se não encontrada.</returns>
    public async Task<T> GetByIdAsync(params object[] keyValues)
    {
        try
        {
            var entityType = _context.Model.FindEntityType(typeof(T));
            var keyProperties = entityType.FindPrimaryKey().Properties;
            var virtualProperties = GetVirtualFields(typeof(T));

            var query = _context.Set<T>().AsQueryable();

            if (virtualProperties.Count > 0)
            {
                foreach (var property in virtualProperties)
                {
                    query = IncludeNestedProperties(query, property);
                }
            }

            // Adicionar cláusula WHERE para as chaves primárias
            for (int i = 0; i < keyProperties.Count; i++)
            {
                var keyName = keyProperties[i].Name;
                // Converter o valor da chave primária para o tipo correto
                var keyValue = Convert.ChangeType(keyValues[i], keyProperties[i].ClrType);
                query = query.Where(e => EF.Property<object>(e, keyName).Equals(keyValue));
            }

            return await query.FirstOrDefaultAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    /// <summary>
    /// Encontra entidades que correspondem aos critérios fornecidos em JSON.
    /// </summary>
    /// <param name="json">
    /// O JSON que contém os critérios de filtro. O formato esperado do JSON é um dicionário onde a chave é composta pelo nome do campo e o operador,
    /// e o valor é o critério de comparação. O formato é:
    /// 
    /// {
    ///     "campo@operador": "valor@tipoDoValor"
    /// }
    /// 
    /// Exemplos:
    /// 
    /// - {"Nome@igual": "John Doe@System.String"}
    /// - {"Idade@maior": "30@System.Int32"}
    /// - {"DataDeNascimento@menorigual": "2000-01-01T00:00:00@System.DateTime"}
    /// 
    /// Operadores suportados:
    /// - "igual": compara se o valor é igual ao campo.
    /// - "diferente": compara se o valor é diferente do campo.
    /// - "maior": compara se o valor é maior que o campo (suporta IComparable).
    /// - "menor": compara se o valor é menor que o campo (suporta IComparable).
    /// - "maiorigual": compara se o valor é maior ou igual ao campo (suporta IComparable).
    /// - "menorigual": compara se o valor é menor ou igual ao campo (suporta IComparable).
    /// </param>
    /// <returns>Uma lista de entidades que atendem aos critérios de filtro.</returns>
    public async Task<IEnumerable<T>> FindAsync(string json)
    {
        try
        {
            // Deserializar o JSON para um objeto Dictionary
            var filters = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            // Iniciar a consulta
            var query = _context.Set<T>().AsQueryable();

            // Obter as propriedades virtuais da entidade
            var virtualProperties = GetVirtualFields(typeof(T));

            // Iterar sobre o dicionário e construir a consulta
            foreach (var filter in filters)
            {
                // Dividir a chave em campo e operador
                var parts = filter.Key.Split('@');
                var field = parts[0];
                var operador = parts[1];

                // Converter o valor para o tipo correto
                var valueParts = filter.Value.Split('@');
                var valueStr = valueParts[0];
                var valueTypeStr = valueParts[1];
                var valueType = Type.GetType(valueTypeStr);
                object value;

                // Converter o valor para o tipo apropriado
                if (valueType == typeof(DateTime))
                {
                    value = DateTime.Parse(valueStr, null, System.Globalization.DateTimeStyles.RoundtripKind);
                }
                else
                {
                    value = Convert.ChangeType(valueStr, valueType);
                }

                // Construir a consulta com base no operador e no tipo do valor
                switch (operador)
                {
                    case "igual":
                        query = query.Where(e => EF.Property<object>(e, field).Equals(value));
                        break;
                    case "diferente":
                        query = query.Where(e => !EF.Property<object>(e, field).Equals(value));
                        break;
                    case "maior":
                        if (valueType == typeof(DateTime))
                        {
                            query = query.Where(e => EF.Property<DateTime>(e, field) > (DateTime)value);
                        }
                        else if (typeof(IComparable).IsAssignableFrom(valueType))
                        {
                            query = query.Where(e => ((IComparable)EF.Property<object>(e, field)).CompareTo(value) > 0);
                        }
                        else
                        {
                            throw new ArgumentException($"Tipo de dado não suportado para o operador 'maior': {valueType}");
                        }
                        break;
                    case "menor":
                        if (valueType == typeof(DateTime))
                        {
                            query = query.Where(e => EF.Property<DateTime>(e, field) < (DateTime)value);
                        }
                        else if (typeof(IComparable).IsAssignableFrom(valueType))
                        {
                            query = query.Where(e => ((IComparable)EF.Property<object>(e, field)).CompareTo(value) < 0);
                        }
                        else
                        {
                            throw new ArgumentException($"Tipo de dado não suportado para o operador 'menor': {valueType}");
                        }
                        break;
                    case "maiorigual":
                        if (valueType == typeof(DateTime))
                        {
                            query = query.Where(e => EF.Property<DateTime>(e, field) >= (DateTime)value);
                        }
                        else if (typeof(IComparable).IsAssignableFrom(valueType))
                        {
                            query = query.Where(e => ((IComparable)EF.Property<object>(e, field)).CompareTo(value) >= 0);
                        }
                        else
                        {
                            throw new ArgumentException($"Tipo de dado não suportado para o operador 'maiorigual': {valueType}");
                        }
                        break;
                    case "menorigual":
                        if (valueType == typeof(DateTime))
                        {
                            query = query.Where(e => EF.Property<DateTime>(e, field) <= (DateTime)value);
                        }
                        else if (typeof(IComparable).IsAssignableFrom(valueType))
                        {
                            query = query.Where(e => ((IComparable)EF.Property<object>(e, field)).CompareTo(value) <= 0);
                        }
                        else
                        {
                            throw new ArgumentException($"Tipo de dado não suportado para o operador 'menorigual': {valueType}");
                        }
                        break;
                    default:
                        throw new ArgumentException($"Operador '{operador}' não é suportado.");
                }
            }

            // Adicionar includes para propriedades virtuais
            foreach (var property in virtualProperties)
            {
                query = IncludeNestedProperties(query, property);
            }

            // Executar a consulta e retornar o resultado
            return await query.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


    /// <summary>
    /// Adiciona uma nova entidade ao banco de dados.
    /// </summary>
    /// <param name="entity">A entidade a ser adicionada.</param>
    /// <returns>A entidade adicionada.</returns>
    public virtual async Task<T> AddAsync(T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    /// <summary>
    /// Atualiza uma entidade existente no banco de dados.
    /// </summary>
    /// <param name="entity">A entidade a ser atualizada.</param>
    /// <returns>A entidade atualizada.</returns>
    public async Task<T> UpdateAsync(T entity)
    {
        try
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }


    /// <summary>
    /// Exclui uma entidade do banco de dados com base nos valores de chave fornecidos.
    /// </summary>
    /// <param name="keyValues">Os valores chave da entidade a ser excluída.</param>
    public async Task DeleteAsync(params object[] keyValues)
    {
        var entity = await _context.Set<T>().FindAsync(keyValues);
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}