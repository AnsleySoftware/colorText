using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace colorTextBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncoderController : ControllerBase
    {
        [HttpPost("encode")]
        public IActionResult Encode([FromBody] EncodeRequest request)
        {
            TextEncoder encoder = new TextEncoder();
            List<string> encodedText = encoder.EncodeTextToColor(request.Input);
            return Ok(encodedText);
        }



        [HttpPost("decode")]
        public IActionResult DecodeColors([FromBody] DecodeRequest request)
        {
            TextDecoder decoder = new TextDecoder();
            string decodedText = decoder.DecodeColorToText(request.Colors);
            return Ok(decodedText);
        }

    }

    public class EncodeRequest
    {
        public string Input { get; set; }
    }

    public class DecodeRequest
    {
        public List<string> Colors {  get; set; }
    }
}
