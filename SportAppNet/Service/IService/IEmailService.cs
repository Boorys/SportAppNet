using SportAppNet.DTO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace SportAppNet.Service.IService
{
  public interface IEmailService
    {

        public void SendEmail(UserPostDTO userPostDTO);
        public bool CheckEmailToken(string token);
        public JwtSecurityToken DecodeJwtToken(string token);
    }
}
