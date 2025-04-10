// Código para aprendizado de .NET, C# e etc... Utilizando design Patterns e code clean.
// Código em inglês para padronização e deixar o mais clean possivel.
using Microsoft.EntityFrameworkCore;
using SocialHubApi.Models;

namespace SocialHubApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Construtor que irá receber as opções de configuração do banco.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Definindo as tabelas que o Entity Framework irá mapear.
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
