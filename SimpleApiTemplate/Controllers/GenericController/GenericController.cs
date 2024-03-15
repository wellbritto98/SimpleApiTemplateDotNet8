using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleApiTemplate.Models;
using SimpleApiTemplate.Services.GenericRepository;

namespace SimpleApiTemplate.Controllers.GenericController;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class GenericController<T1, T2> : ControllerBase where T1 : BaseEntity where T2 : class
{
    private readonly IGenericRepository<T1> _repository;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public GenericController(IGenericRepository<T1> repository, IMapper mapper,
        IHttpContextAccessor httpContextAccessor)
    {
        _repository = repository;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet("GetAll")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<T2>>> GetAll()
    {
        var entities = await _repository.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<T2>>(entities));
    }

    [HttpGet("Get/{id}")]
    [Authorize]
    public async Task<ActionResult<T2>> Get(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return NotFound();
        return Ok(_mapper.Map<T2>(entity));
    }

    [HttpPost("Create")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<T2>> Post(T2 dto)
    {
        var entity = _mapper.Map<T1>(dto);
        var createdEntity = await _repository.AddAsync(entity);
        return CreatedAtAction(nameof(Get), new { id = createdEntity.Id }, _mapper.Map<T2>(createdEntity));
    }

    [HttpPut("Update/{id}")]
    [Authorize]
    public async Task<ActionResult> Put(int id, T2 dto)
    {
        var entity = _mapper.Map<T1>(dto);
        entity.Id = id;

        await _repository.UpdateAsync(entity);
        return NoContent();
    }

    [HttpDelete("Delete/{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}