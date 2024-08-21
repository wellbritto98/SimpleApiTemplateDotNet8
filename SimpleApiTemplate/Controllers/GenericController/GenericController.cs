using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimpleApiTemplateDotNet8.Models.Base;
using SimpleApiTemplateDotNet8.Services.GenericService;
using Swashbuckle.AspNetCore.Annotations;

namespace SimpleApiTemplate.Web.Controllers.GenericController;

[ApiController]
[Route("api/[controller]")]
// T1 = Entity, T2 = InsertDTO, T3 = ReadDTO, T4 = UpdateDTO
public class GenericController<T1, T2, T3, T4> : ControllerBase where T1 : BaseEntity where T2 : class where T3 : class where T4 : class
{
    protected readonly IGenericService<T1> _service;
    protected readonly IMapper _mapper;
    protected readonly IHttpContextAccessor _httpContextAccessor;

    public GenericController(IGenericService<T1> service, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _service = service;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet("GetAll")]
    [SwaggerOperation(Summary = "Retorna uma lista de items")]
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

    [HttpGet("Find")]
    [SwaggerOperation(
        Summary = "Retorna uma lista de items filtrados pelos campos desejados e operadores informados",
        Description = "Espera um JSON com os filtros."
    )]
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

    [HttpGet("Get/{id}")]
    [SwaggerOperation(Summary = "Retorna um item pelo ID")]
    public async Task<ActionResult<T3>> Get(string id)
    {
        try
        {
            var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(id);
            object[] keyValues = dict.Values.ToArray();

            var entity = await _service.GetByIdAsync(keyValues);
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
    [SwaggerOperation(Summary = "Insere um novo item no banco de dados")]
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

    [HttpPut("Update")]
    [SwaggerOperation(Summary = "Altera informações de um item pelo ID")]
    public async Task<ActionResult> Put([FromQuery] string id, T4 dto)
    {
        try
        {
            var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(id);
            object[] keyValues = dict.Values.ToArray();
            var entity = await _service.GetByIdAsync(keyValues);

            var mappedEntity = _mapper.Map(dto, entity);
            await _service.UpdateAsync(mappedEntity);

            return Ok("Atualizado com sucesso");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("Delete")]
    [SwaggerOperation(Summary = "Deleta um item pelo ID")]
    public async Task<IActionResult> Delete([FromQuery] string id)
    {
        try
        {
            var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(id);
            object[] keyValues = dict.Values.ToArray();

            await _service.DeleteAsync(keyValues);
            return Ok("Deletado com sucesso");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
