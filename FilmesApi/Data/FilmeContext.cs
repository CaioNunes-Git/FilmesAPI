using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data
{
    public class FilmeContext : DbContext
    {

        private readonly IConfiguration configuration; 

        public FilmeContext() : base()
        {
            
        }

        public FilmeContext(DbContextOptions<FilmeContext> opts) : base(opts)
        {
           
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var connectionString = configuration.GetConnectionString("FilmeConnection");
        //    optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        //}

        public DbSet<Filme> Filmes { get; set; } 

    }
}
