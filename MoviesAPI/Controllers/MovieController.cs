using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers;

[ApiController]
[Route( "[controller]" )]
public class MovieController : Controller
{
    private static List<Movie> movies = new List<Movie>();
    private static int id = 1;
    
    [HttpPost]
    public IActionResult AddMovie([FromBody] Movie movie)
    {   
        movie.Id = id++;
        movies.Add(movie);
        return CreatedAtAction(nameof(RecoverMovieId), new {Id = movie.Id}, movie);
    }
    
    [HttpGet]
    public IActionResult RecoverMovie()
    {
        return Ok(movies);
    }
    
    [HttpGet("{id}")]
    public IActionResult RecoverMovieId(int id)
    {
        var movie = movies.FirstOrDefault(x => x.Id == id);
        if (movie == null)
        {
            return NotFound();
        }
        return Ok(movie);
    }
}