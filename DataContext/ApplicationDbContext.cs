using Microsoft.EntityFrameworkCore;
using Projeto_Confitec.Models;

namespace Projeto_Confitec.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<NivelEscolar> NiveisEscolares { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Usuario>()
                .HasData(new List<Usuario>(){
                    new Usuario (1, "Jorge", "de Jesus", "jjesus@gmail.com", new DateTime(2000,7,7,2,0,0), 1),
                    new Usuario (2, "Emilio", "Nascimento", "enascimento@gmail.com", new DateTime(1985,9,3,2,0,0), 2),
                    new Usuario (3, "João", "Fahrenheit", "fahrenheitizin@gmail.com", new DateTime(1999,10,20,2,0,0), 3),
                    new Usuario (4, "Cleysson", "Trambique", "cleytrambiq@gmail.com", new DateTime(1990,12,24,2,0,0), 1),
                    new Usuario (5, "Julio", "Jordan", "jordanJu@gmail.com", new DateTime(1995,7,17,2,0,0), 4),
                });

            builder.Entity<NivelEscolar>()
                .HasData(new List<NivelEscolar>{
                    new NivelEscolar (1, "Infantil"),
                    new NivelEscolar (2, "Fundamental"),
                    new NivelEscolar (3, "Médio"),
                    new NivelEscolar (4, "Superior")
                });
        }
    }
}
