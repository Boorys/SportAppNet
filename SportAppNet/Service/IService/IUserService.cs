using SportAppNet.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAppNet.Service.IService
{
    public interface IUserService
    {
        public void AddNewUser(UserPostDTO userPostDTO);
        public void LoginUser(string email);
        public AuthenticateResponse Authenticate(UserCredentialGetDTO userCredentialGetDTO);
    }
}
