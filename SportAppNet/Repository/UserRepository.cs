using Org.BouncyCastle.Math.EC.Rfc7748;
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
        public bool EmailExist(string email)
        {
            using (var context = new Context())
            {
                var user = context.UserEntity.Where(x => x.Email == email).FirstOrDefault();
                return (user != null);
            }
        }
        public UserEntity UserByCredential(UserCredentialGetDTO userCredentialGetDTO)
        {
            using (var context = new Context())
            {
                var user = context.UserEntity.SingleOrDefault(x => x.Email == userCredentialGetDTO.Email && 
                x.Password == PasswordTools.sha256(userCredentialGetDTO.Password) &&
                x.IsActive == true);

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
        public UserEntity GetUserByEmail(string email ,Context context)
        {               
           return context.UserEntity.FirstOrDefault(x => x.Email == email);        
        }
    }
}
