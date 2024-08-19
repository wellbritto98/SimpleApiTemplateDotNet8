using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimpleApiTemplateDotNet8.Models.Base;
using SimpleApiTemplateDotNet8.Repository.GenericRepository;
using Swashbuckle.AspNetCore.Annotations;
using SimpleApiTemplateDotNet8.Models;


namespace SimpleApiTemplate.Web.Controllers.GenericController;

[ApiController]
[Route("api/[controller]")]
//T1 = Entity, T2= InsertDTO, T3 = ReadDTO, T4 = UpdateDTO
public class GenericController<T1, T2, T3, T4> : ControllerBase where T1 : BaseEntity where T2 : class where T3 : class where T4 : class
{
    protected readonly IGenericRepository<T1> _repository;
    protected readonly IMapper _mapper;
    protected readonly IHttpContextAccessor _httpContextAccessor;

    public GenericController(IGenericRepository<T1> repository, IMapper mapper,
        IHttpContextAccessor httpContextAccessor)
    {
        _repository = repository;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet("GetAll")]
    [SwaggerOperation(
    Summary = "Retorna uma lista de items"
    )]
    public async Task<ActionResult<IEnumerable<T3>>> GetAll()
    {
        try
        {
            var entities = await _repository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<T3>>(entities));
        }

        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("Find")]
    [SwaggerOperation(
        Summary = "Retorna uma lista de items filtrados pelos campos desejados e operadores informados",
        Description = "Espera um JSON com os filtros. Exemplo: {\"field@operator\":\"value@type\", \"field2@operator2\":\"value2@type2\",...}" +
        "Caso deseje buscar por PsicologoId, PacienteId, ou UserId, o tipo desses campos é System.String" +
        "Campos do tipo DateTime, a API entede por System.DateTime"
        )]
    public async Task<ActionResult<IEnumerable<T3>>> Find([FromQuery] string json)
    {
        try
        {
            var entities = await _repository.FindAsync(json);
            return Ok(_mapper.Map<IEnumerable<T3>>(entities));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("Get/{id}")]
    [SwaggerOperation(
    Summary = "Retorna um item pelo ID",
    Description = "Espera um ID no formato JSON com as chaves primárias. Exemplo: {\"key1\":\"value\", \"key2\":value2,...}, as chaves devem estar na mesma ordem do banco de dados"
    )]
    public async Task<ActionResult<T3>> Get(string id)
    {
        try
        {
            // Deserialize the JSON into a dictionary
            var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(id);

            // Get the primary key properties of T1 based on ColumnOrder
            var keyProperties = typeof(T1).GetProperties()
                .Where(p => p.GetCustomAttributes(typeof(ColumnAttribute), true)
                             .Cast<ColumnAttribute>()
                             .Any(ca => ca.Order >= 0))
                .ToList();

            // Validate that all primary key properties are present
            if (keyProperties.Any(key => !dict.ContainsKey(key.Name)))
            {
                return BadRequest("Missing primary key properties in the request.");
            }

            // Convert the values to the correct types
            var keyValues = keyProperties.Select(key =>
            {
                try
                {
                    return Convert.ChangeType(dict[key.Name], key.PropertyType);
                }
                catch (Exception ex)
                {
                    throw new ArgumentException($"Invalid value for property '{key.Name}': {ex.Message}");
                }
            }).ToArray();

            // Get the entity by its primary key
            var entity = await _repository.GetByIdAsync(keyValues);
            if (entity == null) return NotFound();

            return Ok(_mapper.Map<T3>(entity));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("Create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [SwaggerOperation(
    Summary = "Insere um novo item no banco de dados",
    Description = "Espera um objeto para inserir no baco de dados")]
    public async Task<ActionResult<T2>> Post(T2 dto)
    {
        try
        {
            var entity = _mapper.Map<T1>(dto);
            var createdEntity = await _repository.AddAsync(entity);
            return Ok(_mapper.Map<T2>(createdEntity));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("Update")]
    [SwaggerOperation(
    Summary = "Altera informações de um item pelo ID",
    Description = "Espera um ID no formato JSON com as chaves primárias. Exemplo: {\"key1\":\"value\", \"key2\":value2,...}, e um objeto do mesmo tipo com as informações a serem modificadas."
    )]
    public async Task<ActionResult> Put([FromQuery] string id, T4 dto)
    {
        try
        {
            // Desserializa o JSON em um dicionário
            var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(id);

            // Pega os valores do dicionário e coloca em um array
            object[] keyValues = dict.Values.ToArray();
            var entity = await _repository.GetByIdAsync(keyValues);

            var mappedEntity = _mapper.Map(dto, entity);

            var updatedEntity = await _repository.UpdateAsync(mappedEntity);
            return Ok("Atualizado com sucesso");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("Delete")]
    [SwaggerOperation(
    Summary = "Deleta um item pelo ID",
    Description = "Espera um ID no formato JSON com as chaves primárias. Exemplo: {\"key1\":\"value\", \"key2\":value2,...}, as chaves devem estar na mesma ordem do banco de dados"
    )]
    public async Task<IActionResult> Delete([FromQuery] string id)
    {
        try
        {
            var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(id);

            // Pega os valores do dicionário e coloca em um array
            object[] keyValues = dict.Values.ToArray();
            await _repository.DeleteAsync(keyValues);
            return Ok("Deletado com sucesso");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}