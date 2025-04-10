// Código para aprendizado de .NET, C# e etc... Utilizando design Patterns e code clean.
// Código em inglês para padronização e deixar o mais clean possivel.


using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialHubApi.Data;
using SocialHubApi.Models;

namespace SocialHubApi.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        // Injeção de dependência do contexto.
        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Recupera todos os posts.
        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            return await _context.Posts.Include(p => p.User).ToListAsync();
        }

        // Recupera um post pelo ID.
        public async Task<Post> GetPostIdAsync(int id)
        {
            return await _context.Posts.Include(p => p.User).FirstOrDefaultAsync(p => p.Id == id);
        }

        // Adiciona um novo post.
        public async Task<Post> AddPostAsync(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }

        // Atualiza um post existente.
        public async Task<Post> UpdatePostAsync(Post post)
        { 
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
            return post;
        }

        // Deleta um post pelo ID.
        public async Task<bool> DeletePostAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return false;
            }

            _context.Posts.Remove(post);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}