
using TransportIn.Services;

namespace TransportIn.Models
{
    public class OrderStatusHistory
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order? Order { get; set; }

        public string PreviousStatus { get; set; } = "";

        public string NewStatus { get; set; } = "";

        public DateTime ChangedAt { get; set; } = DateTime.UtcNow;

        public int? ChangedByEmployeeId { get; set; }
        public Employee? ChangedByEmployee { get; set; }

        public string Comment { get; set; } = "";
    }
}
