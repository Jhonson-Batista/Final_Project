using Microsoft.EntityFrameworkCore;

namespace Contact_list
{
    public class AgendaContext : DbContext
    {
        public DbSet<Contacto> Contactos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=JHONSONPC\\SQLEXPRESS;Database=AgendaContactosDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}