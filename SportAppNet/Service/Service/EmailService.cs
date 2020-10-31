using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using SportAppNet.DTO;
using SportAppNet.Entity;
using SportAppNet.Repository;
using SportAppNet.Service.IService;
using SportAppNet.Tool;

namespace SportAppNet.Service.Service
{
    public class EmailService : IEmailService
    {

        private readonly AppSettings _appSettings;
        private readonly IUserRepository _userRepository;

        public EmailService(IOptions<AppSettings> appSettings, IUserRepository userRepository)
        {          
            _appSettings = appSettings.Value;
            _userRepository = userRepository;
        }

        public void SendEmail(UserPostDTO userPostDTO)
        {
            var message = new MimeMessage();
          
            message.From.Add(new MailboxAddress("", _appSettings.SendingEmail));
           
            message.To.Add(new MailboxAddress("", userPostDTO.Email));

            message.Subject = "Sport app net";

            var builder = new BodyBuilder();

            builder.HtmlBody = CreateEmailBody(userPostDTO);

            message.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate(_appSettings.SendingEmail, _appSettings.EmailPassword);
                client.Send(message);
                client.Disconnect(true);
            }
        }

        private string CreateEmailBody(UserPostDTO userPostDTO)
        {
            var emailHtmlBody = "<div>" +
                "Clik " +
                "<a href="+'"'+ _appSettings.Domain + generateEmailConfirmationToken(userPostDTO) + '"' +'>'+ "CONFIRM" + "</a>" + "</div>";
        
                return emailHtmlBody;
        }

        private string generateEmailConfirmationToken(UserPostDTO userPostDTO)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, userPostDTO.Email.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public JwtSecurityToken DecodeJwtToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
                return (JwtSecurityToken)validatedToken;
            }catch
            {
                return null;
            }      
        }

        public bool CheckEmailToken(string token)
        {                           
                var jwtToken = DecodeJwtToken(token);        
                var nowTime = DateTime.Now.Subtract(new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
                var email = jwtToken.Payload.FirstOrDefault(x => x.Key == "email");
                var isEmailExist = _userRepository.EmailExist(email.Value.ToString());

                if ((jwtToken.Payload.Exp > (nowTime)) && isEmailExist)
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }             
    }
}
