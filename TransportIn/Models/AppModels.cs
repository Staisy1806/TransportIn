using TransportIn.Services;

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

    public class OrderCargo
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order? Order { get; set; }

        public int CargoId { get; set; }
        public Cargo? Cargo { get; set; }

        public int Quantity { get; set; } = 1;

        public string Notes { get; set; } = "";
    }

    public class VehicleStatus
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string Description { get; set; } = "";

        public bool IsActive { get; set; } = true;
    }

    public class RoutePoint
    {
        public int Id { get; set; }

        public int RouteId { get; set; }
        public Route? Route { get; set; }

        public int SequenceNumber { get; set; }

        public string PointType { get; set; } = "Проміжна";

        public string Address { get; set; } = "";

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public DateTime? PlannedArrival { get; set; }

        public DateTime? ActualArrival { get; set; }

        public string Notes { get; set; } = "";
    }

    public class RouteHistory
    {
        public int Id { get; set; }

        public int RouteId { get; set; }
        public Route? Route { get; set; }

        public string PreviousStatus { get; set; } = "";

        public string NewStatus { get; set; } = "";

        public string Description { get; set; } = "";

        public DateTime ChangedAt { get; set; } = DateTime.UtcNow;

        public int? ChangedByEmployeeId { get; set; }
        public Employee? ChangedByEmployee { get; set; }
    }

    public class RoadEvent
    {
        public int Id { get; set; }

        public string EventType { get; set; } = "";

        public string Title { get; set; } = "";

        public string Description { get; set; } = "";

        public string Address { get; set; } = "";

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public DateTime StartedAt { get; set; } = DateTime.UtcNow;

        public DateTime? EndedAt { get; set; }

        public string Severity { get; set; } = "Середній";

        public bool IsActive { get; set; } = true;
    }

    public class RoadRestriction
    {
        public int Id { get; set; }

        public string RestrictionType { get; set; } = "";

        public string Description { get; set; } = "";

        public string Address { get; set; } = "";

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public double? MaxWeightTons { get; set; }

        public double? MaxHeightMeters { get; set; }

        public double? MaxWidthMeters { get; set; }

        public double? MaxLengthMeters { get; set; }

        public DateTime StartedAt { get; set; } = DateTime.UtcNow;

        public DateTime? EndedAt { get; set; }

        public bool IsActive { get; set; } = true;
    }

    public class SafeLocation
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string LocationType { get; set; } = "";

        public string Address { get; set; } = "";

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int? Capacity { get; set; }

        public bool HasSecurity { get; set; }

        public bool HasParking { get; set; }

        public bool HasFuel { get; set; }

        public bool HasRepairService { get; set; }

        public string Description { get; set; } = "";

        public bool IsActive { get; set; } = true;
    }

  
    public class RuleExecutionHistory
    {
        public int Id { get; set; }

        public int ExpertRuleId { get; set; }
        public ExpertRule? ExpertRule { get; set; }

        public DateTime ExecutedAt { get; set; } = DateTime.UtcNow;

        public string TriggerDescription { get; set; } = "";

        public string Result { get; set; } = "";

        public string Details { get; set; } = "";

        public bool WasSuccessful { get; set; }

        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }

    public class Notification
    {
        public int Id { get; set; }

        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public string Title { get; set; } = "";

        public string Message { get; set; } = "";

        public string NotificationType { get; set; } = "";

        public bool IsRead { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? ReadAt { get; set; }
    }

    public class DriverReport
    {
        public int Id { get; set; }

        public int DriverId { get; set; }
        public Employee? Driver { get; set; }

        public int? OrderId { get; set; }
        public Order? Order { get; set; }

        public int? RouteId { get; set; }
        public Route? Route { get; set; }

        public string ReportType { get; set; } = "";

        public string Description { get; set; } = "";

        public string CargoCondition { get; set; } = "";

        public string VehicleCondition { get; set; } = "";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool RequiresAttention { get; set; }
    }

    public class VehicleLocation
    {
        public int Id { get; set; }

        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double? SpeedKmh { get; set; }

        public double? DirectionDegrees { get; set; }

        public DateTime RecordedAt { get; set; } = DateTime.UtcNow;
    }
    public class RuleCondition
    {
        public int Id { get; set; }

        public int ExpertRuleId { get; set; }
        public ExpertRule? ExpertRule { get; set; }

        public string Parameter { get; set; } = "";
        public string Operator { get; set; } = "";
        public string ExpectedValue { get; set; } = "";

        public string LogicalOperator { get; set; } = "AND";

        public int SequenceNumber { get; set; }

        public string Description { get; set; } = "";
    }
    public class ActivityLog
    {
        public int Id { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }

        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public string Action { get; set; } = "";

        public string EntityName { get; set; } = "";

        public int? EntityId { get; set; }

        public string Description { get; set; } = "";

        public string IpAddress { get; set; } = "";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}