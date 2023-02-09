using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base (options) 
    { }  
    public DbSet<Filme>? Filmes { get; set; }
}
