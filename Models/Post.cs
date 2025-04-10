// Código para aprendizado de .NET, C# e etc... Utilizando design Patterns e code clean.
// Código em inglês para padronização e deixar o mais clean possivel.
namespace SocialHubApi.Models
{
    public class Post
    {
        // Id do post que vai ser gerado pelo banco de dados.
        public int Id { get; set; }

        // Conteúdo do post.
        public string? Content { get; set; }
        
        // Data de criação do post.
        public DateTime CreatedAt { get; set;}
        
        // Chave estrangeria para o usuário que criou o post.
        public int UserId { get; set; }
        
        // Cada post pertence unicamente a um usuário.
        public User User { get; set; }
    }
}