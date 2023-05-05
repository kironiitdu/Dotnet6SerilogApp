using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SwaggerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UplaodController : ControllerBase
    {

        [HttpPost("Upload")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file, [FromForm] FileMetaDataDto metaData)
        {
            return Ok();
        }
    }
    public class FileMetaDataDto
    {
        public IFormFile File { get; set; }
        public string FileName { get; set; }
        public string Version { get; set; }
    }
}
