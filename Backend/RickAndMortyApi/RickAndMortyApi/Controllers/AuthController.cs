using Microsoft.AspNetCore.Mvc;
using RickAndMortyApi.DAL.Models;
using RickAndMortyApi.Models;
using RickAndMortyApi.Services;

namespace RickAndMortyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;
        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(UserDto reqest)
        {
            var user = await userService.Create(reqest);

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto reqest)
        {
            try
            {
                var jwtToken = await userService.GetJwtToken(reqest);

                return Ok(jwtToken);
            }
            catch (NullReferenceException)
            {
                return BadRequest("Incorrect login");
            }
            catch (ArgumentException)
            {
                return BadRequest("Incorrect password");
            }
            catch (Exception)
            {
                return BadRequest("Incorrect user");
            }
        }
    }
}
