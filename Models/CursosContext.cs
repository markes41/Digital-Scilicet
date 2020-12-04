using Microsoft.EntityFrameworkCore;

namespace Cursos.Models
{
    public class CursosContext : DbContext
    {
        public CursosContext(DbContextOptions<CursosContext> options)
            : base (options)
        { }
        
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}