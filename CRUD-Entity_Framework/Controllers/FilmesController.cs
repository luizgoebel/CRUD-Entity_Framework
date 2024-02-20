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
        return Ok(await _filmeRepository.BuscaFilmesAsync());
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
            _filmeRepository.AdicionarAsync(request);
            return Ok();
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
            _filmeRepository.AtualizarAsync(request, id);
            return Ok();
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
            _filmeRepository.DeletarFilmeAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }
}
