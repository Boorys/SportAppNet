using Microsoft.AspNetCore.Mvc;
using SportAppNet.Service.IService;
using SportAppNet.Tool;
using Microsoft.AspNetCore.Http;
using SportAppNet.DTO;
using Microsoft.AspNetCore.Authorization;

namespace SportAppNet.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;

        }

        [HttpGet("authentification")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Authenticate(UserCredentialGetDTO model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return StatusCode(401, "Username or password is incorrect");

            return Ok(response);
        }

        [Microsoft.AspNetCore.Authorization.Authorize(Roles = Role.USER)]
        [HttpGet("users")]
        public IActionResult GetAll()
        {

            return Ok();
        }

    }
}
