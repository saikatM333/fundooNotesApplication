using BuisnessLayer.Interfaces.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Model;

namespace FundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IregisterBL _iregisterBL;
        private readonly IloginBL _loginBL;
        public UsersController(IregisterBL iregisterBL , IloginBL ilogin) 
        {
            _iregisterBL = iregisterBL;
            _loginBL = ilogin;
        }

        [HttpPost("register")]
        public IActionResult register(UserModel user)
        {   
            var result = _iregisterBL.register(user);
            return Ok(result);
        }

        [HttpPost("login")]
        public IActionResult login(LoginModel user) 
        
        { 
            var data = _loginBL.Login(user);
            return Ok(data);
        }
    }
}
