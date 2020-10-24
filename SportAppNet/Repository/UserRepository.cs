using SportAppNet.DTO;
using SportAppNet.Entity;
using SportAppNet.Tool;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SportAppNet.Repository
{
    public class UserRepository : IUserRepository
    {
        public void AddNewUser(UserEntity userEntity)
        {
            using (var context = new Context())
            {
                context.UserEntity.Add(userEntity);
                context.SaveChanges();
            }
        }
        public bool EmailExist(UserPostDTO userPostDTO)
        {
            using (var context = new Context())
            {
                var user = context.UserEntity.Where(x => x.Email == userPostDTO.Email).FirstOrDefault();
                return (user != null);
            }
        }

        public UserEntity UserByCredential(UserCredentialGetDTO userCredentialGetDTO)
        {
            using (var context = new Context())
            {
                var user = context.UserEntity.SingleOrDefault(x => x.Email == userCredentialGetDTO.Email && x.Password == PasswordTools.sha256(userCredentialGetDTO.Password));

                return user;
            }
        }

        public UserEntity GetUserById(int id)
        {
            using (var context = new Context())
            {
                return context.UserEntity.Where(x => x.Id == id).FirstOrDefault();
            }
        }
    }
}
