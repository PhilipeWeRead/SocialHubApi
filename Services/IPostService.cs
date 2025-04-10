// Código para aprendizado de .NET, C# e etc... Utilizando design Patterns e code clean.
// Código em inglês para padronização e deixar o mais clean possivel.
// Código com explicação e cometarios no Repositories, para evitar comentarios repetitivos.

using System.Collections.Generic;
using System.Threading.Tasks;
using SocialHubApi.Models;

namespace SocialHubApi.Services
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetPostsAsync();
        Task<Post> GetPostIdAsync(int id);
        Task<Post> AddPostAsync(Post post);
        Task<bool> DeletePostAsync(int id);
    }
}