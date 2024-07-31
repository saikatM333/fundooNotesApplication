using ModelLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces.Users
{
    public  interface IloginRL
    {
        string Login(LoginModel model);
    }
}
