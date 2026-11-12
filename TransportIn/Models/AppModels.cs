namespace TransportIn.Models
{
    // Ролі користувачів у системі
    public enum UserRole
    {
        Admin,
        Manager,
        Driver
    }

    // Модель користувача (для входу та реєстрації)
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; // Для університетського проєкту поки що простий текст
        public UserRole Role { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }

    // Модель вантажу (для менеджера)
    public class Cargo
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty; // Що за товар
        public double WeightKg { get; set; }             // Вага
        public string TransportConditions { get; set; } = string.Empty; // Наприклад: "Холодильник (+4°C)"

        // Контакти
        public string SenderName { get; set; } = string.Empty;
        public string SenderPhone { get; set; } = string.Empty;
        public string RecipientName { get; set; } = string.Empty;
        public string RecipientPhone { get; set; } = string.Empty;
    }

    // Модель маршруту та статусу перевезення (для водія та трекінгу)
    public class TransportRoute
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public int CargoId { get; set; }

        // Статуси: На складі, Загружається, В дорозі, Розвантажується, Завершено
        public string Status { get; set; } = "На складі";

        // Координати для мапи
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}