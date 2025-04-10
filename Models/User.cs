// Código para aprendizado de .NET, C# e etc... Utilizando design Patterns e code clean.
// Código em inglês para padronização e deixar o mais clean possivel.
namespace SocialHubApi.Models
{
    public class User
    {
        // ID que vai ser gerado pelo Banco de Dados.
        public int Id { get; set; }

        // Nome do usuário (Deve ser único).
        public string? UserName { get; set; }
        public string? Email { get; set; }

        // URL da imagem de perfil (Opcional, pois o usuário pode preferir não ter uma).
        public string? ProfileImage { get; set; }

        // Um usuário pode ter varios post.
        public ICollection<Post> Posts { get; set; }
    }
}