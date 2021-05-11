using CarConfigAPI.Interfaces;
using CarConfigAPI.ViewModels;
using System.Linq;

namespace CarConfigAPI.Services
{
    public class UserService : IUserService
    {
        private readonly CarConfigApiContext dbContext;
        public UserService(CarConfigApiContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void CreateUser(Users user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }
        public Users GetUserById(int userId)
        {
            return dbContext.Users.Where(u => u.Id == userId).FirstOrDefault();
        }
        public Users UserLogin(LoginViewModel user)
        {
            Users foundUser = dbContext.Users.Where(u => u.Login == user.login).FirstOrDefault();

            if (foundUser == null)
            {
                return null;
            }

            if (foundUser.Password == user.password)
            {
                return foundUser;
            }
            else
            {
                return null;
            }
        }
    }
}
