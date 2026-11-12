namespace TransportIn.Services
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public string Role { get; set; } = "Водій"; // Адміністратор, Менеджер, Водій
        public string Phone { get; set; } = "";
        public string LicenseCategory { get; set; } = "C, CE"; // Категорії водія
        public string MedicalCertExpiry { get; set; } = "01.01.2027"; // Термін дії медкнижки
        public bool IsActive { get; set; } = true;
    }

    public class EmployeeService
    {
        private List<Employee> employees = new()
        {
            new Employee { Id = 1, FullName = "Іван Водійченко", Role = "Водій", Phone = "0501112233", LicenseCategory = "C, CE", MedicalCertExpiry = "12.10.2026", IsActive = true },
            new Employee { Id = 2, FullName = "Петро Дальнобій", Role = "Водій", Phone = "0672223344", LicenseCategory = "C1, C", MedicalCertExpiry = "05.05.2027", IsActive = true },
            new Employee { Id = 3, FullName = "Олена Менеджер", Role = "Менеджер", Phone = "0933334455", LicenseCategory = "-", MedicalCertExpiry = "-", IsActive = true }
        };

        public event Action? OnChange;

        public List<Employee> GetAllEmployees() => employees;

        public void AddEmployee(Employee employee)
        {
            employee.Id = employees.Count > 0 ? employees.Max(e => e.Id) + 1 : 1;
            employees.Add(employee);
            NotifyStateChanged();
        }

        public void DeleteEmployee(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                employees.Remove(emp);
                NotifyStateChanged();
            }
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}