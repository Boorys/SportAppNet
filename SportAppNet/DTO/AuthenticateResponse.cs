
using SportAppNet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAppNet.DTO
{
    public class AuthenticateResponse
    {

        public string FirstName { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(UserEntity user, string token)
        {
            FirstName = user.FirstName;
            Token = token;
        }
    }
}
