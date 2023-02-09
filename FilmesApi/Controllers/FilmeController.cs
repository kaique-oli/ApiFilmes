using FilmesApi.Data;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private Context _context;

    public FilmeController(Context context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] Filme filme)
    {
       _context.Filmes.Add(filme);
        _context.SaveChanges();
       return CreatedAtAction(nameof(RecuperaFilmesProId), new { id = filme.Id}, filme);
    }
    [HttpGet]
    public IActionResult RecuperaFilmes([FromQuery] int skip, [FromQuery] int take)
    {
        return Ok(_context.Filmes.Skip(skip).Take(take));  
    }
    [HttpGet("{id}")]
    public IActionResult RecuperaFilmesProId(int id)
    {
        var result = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (result == null) return NotFound();  
        return Ok(result);  

    }

}
        