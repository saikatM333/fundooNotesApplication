using Microsoft.Extensions.Configuration;
using ModelLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.FundooDbContext;
using RepositoryLayer.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services.Users
{
    public class RegisterRL : IregisterRL
    {private readonly FundooNotesDBContext _fundooDbContext;
        private readonly IConfiguration _configration;

        public RegisterRL( FundooNotesDBContext fundooNotesDBContext , IConfiguration configuration) 
        {
            _fundooDbContext = fundooNotesDBContext;
            _configration = configuration;

        } 

        public UserModel register( UserModel user ) 
        
        {

            User userStore = new User();
            userStore.UserName = user.UserName;
            userStore.Email = user.Email;
            userStore.Password = user.Password;
            var result = _fundooDbContext.Users.FirstOrDefault(x => x.Email == userStore.Email);
            if (result != null)
            {
                return null;
            }
            else
            {
                _fundooDbContext.Users.Add(userStore);
                _fundooDbContext.SaveChanges();

                return user;

            }
        }
    }
}
