using Microsoft.EntityFrameworkCore;
using ApiLogin.Models;

namespace ApiLogin.Models
{
    public class ApiLoginDbContext : DbContext
    {
        public ApiLoginDbContext(DbContextOptions<ApiLoginDbContext> options)
            : base(options)
        {

        }

        public DbSet<UsuarioModel> Usuarios { get; set; }

        // Mapear a classe de modelo para uma tabela do banco de dados
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}