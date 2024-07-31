using BuisnessLayer.Interfaces.User;
using ModelLayer.Model;
using RepositoryLayer.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Services.User
{
    public  class LoginBL: IloginBL
    {
        private readonly IloginRL _iloginRL;
        public LoginBL(IloginRL ilogin) 
        {
            _iloginRL = ilogin;
        }

        public string Login(LoginModel user) 
        { 
        
            var result = _iloginRL.Login(user);
            return result;
        
        }
    }
}
