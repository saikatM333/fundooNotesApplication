using ModelLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Interfaces.User
{
    public  interface IloginBL
    {
        string Login( LoginModel loginModel);
    }
}
