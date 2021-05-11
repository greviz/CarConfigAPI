using CarConfigAPI.Services;
using CarConfigAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CarConfigAPI.Controllers
{
    [Route("/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("login")]
        public ActionResult<Users> userLogin([FromBody] LoginViewModel user)
        {
            return userService.UserLogin(user);
        }

        [HttpPost("add")]
        public ActionResult<Users> userCreate([FromBody] Users user)
        {
            userService.CreateUser(user);

            return Accepted();
        }

        [HttpGet("view/{userId}")]
        public ActionResult<Users> getUserById(int userId)
        {
            return userService.GetUserById(userId);
        }
    }
}
