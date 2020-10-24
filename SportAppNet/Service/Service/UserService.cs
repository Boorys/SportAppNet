using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SportAppNet.DTO;
using SportAppNet.Entity;
using SportAppNet.Repository;
using SportAppNet.Service.IService;
using SportAppNet.Tool;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SportAppNet.Service.Service
{
    public class UserService : IUserService
    {

        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly AppSettings _appSettings;

        public UserService(IMapper mapper, IUserRepository userRepository, IOptions<AppSettings> appSettings)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
        }

        public void AddNewUser(UserPostDTO userPostDTO)
        {
            userPostDTO.Password = PasswordTools.sha256(userPostDTO.Password);
            UserEntity userEntity = _mapper.Map<UserEntity>(userPostDTO);
            userEntity.Role = Role.USER.ToString();
            _userRepository.AddNewUser(userEntity);

        }

        public void LoginUser(string email)
        {
            throw new NotImplementedException();
        }


        public AuthenticateResponse Authenticate(UserCredentialGetDTO userCredentialGetDTO)
        {
            var user = _userRepository.UserByCredential(userCredentialGetDTO);

            if (user == null)
                return null;

            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);

        }


        private string generateJwtToken(UserEntity user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    }
}
