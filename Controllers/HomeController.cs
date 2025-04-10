using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace SocialHubApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IFileProvider _fileProvider;

        // Injeção de dependência do IFileProvider
        public HomeController(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        [HttpGet("getfile/{filename}")]
        public IActionResult GetFile(string filename)
        {
            var fileInfo = _fileProvider.GetFileInfo(Path.Combine("wwwroot", filename));

            if (!fileInfo.Exists)
            {
                return NotFound();
            }

            var fileContents = System.IO.File.ReadAllText(fileInfo.PhysicalPath);
            return Ok(fileContents);
        }
    }
}
