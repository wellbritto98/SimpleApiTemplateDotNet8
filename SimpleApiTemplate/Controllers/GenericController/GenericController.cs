using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimpleApiTemplateDotNet8.Models.Base;
using SimpleApiTemplateDotNet8.Services.GenericService;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace SimpleApiTemplate.Web.Controllers.GenericController;

[ApiController]
[Route("api/[controller]")]
/// <summary>
/// Controlador genérico que fornece endpoints CRUD.
/// T1 = Entidade, T2 = DTO para Inserção, T3 = DTO para Leitura, T4 = DTO para Atualização.
/// </summary>
/// <typeparam name="T1">Entidade base que herda de BaseEntity.</typeparam>
/// <typeparam name="T2">DTO de inserção da entidade.</typeparam>
/// <typeparam name="T3">DTO de leitura da entidade.</typeparam>
/// <typeparam name="T4">DTO de atualização da entidade.</typeparam>
public class GenericController<T1, T2, T3, T4, T5> : ControllerBase where T1 : BaseEntity where T2 : class where T3 : class where T4 : class where T5 : class
{
    protected readonly IGenericService<T1> _service;
    protected readonly IMapper _mapper;
    protected readonly IHttpContextAccessor _httpContextAccessor;

    /// <summary>
    /// Inicializa uma nova instância do controlador genérico com os serviços injetados.
    /// </summary>
    /// <param name="service">Serviço genérico para operações CRUD.</param>
    /// <param name="mapper">Mapper para conversão de DTOs.</param>
    /// <param name="httpContextAccessor">Acessor de contexto HTTP.</param>
    public GenericController(IGenericService<T1> service, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _service = service;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// Retorna uma lista de todos os itens da entidade.
    /// </summary>
    /// <returns>Uma lista de itens da entidade.</returns>
    [HttpGet("GetAll")]
    [SwaggerOperation(Summary = "Retorna uma lista de todos os itens da entidade.",
        Description = "Esse endpoint retorna todos os registros da entidade representada.")]
    [ProducesResponseType(StatusCodes.Status200OK)]  // Removido o uso de tipos genéricos nos atributos
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<T3>>> GetAll()
    {
        try
        {
            var entities = await _service.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<T3>>(entities));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Retorna uma lista de itens filtrados pelos campos e operadores especificados no JSON.
    /// </summary>
    /// <param name="json">
    /// JSON contendo os filtros no formato:
    /// {
    ///     "campo@operador": "valor@tipoDoValor"
    /// }
    /// Exemplos: 
    /// - {"Nome@igual": "John Doe@System.String"}
    /// - {"Idade@maior": "30@System.Int32"}
    /// </param>
    /// <returns>Uma lista de itens filtrados da entidade.</returns>
    [HttpGet("Find")]
    [SwaggerOperation(Summary = "Retorna uma lista de itens filtrados.",
        Description = "Esse endpoint permite a filtragem dinâmica de registros da entidade através de JSON, especificando campos, operadores e tipos.")]
    [ProducesResponseType(StatusCodes.Status200OK)]  // Removido o uso de tipos genéricos nos atributos
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerRequestExample(typeof(string), typeof(ExampleFilters))]
    public async Task<ActionResult<IEnumerable<T3>>> Find([FromQuery] string json)
    {
        try
        {
            var entities = await _service.FindAsync(json);
            return Ok(_mapper.Map<IEnumerable<T3>>(entities));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Retorna um item pelo ID.
    /// </summary>
    /// <param name="id">
    /// ID do item no formato JSON. O JSON deve conter as chaves primárias necessárias da entidade no seguinte formato:
    /// {
    ///     "Chave1": "Valor1",
    ///     "Chave2": "Valor2"
    /// }
    /// Exemplo para uma chave composta:
    /// {
    ///     "Id": "123",
    ///     "SubId": "456"
    /// }
    /// </param>
    /// <returns>O item correspondente da entidade.</returns>
    [HttpGet("Get/")]
    [SwaggerOperation(Summary = "Retorna um item pelo ID.",
       Description = "Esse endpoint permite a busca de um item no banco de dados através de sua chave primária, fornecida em formato JSON. " +
       "ID do item no formato JSON. O JSON deve conter as chaves primárias necessárias da entidade no seguinte formato:" +
       "{ \"Chave1\": \"Valor1\",\r\n\"Chave2\": \"Valor2\" }")]
    [ProducesResponseType(StatusCodes.Status200OK)]  // Removido o uso de tipos genéricos nos atributos
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerRequestExample(typeof(string), typeof(ExampleId))]
    public async Task<ActionResult<T3>> Get([FromQuery] T5 queryParam)
    {
        try
        {
            // Extrair os valores das propriedades de T5 e passá-los como parâmetros para a consulta
            var keyValues = queryParam.GetType().GetProperties()
                                      .Select(p => p.GetValue(queryParam))
                                      .ToArray();

            // Chamar o serviço para buscar a entidade pelo ID composto
            var entity = await _service.GetByIdAsync(keyValues);
            if (entity == null) return NotFound();

            // Retornar o DTO mapeado da entidade
            return Ok(_mapper.Map<T3>(entity));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Insere um novo item no banco de dados.
    /// </summary>
    /// <param name="dto">DTO de inserção do item.</param>
    /// <returns>O item criado.</returns>
    [HttpPost("Create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [SwaggerOperation(Summary = "Insere um novo item no banco de dados.")]
    [ProducesResponseType(StatusCodes.Status200OK)]  // Removido o uso de tipos genéricos nos atributos
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<T2>> Post(T2 dto)
    {
        try
        {
            var entity = _mapper.Map<T1>(dto);
            var createdEntity = await _service.AddAsync(entity);
            return Ok(_mapper.Map<T2>(createdEntity));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Atualiza as informações de um item existente pelo ID.
    /// </summary>
    /// <param name="id">
    /// ID do item no formato JSON. O JSON deve conter as chaves primárias necessárias da entidade no seguinte formato:
    /// {
    ///     "Chave1": "Valor1",
    ///     "Chave2": "Valor2"
    /// }
    /// Exemplo para uma chave composta:
    /// {
    ///     "Id": "123",
    ///     "SubId": "456"
    /// }
    /// </param>
    /// <param name="dto">DTO de atualização do item.</param>
    /// <returns>Mensagem de sucesso ou erro.</returns>
    [HttpPut("Update")]
    [SwaggerOperation(Summary = "Altera informações de um item pelo ID.",
       Description = "Atualiza um item existente no banco de dados através de sua chave primária fornecida em formato JSON." +
       "ID do item no formato JSON. O JSON deve conter as chaves primárias necessárias da entidade no seguinte formato:" +
       "{ \"Chave1\": \"Valor1\",\r\n\"Chave2\": \"Valor2\" }")]
    [ProducesResponseType(StatusCodes.Status200OK)]  // Removido o uso de tipos genéricos nos atributos
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerRequestExample(typeof(string), typeof(ExampleId))]
    public async Task<ActionResult> Put([FromQuery] T5 queryParam, T4 dto)
    {
        try
        {
            // Extrair as chaves dos parâmetros de query
            object[] keyValues = queryParam.GetType().GetProperties()
                                          .Select(p => p.GetValue(queryParam))
                                          .ToArray();

            // Buscar a entidade existente pelas chaves compostas
            var entity = await _service.GetByIdAsync(keyValues);
            if (entity == null) return NotFound("Entidade não encontrada");

            // Mapear as atualizações do DTO para a entidade
            var mappedEntity = _mapper.Map(dto, entity);

            // Atualizar a entidade
            await _service.UpdateAsync(mappedEntity);

            return Ok("Atualizado com sucesso");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    /// <summary>
    /// Exclui um item pelo ID.
    /// </summary>
    /// <param name="id">
    /// ID do item no formato JSON. O JSON deve conter as chaves primárias necessárias da entidade no seguinte formato:
    /// {
    ///     "Chave1": "Valor1",
    ///     "Chave2": "Valor2"
    /// }
    /// Exemplo para uma chave composta:
    /// {
    ///     "Id": "123",
    ///     "SubId": "456"
    /// }
    /// </param>
    /// <returns>Mensagem de sucesso ou erro.</returns>
    [HttpDelete("Delete")]
    [SwaggerOperation(Summary = "Deleta um item pelo ID.",
         Description = "Exclui um item no banco de dados através de sua chave primária fornecida em formato JSON." +
         "ID do item no formato JSON. O JSON deve conter as chaves primárias necessárias da entidade no seguinte formato:" +
         "{ \"Chave1\": \"Valor1\",\r\n\"Chave2\": \"Valor2\" }")]
    [ProducesResponseType(StatusCodes.Status200OK)]  // Removido o uso de tipos genéricos nos atributos
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerRequestExample(typeof(string), typeof(ExampleId))]
    public async Task<IActionResult> Delete([FromQuery] T5 queryParam)
    {
        try
        {
            // Extrair as chaves dos parâmetros de query
            object[] keyValues = queryParam.GetType().GetProperties()
                                        .Select(p => p.GetValue(queryParam))
                                        .ToArray();

            // Chamar o serviço para deletar a entidade pelas chaves compostas
            await _service.DeleteAsync(keyValues);
            return Ok("Deletado com sucesso");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}


/// <summary>
/// Classe de exemplo para o JSON de filtros em Find.
/// </summary>
public class ExampleFilters : IExamplesProvider<string>
{
    public string GetExamples()
    {
        return JsonConvert.SerializeObject(new Dictionary<string, string>
        {
            {"Nome@igual", "John Doe@System.String"},
            {"Idade@maior", "30@System.Int32"}
        });
    }
}

/// <summary>
/// Classe de exemplo para o JSON de ID em Get, Update, e Delete.
/// </summary>
public class ExampleId : IExamplesProvider<string>
{
    public string GetExamples()
    {
        return JsonConvert.SerializeObject(new Dictionary<string, object>
        {
            {"Id", 123},
            {"SubId", 456}
        });
    }
}
