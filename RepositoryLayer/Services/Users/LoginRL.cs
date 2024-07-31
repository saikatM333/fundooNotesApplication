using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ModelLayer.Model;
using RepositoryLayer.FundooDbContext;
using RepositoryLayer.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services.Users
{
    public class LoginRL:IloginRL
    {   
        readonly private FundooNotesDBContext _dbContext;
        readonly private IConfiguration _configuration;
        public LoginRL(FundooNotesDBContext fundooNotesDBContext , IConfiguration configuration) 
        {
            _configuration = configuration;
            _dbContext = fundooNotesDBContext;
        }

        public string Login(LoginModel model)
        {

            var result = _dbContext.Users.FirstOrDefault(x=>x.Email == model.Email && x.Email.Equals(model.Email));
            if (result == null)
            {
                return null;
            }
            else
            {
                UserModel userModel = new UserModel();
                userModel.Email = result.Email;
                userModel.Password = result.Password;
                userModel.UserName = result.UserName;

                var claim = new[]
                {
                    new Claim(ClaimTypes.Email, result.Email),
                    //new Claim(ClaimTypes.NameIdentifier , Cresult.UserId)
                    new Claim(ClaimTypes.Name , ClaimTypes.Name)
                };
                var token = new JwtSecurityToken(
                 issuer: _configuration["Jwt:Issuer"],
                 audience: _configuration["Jwt:Audience"],
                 claims: claim,
                 expires: DateTime.UtcNow.AddDays(1),
                 notBefore: DateTime.UtcNow,
                 signingCredentials: new SigningCredentials(
                   new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                   SecurityAlgorithms.HmacSha256
                     )
                 ) ;

                var TokenString = new JwtSecurityTokenHandler().WriteToken(token);
                return TokenString;
            }

        }
    }
}
