using Microsoft.AspNetCore.Mvc;
using TelecomRewardsApi.Service;

namespace TelecomRewardsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Ovo je pr., u realnoj aplikaciji treba proveriti korisnika iz baze
            if (request.Username == "test" && request.Password == "password")
            {
                var token = _authService.GenerateToken(request.Username);
                return Ok(new { Token = token });
            }
            return Unauthorized();
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
