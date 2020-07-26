using Monitor.Models;
using System.Linq;

namespace Monitor.Services
{
    public class UserService : IUserService
    {
        private readonly MonitorContext _context;

        public UserService(MonitorContext context)
        {
            _context = context;
        }

        public bool Login(string email, string password)
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == email && x.Password == password);

            return !(user is null);
        }

        public User Save(User user)
        {
            _context.Add(user);
            _context.SaveChanges();

            return user;
        }
    }
}
