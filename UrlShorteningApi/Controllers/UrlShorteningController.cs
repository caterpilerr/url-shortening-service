using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using UrlShorteningApi.Contracts;

namespace UrlShorteningApi.Controllers
{
    [ApiController]
    [Route("/")]
    public class UrlShorteningController : ControllerBase
    {
        private readonly IUrlShorteningService _urlShorteningService;

        public UrlShorteningController(IUrlShorteningService urlShorteningService)
        {
            _urlShorteningService = urlShorteningService;
        }

        [HttpGet]
        [Route("{shortenedUrl}")]
        public async Task<IActionResult> RedirectToOriginalUrl(string shortenedUrl)
        {
            var decodedUrl = HttpUtility.UrlDecode(shortenedUrl);
            var url = await _urlShorteningService.GetUrl(decodedUrl);

            if (url is null)
            {
                return NotFound();
            }

            return Redirect(url);
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateShortening(string url)
        {
            var shortening = await _urlShorteningService.CreateShortening(url);
            var host = HttpContext.Request.Host;
            
            return $"{host}/{shortening}";
        }
    }
}