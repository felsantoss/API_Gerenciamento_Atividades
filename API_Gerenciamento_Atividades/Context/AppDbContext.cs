using API_Gerenciamento_Atividades.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Gerenciamento_Atividades.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {}

        public DbSet<Atividades> Atividades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
