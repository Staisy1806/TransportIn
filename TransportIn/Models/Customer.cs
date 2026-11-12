
namespace TransportIn.Models
{
    public class Customer
    {
        public int Id { get; set; }

        // Информация о компании
        public string CompanyName { get; set; } = "";
        public string Edrpou { get; set; } = "";

        // Контактная информация
        public string Address { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Email { get; set; } = "";

        // Дополнительная информация
        public string Notes { get; set; } = "";
        public bool IsActive { get; set; } = true;
    }
}
