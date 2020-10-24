using SportAppNet.DTO;
using SportAppNet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAppNet.Repository
{
    public interface IUserRepository
    {
        public void AddNewUser(UserEntity userEntity);
        public bool EmailExist(UserPostDTO userPostDTO);
        public UserEntity UserByCredential(UserCredentialGetDTO userCredentialGetDTO);
        public UserEntity GetUserById(int id);
    }
}
