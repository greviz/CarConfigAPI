using CarConfigAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarConfigAPI.Controllers
{
    [Route("/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        CarConfigApiContext db;
        public UserController()
        {
            db = new CarConfigApiContext();
        }


        [HttpPost("login")]
        public ActionResult<Users> userLogin([FromBody] LoginViewModel user)
        {
            Users foundUser = db.Users.Where(u => u.Login == user.login).FirstOrDefault();

            if (foundUser == null)
            {
                return NotFound();
            }
            else if (foundUser.Password == user.password)
            {
                return foundUser;
            }
            return NotFound();
        }

        [HttpPost("add")]
        public ActionResult<Users> userCreate([FromBody] Users user)
        {
            db.Users.Add(user);
            db.SaveChanges();

            return Accepted();
        }

        [HttpGet("view/{userId}")]
        public ActionResult<Users> getUserById(int userId)
        {
            return db.Users.Where(u => u.Id == userId).FirstOrDefault();
        }
    }
}
