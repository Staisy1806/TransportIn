
using TransportIn.Services;

namespace TransportIn.Models
{
    public class OrderAssignment
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order? Order { get; set; }

        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }

        public int DriverId { get; set; }
        public Employee? Driver { get; set; }

        public DateTime AssignedAt { get; set; }

        public DateTime PlannedStart { get; set; }

        public DateTime PlannedEnd { get; set; }

        public DateTime? ActualStart { get; set; }

        public DateTime? ActualEnd { get; set; }

        public string Status { get; set; } = "Призначено";

        public string Notes { get; set; } = "";
    }
}
