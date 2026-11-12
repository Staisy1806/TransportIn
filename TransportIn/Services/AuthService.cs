using TransportIn.Models;

namespace TransportIn.Services
{
    public class AuthService
    {
        // Початкові тестові користувачі для перевірки
        private readonly List<User> _users = new()
        {
            new User { Id = 1, Username = "admin", Password = "123", Role = UserRole.Admin, FullName = "Головний Адмін", Phone = "+380000000001" },
            new User { Id = 2, Username = "manager", Password = "123", Role = UserRole.Manager, FullName = "Менеджер Складу", Phone = "+380000000002" },
            new User { Id = 3, Username = "driver", Password = "123", Role = UserRole.Driver, FullName = "Водій Рефрижератора", Phone = "+380000000003" }
        };

        public User? CurrentUser { get; private set; }

        public User? Login(string username, string password)
        {
            var user = _users.FirstOrDefault(u => u.Username == username && u.Password == password);
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

        public void RegisterUser(string username, string password, UserRole role, string fullName, string phone)
        {
            var newUser = new User
            {
                Id = _users.Count + 1,
                Username = username,
                Password = password,
                Role = role,
                FullName = fullName,
                Phone = phone
            };
            _users.Add(newUser);
        }

        public List<User> GetAllUsers() => _users;
    }
}