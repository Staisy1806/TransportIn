
namespace TransportIn.Models
{
    public class OrderPoint
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order? Order { get; set; }

        public string PointType { get; set; } = "Завантаження";

        public string Address { get; set; } = "";

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public string ContactName { get; set; } = "";

        public string ContactPhone { get; set; } = "";

        public int SequenceNumber { get; set; }

        public DateTime? PlannedArrival { get; set; }

        public DateTime? ActualArrival { get; set; }

        public string Status { get; set; } = "Очікується";

        public string Notes { get; set; } = "";
    }
}
