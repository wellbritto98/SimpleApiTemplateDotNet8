using Microsoft.AspNetCore.Mvc;
using SimpleApiTemplate.Models;
using SimpleApiTemplate.Services.GenericRepository;

namespace SimpleApiTemplate.Controllers.GenericController;

[ApiController]
[Route("api/[controller]")]
public class GenericController<T> : ControllerBase where T : BaseEntity
{
    private readonly IGenericRepository<T> _repository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public GenericController(IGenericRepository<T> repository, IHttpContextAccessor httpContextAccessor)
    {
        _repository = repository;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<IEnumerable<T>>> GetAll()
    {
        return Ok(await _repository.GetAllAsync());
    }

    [HttpGet("Get/{id}")]
    public async Task<ActionResult<T>> Get(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return NotFound();
        return Ok(entity);
    }

    [HttpPost("Create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<T>> Post(T entity)
    {
        var createdEntity = await _repository.AddAsync(entity);
        return CreatedAtAction(nameof(Get), new { id = createdEntity.Id }, createdEntity);
    }

    [HttpPut("Update/{id}")]
    public async Task<IActionResult> Put(int id, T entity)
    {
        if (id != entity.Id)
        {
            return BadRequest();
        }
        
        await _repository.UpdateAsync(entity);
        return NoContent();
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}
