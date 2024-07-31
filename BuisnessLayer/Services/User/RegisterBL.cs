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
    public class RegisterBL: IregisterBL
    {
        private readonly IregisterRL _iregisterRl;
       
        public RegisterBL(IregisterRL iregisterRL) 
        {
            _iregisterRl = iregisterRL;
        } 

        public UserModel register(UserModel model)
        {
            var userModel = _iregisterRl.register(model);
            return userModel;
        }

    }
}
