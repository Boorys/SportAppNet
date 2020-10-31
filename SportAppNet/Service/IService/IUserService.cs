using SportAppNet.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAppNet.Service.IService
{
    public interface IUserService
    {
        public bool AddNewUser(UserPostDTO userPostDTO);
        public AuthenticateResponse Authenticate(UserCredentialGetDTO userCredentialGetDTO);
        public void ActivateUser(string email);
    }
}
