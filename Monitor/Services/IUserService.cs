using Monitor.Models;

namespace Monitor.Services
{
    public interface IUserService
    {
        User Save(User user);
        bool Login(string email, string password);
    }
}
