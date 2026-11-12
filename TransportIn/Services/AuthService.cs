
using Microsoft.EntityFrameworkCore;
using TransportIn.Data;
using TransportIn.Models;

namespace TransportIn.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public User? CurrentUser { get; private set; }

        public User? Login(string username, string password)
        {
            var user = _context.Users
                .AsNoTracking()
                .FirstOrDefault(u =>
                    u.Username == username &&
                    u.Password == password);

            if (user != null)
            {
                CurrentUser = user;
            }

            return user;
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        public void RegisterUser(
            string username,
            string password,
            UserRole role,
            string fullName,
            string phone)
        {
            bool userExists = _context.Users
                .Any(u => u.Username == username);

            if (userExists)
            {
                throw new InvalidOperationException(
                    "Користувач з таким логіном вже існує.");
            }

            var newUser = new User
            {
                Username = username,
                Password = password,
                Role = role,
                FullName = fullName,
                Phone = phone
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return _context.Users
                .AsNoTracking()
                .OrderBy(u => u.Id)
                .ToList();
        }
    }
}
