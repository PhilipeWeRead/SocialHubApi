// Código para aprendizado de .NET, C# e etc... Utilizando design Patterns e code clean.
// Código em inglês para padronização e deixar o mais clean possivel.

// Repositorio para manipuar os dados de post.

using System.Collections.Generic;
using System.Threading.Tasks;
using SocialHubApi.Models;

namespace SocialHubApi.Repositories
{
    public interface IPostRepository
    {
        // Obter todos os post.
        Task<IEnumerable<Post>> GetPostsAsync();
        Task<Post> GetPostIdAsync(int id);
        Task<Post> AddPostAsync(Post post);
        Task<bool> DeletePostAsync(int id);
    }
}
