using Microsoft.AspNetCore.Mvc;
using CareCenterApi.Model; 
using CareCenterApi.Service;


namespace CareCenterApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        
        private readonly ILogin _loginService;

        public LoginController(ILogin loginService)
        {
            _loginService = loginService;
        }

        [HttpGet("signin")]
        public async Task<IActionResult> SignIn(string userId, string password)
        {
            var user = await _loginService.Signin(userId, password);
            if (user != null)
            {
            return Ok(user.ToString());
            }
            return Unauthorized("Invalid user ID or password");
        }

        [HttpPost("signup")]
        public IActionResult SignUp([FromBody] LoginUser signUp)
        {

        var result = _loginService.Signup(signUp);
        if (result!=null)
        {
            return Ok(result.ToString());
        }
        return BadRequest("Sign up failed");
            
        }
    }

   
}