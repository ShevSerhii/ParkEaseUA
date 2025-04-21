using Microsoft.AspNetCore.Mvc;
using ParkingPlatform.Application.DTOs.Auth;
using ParkingPlatform.Application.Interfaces;

namespace ParkingPlatform.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            var result = await _authService.RegisterAsync(model);

            if (!result.Success)
            {
                return BadRequest(new
                {
                    message = result.Message,
                    errors = result.Errors
                });
            }

            return Ok(new
            {
                message = result.Message
            });
        }
    }
}