using CRUD_Entity_Framework.Models;
using CRUD_Entity_Framework.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Entity_Framework.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilmesController : ControllerBase
{
    private readonly IFilmeRepository _filmeRepository;

    public FilmesController(IFilmeRepository filmeRepository)
    {
        _filmeRepository = filmeRepository;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            return Ok(await _filmeRepository.BuscaFilmesAsync());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            return Ok(await _filmeRepository.BuscaFilmeAsync(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> Post(FilmeRequest request)
    {
        try
        {
            return Ok(await _filmeRepository.AdicionarAsync(request));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(FilmeRequest request, int id)
    {
        try
        {
            return Ok(await _filmeRepository.AtualizarAsync(request, id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            return Ok(await _filmeRepository.DeletarFilmeAsync(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
