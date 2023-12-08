using API_Gerenciamento_Atividades.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Gerenciamento_Atividades.Context
{
    public class AppDbContext : DbContext // A classe appDbContext é a classe que irá determinar o comportamento do Entity Framework 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {}

        public DbSet<Atividades> Atividades { get; set; }
    }
}
