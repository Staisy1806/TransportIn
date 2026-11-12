
using System;
using TransportIn.Services;

namespace TransportIn.Models
{
    public class DriverSchedule
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public DateOnly WorkDate { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public string ShiftType { get; set; } = "Денна";

        public bool IsAvailable { get; set; } = true;

        public string Notes { get; set; } = "";

        public Employee? Employee { get; set; }
    }
}
