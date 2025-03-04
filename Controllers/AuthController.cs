using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NotesServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet("Verify")]
        [Authorize]
        public IActionResult VerifyUser()
        {
            return Ok(new { message="Authorized" });
        }
    }
}
