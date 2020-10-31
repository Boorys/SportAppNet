using Microsoft.AspNetCore.Mvc;
using SportAppNet.Service.IService;
using SportAppNet.Tool;
using Microsoft.AspNetCore.Http;
using SportAppNet.DTO;
using Microsoft.AspNetCore.Authorization;
using SportAppNet.Service.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace SportAppNet.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public UserController(IUserService userService,IEmailService emailService)
        {
            _userService = userService;
            _emailService = emailService;
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

        [HttpGet]
        [Route("email-confirm/{token}")]
        public IActionResult ConfirmEmail(string token)
        {             
          bool emailConfirmation = _emailService.CheckEmailToken(token);

            if (emailConfirmation)
            {
                JwtSecurityToken tokenJwt = _emailService.DecodeJwtToken(token);
                string email = tokenJwt.Payload.FirstOrDefault(x => x.Key == "email").Value.ToString();
                _userService.ActivateUser(email);
            }
            return null;
        }

        [HttpPost("add")]
        public IActionResult CreateUser(UserPostDTO userPostDTO)
        {
           var isCreated = _userService.AddNewUser(userPostDTO);

            if (!isCreated)
                return StatusCode(401, "Email exist");

            return Ok();
        }

        [Microsoft.AspNetCore.Authorization.Authorize(Roles = Role.USER)]
        [HttpGet("users")]
        public IActionResult GetAll()
        {
            return Ok();
        }

    }
}
