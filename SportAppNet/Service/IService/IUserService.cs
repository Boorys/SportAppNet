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
        public AuthenticateResponse Authenticate(UserCredentialGetDTO userCredentialGetDTO);
        public void ActivateUser(string email);
        public bool CheckEmailExist(string email);
    }
}
