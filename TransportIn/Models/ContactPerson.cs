
namespace TransportIn.Models
{
    public class ContactPerson
    {
        public int Id { get; set; }

        // Компания, к которой относится контактное лицо
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        // Информация о человеке
        public string FullName { get; set; } = "";
        public string Position { get; set; } = "";

        // Контакты
        public string Phone { get; set; } = "";
        public string Email { get; set; } = "";

        // Основное контактное лицо компании
        public bool IsPrimary { get; set; } = false;

        public bool IsActive { get; set; } = true;
    }
}
