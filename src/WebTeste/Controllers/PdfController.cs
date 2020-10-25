using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        private readonly WkHtmlSmartConvert.IPdfConvert _pdfConvert;

        public PdfController(WkHtmlSmartConvert.IPdfConvert pdfConvert)
        {
            _pdfConvert = pdfConvert;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var html = "<html><body><strong>Name: </strong> Teste</body></html>";
            var buffer = await _pdfConvert.ConvertAsync(html);
            return File(buffer, "application/pdf");
        }
    }
}
