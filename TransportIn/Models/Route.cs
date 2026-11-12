
namespace TransportIn.Models
{
    public class Route
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order? Order { get; set; }

        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }

        public string StartPoint { get; set; } = "";

        public string EndPoint { get; set; } = "";

        public double DistanceKm { get; set; }

        public int EstimatedDurationMinutes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string Status { get; set; } = "Заплановано";
    }
}
