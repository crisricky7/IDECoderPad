using ApiDevsuCMunoz.Domain;
using Microsoft.EntityFrameworkCore;

namespace ApiDevsuCMunoz.Data
{
    public class ApiDevsuCMunozDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Devsu;Trusted_Connection=True;Encrypt=False;")
            .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name}, Microsoft.Extensions.Logging.LogLevel.Information)
            .EnableSensitiveDataLogging();
        }
        public DbSet<Cliente>? Clientes { get; set; }
        public DbSet<Cuenta>? Cuentas { get; set; }
        public DbSet<Movimiento>? Movimientos { get; set; }
    }
}
