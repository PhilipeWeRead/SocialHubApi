// O PostController expõe os endpoints para manipulação dos post.

using Microsoft.AspNetCore.Mvc;
using SocialHubApi.Models;
using SocialHubApi.Services;

namespace SocialHubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        // Injeção de dependência do serviço de posts.
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        // Endpoint para obter todos os posts.
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _postService.GetPostsAsync();
            return Ok(posts);
        }

        // Endpoint para buscar um post pelo ID.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postService.GetPostIdAsync(id);
            if (post == null)
            {
                // Retorna 404 se não encontrar.
                return NotFound();
            }
            return Ok(post);
        }
        
        // Endpoint para obter todos os posts.
        [HttpPost]
        public async Task<IActionResult> PostPost([FromBody] Post post)
        {
            var createdPost = await _postService.AddPostAsync(post);

            // Retorna 201 com o novo post criado.
            return CreatedAtAction(nameof(GetPost), new { id = createdPost.Id }, createdPost);
        }

        // Endpoint para excluir um post
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var result = await _postService.DeletePostAsync(id);
            if (!result)
            {
                // Retorna 404 se não encontrar.
                return NotFound();
            }
            // Retorna 204 sem conteúdo.
            return NoContent();
        }

    }
}