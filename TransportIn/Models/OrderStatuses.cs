
namespace TransportIn.Models
{
    public class OrderStatus
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string Description { get; set; } = "";

        public bool IsActive { get; set; } = true;
    }
}
