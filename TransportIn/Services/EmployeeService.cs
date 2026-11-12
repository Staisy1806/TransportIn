
using Microsoft.EntityFrameworkCore;
using TransportIn.Data;
using TransportIn.Models;

namespace TransportIn.Services
{
    public class Employee
    {
            public int Id { get; set; }

            public string FullName { get; set; } = "";

            public string Address { get; set; } = "";

            public string Phone { get; set; } = "";

            public string Email { get; set; } = "";

            public string PhotoPath { get; set; } = "";

            public int RoleId { get; set; }

            public Role? RoleInfo { get; set; }

            // Оставляем для совместимости с существующей страницей администратора
            public string Role { get; set; } = "Водій";

            public string LicenseCategory { get; set; } = "C, CE";

            public string MedicalCertExpiry { get; set; } = "01.01.2027";

            public bool IsActive { get; set; } = true;
        }

        public class EmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public event Action? OnChange;

        public List<Employee> GetAllEmployees()
        {
            return _context.Employees
                .AsNoTracking()
                .OrderBy(e => e.Id)
                .ToList();
        }

        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();

            NotifyStateChanged();
        }

        public void DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();

                NotifyStateChanged();
            }
        }

        private void NotifyStateChanged()
        {
            OnChange?.Invoke();
        }
    }
}
