using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Infrastructure;

using SportAppNet.Service.IService;
using SportAppNet.Service.Service;
using Xunit;
using Moq;
using SportAppNet.Repository;
using SportAppNet.Tool;
using Microsoft.Extensions.Options;
using SportAppNet.DTO;
using SportAppNet.Entity;

namespace SportAppNetTest
{
    public class UnitTest1
    {
       
        private readonly UserService _userService;
        private readonly Mock<IUserRepository> _userRepositoryMock = new Mock<IUserRepository>();
        private readonly Mock<IEmailService> _emailServiceMock = new Mock<IEmailService>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
        private readonly IOptions<AppSettings> _appSettings = Options.Create<AppSettings>(new AppSettings());



        public UnitTest1()
        {
            _appSettings.Value.Secret = "THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING";
            _userService = new UserService(_mapperMock.Object, _userRepositoryMock.Object, _appSettings, _emailServiceMock.Object);
        }

        [Fact]
        public void AuthenticateShouldReturnAuthenticateResponseTest()
        {
           //given
            var userCredentialGetDto = new UserCredentialGetDTO();
            userCredentialGetDto.Email = "test@email";
            userCredentialGetDto.Password = "1234";
            var userEntity = new UserEntity();
            userEntity.Role = "ADMIN";
            userEntity.FirstName = "Tom";
            _userRepositoryMock.Setup(x => x.UserByCredential(userCredentialGetDto)).Returns(userEntity); 
            
            //when
            var authenticateResponse = _userService.Authenticate(userCredentialGetDto);

            //then
            //AuthenticateResponse(user, token);
            Assert.Equal(userEntity.FirstName,authenticateResponse.FirstName);
            Assert.NotEqual("",authenticateResponse.Token);
            Assert.NotNull(authenticateResponse.Token);
            
        }
    }
}
