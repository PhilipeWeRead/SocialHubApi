// Código para aprendizado de .NET, C# e etc... Utilizando design Patterns e code clean.
// Código em inglês para padronização e deixar o mais clean possivel.


// O padrão Service é o que lida com a lógica de negócios.

using System.Collections.Generic;
using System.Threading.Tasks;
using SocialHubApi.Models;
using SocialHubApi.Repositories;

namespace SocialHubApi.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        
        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            return await _postRepository.GetPostsAsync();
        }

        public async Task<Post> GetPostIdAsync(int id)
        {
            return await _postRepository.GetPostIdAsync(id);
        }

        public async Task<Post> AddPostAsync(Post post)
        {
            return await _postRepository.AddPostAsync(post);
        }

        //public async Task<Post> UpdatePostAsync(Post post)
        //{
        //    return await _postRepository.UpdatePostAsync(post);
        //}

        public async Task<bool> DeletePostAsync(int id)
        {
            return await _postRepository.DeletePostAsync(id);
        }
    }
}