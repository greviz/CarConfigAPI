using CarConfigAPI.ViewModels;

namespace CarConfigAPI.Interfaces
{
    public interface IUserService
    {
        public void CreateUser(Users user);
        public Users GetUserById(int userId);
        public Users UserLogin(LoginViewModel user);
    }
}
