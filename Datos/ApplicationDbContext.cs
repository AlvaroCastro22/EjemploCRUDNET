using Microsoft.EntityFrameworkCore;
using WebAppBD.Models;

namespace WebAppBD.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Categoria> Categoria { get; set; }
    }
}
