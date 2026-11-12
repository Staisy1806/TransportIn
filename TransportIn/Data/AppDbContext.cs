
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TransportIn.Models;
using TransportIn.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace TransportIn.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<TransportRoute> TransportRoutes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ExpertRule> ExpertRules { get; set; }
        public DbSet<EmployeeDocument> EmployeeDocuments { get; set; }
        public DbSet<DriverSchedule> DriverSchedules { get; set; }
        public DbSet<VehicleDocument> VehicleDocuments { get; set; }
        public DbSet<VehicleEquipment> VehicleEquipments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ContactPerson> ContactPersons { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<OrderPoint> OrderPoints { get; set; }
        public DbSet<OrderAssignment> OrderAssignments { get; set; }
        public DbSet<OrderStatusHistory> OrderStatusHistories { get; set; }
        public DbSet<TransportIn.Models.Route> Routes { get; set; }
        public DbSet<OrderCargo> OrderCargos { get; set; }
        public DbSet<VehicleStatus> VehicleStatuses { get; set; }
        public DbSet<RoutePoint> RoutePoints { get; set; }
        public DbSet<RouteHistory> RouteHistories { get; set; }
        public DbSet<RoadEvent> RoadEvents { get; set; }
        public DbSet<RoadRestriction> RoadRestrictions { get; set; }
        public DbSet<SafeLocation> SafeLocations { get; set; }
        public DbSet<RuleCondition> RuleConditions { get; set; }
        public DbSet<RuleExecutionHistory> RuleExecutionHistories { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<DriverReport> DriverReports { get; set; }
        public DbSet<VehicleLocation> VehicleLocations { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<VehicleLocation>(entity =>
            {
                entity.HasKey(vl => vl.Id);

                entity.HasOne(vl => vl.Vehicle)
                    .WithMany()
                    .HasForeignKey(vl => vl.VehicleId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(vl => vl.RecordedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.ToTable(t =>
                {
                    t.HasCheckConstraint(
                        "CK_VehicleLocations_Latitude",
                        "\"Latitude\" >= -90 AND \"Latitude\" <= 90");

                    t.HasCheckConstraint(
                        "CK_VehicleLocations_Longitude",
                        "\"Longitude\" >= -180 AND \"Longitude\" <= 180");

                    t.HasCheckConstraint(
                        "CK_VehicleLocations_Speed",
                        "\"SpeedKmh\" IS NULL OR \"SpeedKmh\" >= 0");

                    t.HasCheckConstraint(
                        "CK_VehicleLocations_Direction",
                        "\"DirectionDegrees\" IS NULL OR (\"DirectionDegrees\" >= 0 AND \"DirectionDegrees\" < 360)");
                });

                entity.HasIndex(vl => new
                {
                    vl.VehicleId,
                    vl.RecordedAt
                });
            });

            modelBuilder.Entity<DriverReport>(entity =>
            {
                entity.HasKey(dr => dr.Id);

                entity.HasOne(dr => dr.Driver)
                    .WithMany()
                    .HasForeignKey(dr => dr.DriverId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(dr => dr.Order)
                    .WithMany()
                    .HasForeignKey(dr => dr.OrderId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(dr => dr.Route)
                    .WithMany()
                    .HasForeignKey(dr => dr.RouteId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.Property(dr => dr.ReportType)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(dr => dr.Description)
                    .HasMaxLength(2000);

                entity.Property(dr => dr.CargoCondition)
                    .HasMaxLength(500);

                entity.Property(dr => dr.VehicleCondition)
                    .HasMaxLength(500);

                entity.Property(dr => dr.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasIndex(dr => dr.DriverId);
                entity.HasIndex(dr => dr.OrderId);
                entity.HasIndex(dr => dr.RouteId);
                entity.HasIndex(dr => dr.CreatedAt);
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(n => n.Id);

                entity.HasOne(n => n.Employee)
                    .WithMany()
                    .HasForeignKey(n => n.EmployeeId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.Property(n => n.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(n => n.Message)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(n => n.NotificationType)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(n => n.IsRead)
                    .HasDefaultValue(false);

                entity.Property(n => n.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasIndex(n => n.EmployeeId);
                entity.HasIndex(n => n.IsRead);
                entity.HasIndex(n => n.CreatedAt);
            });

            modelBuilder.Entity<RuleExecutionHistory>(entity =>
            {
                entity.HasKey(rh => rh.Id);

                entity.HasOne(rh => rh.ExpertRule)
                    .WithMany()
                    .HasForeignKey(rh => rh.ExpertRuleId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(rh => rh.Employee)
                    .WithMany()
                    .HasForeignKey(rh => rh.EmployeeId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.Property(rh => rh.ExecutedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(rh => rh.TriggerDescription)
                    .HasMaxLength(500);

                entity.Property(rh => rh.Result)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(rh => rh.Details)
                    .HasMaxLength(2000);

                entity.HasIndex(rh => rh.ExpertRuleId);
                entity.HasIndex(rh => rh.ExecutedAt);
                entity.HasIndex(rh => rh.WasSuccessful);
            });

            modelBuilder.Entity<RuleCondition>(entity =>
            {
                entity.HasKey(rc => rc.Id);

                entity.HasOne(rc => rc.ExpertRule)
                    .WithMany()
                    .HasForeignKey(rc => rc.ExpertRuleId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(rc => rc.Parameter)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(rc => rc.Operator)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(rc => rc.ExpectedValue)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(rc => rc.LogicalOperator)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(rc => rc.Description)
                    .HasMaxLength(500);

                entity.ToTable(t =>
                {
                    t.HasCheckConstraint(
                        "CK_RuleConditions_SequenceNumber",
                        "\"SequenceNumber\" > 0");

                    t.HasCheckConstraint(
                        "CK_RuleConditions_LogicalOperator",
                        "\"LogicalOperator\" IN ('AND', 'OR')");
                });

                entity.HasIndex(rc => new
                {
                    rc.ExpertRuleId,
                    rc.SequenceNumber
                }).IsUnique();
            });

            modelBuilder.Entity<SafeLocation>(entity =>
            {
                entity.HasKey(sl => sl.Id);

                entity.Property(sl => sl.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(sl => sl.LocationType)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(sl => sl.Address)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(sl => sl.Description)
                    .HasMaxLength(1000);

                entity.Property(sl => sl.IsActive)
                    .HasDefaultValue(true);

                entity.ToTable(t =>
                {
                    t.HasCheckConstraint(
                        "CK_SafeLocations_Latitude",
                        "\"Latitude\" >= -90 AND \"Latitude\" <= 90");

                    t.HasCheckConstraint(
                        "CK_SafeLocations_Longitude",
                        "\"Longitude\" >= -180 AND \"Longitude\" <= 180");

                    t.HasCheckConstraint(
                        "CK_SafeLocations_Capacity",
                        "\"Capacity\" IS NULL OR \"Capacity\" > 0");
                    entity.HasData(
    new SafeLocation
    {
        Id = 1,
        Name = "Охраняемая стоянка Киев",
        LocationType = "Стоянка",
        Address = "Киев, ул. Большая Васильковская, 100",
        Latitude = 50.4212,
        Longitude = 30.5167,
        Capacity = 50,
        HasSecurity = true,
        HasParking = true,
        HasFuel = true,
        HasRepairService = false,
        Description = "Охраняемая стоянка для грузового транспорта",
        IsActive = true
    },
    new SafeLocation
    {
        Id = 2,
        Name = "Транспортный центр Львов",
        LocationType = "Транспортный центр",
        Address = "Львов, ул. Городоцкая, 300",
        Latitude = 49.8397,
        Longitude = 24.0297,
        Capacity = 30,
        HasSecurity = true,
        HasParking = true,
        HasFuel = true,
        HasRepairService = true,
        Description = "Площадка для стоянки, заправки и обслуживания транспорта",
        IsActive = true
    },
    new SafeLocation
    {
        Id = 3,
        Name = "Безопасная площадка Одесса",
        LocationType = "Площадка",
        Address = "Одесса, ул. Атамана Головатого, 50",
        Latitude = 46.4825,
        Longitude = 30.7233,
        Capacity = 20,
        HasSecurity = true,
        HasParking = true,
        HasFuel = false,
        HasRepairService = false,
        Description = "Площадка для временной безопасной стоянки транспорта",
        IsActive = true
    }
);
                });

                entity.HasIndex(sl => sl.Name);
                entity.HasIndex(sl => sl.IsActive);
            });

            modelBuilder.Entity<RoadRestriction>(entity =>
            {
                entity.HasKey(rr => rr.Id);

                entity.Property(rr => rr.RestrictionType)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(rr => rr.Description)
                    .HasMaxLength(1000);

                entity.Property(rr => rr.Address)
                    .HasMaxLength(300);

                entity.Property(rr => rr.StartedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(rr => rr.IsActive)
                    .HasDefaultValue(true);

                entity.ToTable(t =>
                {
                    t.HasCheckConstraint(
                        "CK_RoadRestrictions_Latitude",
                        "\"Latitude\" IS NULL OR (\"Latitude\" >= -90 AND \"Latitude\" <= 90)");

                    t.HasCheckConstraint(
                        "CK_RoadRestrictions_Longitude",
                        "\"Longitude\" IS NULL OR (\"Longitude\" >= -180 AND \"Longitude\" <= 180)");

                    t.HasCheckConstraint(
                        "CK_RoadRestrictions_MaxWeight",
                        "\"MaxWeightTons\" IS NULL OR \"MaxWeightTons\" > 0");

                    t.HasCheckConstraint(
                        "CK_RoadRestrictions_MaxHeight",
                        "\"MaxHeightMeters\" IS NULL OR \"MaxHeightMeters\" > 0");

                    t.HasCheckConstraint(
                        "CK_RoadRestrictions_MaxWidth",
                        "\"MaxWidthMeters\" IS NULL OR \"MaxWidthMeters\" > 0");

                    t.HasCheckConstraint(
                        "CK_RoadRestrictions_MaxLength",
                        "\"MaxLengthMeters\" IS NULL OR \"MaxLengthMeters\" > 0");

                    t.HasCheckConstraint(
                        "CK_RoadRestrictions_Dates",
                        "\"EndedAt\" IS NULL OR \"EndedAt\" >= \"StartedAt\"");
                    entity.HasData(
    new RoadRestriction
    {
        Id = 1,
        RestrictionType = "Обмеження ваги",
        Description = "Обмеження для транспортних засобів за максимальною масою",
        Address = "м. Київ, вул. Хрещатик",
        MaxWeightTons = 10,
        StartedAt = new DateTime(2026, 11, 1, 8, 0, 0, DateTimeKind.Utc),
        EndedAt = new DateTime(2026, 11, 2, 18, 0, 0, DateTimeKind.Utc),
        IsActive = false
    },
    new RoadRestriction
    {
        Id = 2,
        RestrictionType = "Обмеження висоти",
        Description = "Обмеження висоти транспортних засобів",
        Address = "м. Харків, вул. Сумська",
        MaxHeightMeters = 3.5,
        StartedAt = new DateTime(2026, 11, 3, 8, 0, 0, DateTimeKind.Utc),
        EndedAt = new DateTime(2026, 11, 4, 18, 0, 0, DateTimeKind.Utc),
        IsActive = false
    },
    new RoadRestriction
    {
        Id = 3,
        RestrictionType = "Обмеження ширини",
        Description = "Обмеження ширини транспортних засобів",
        Address = "м. Одеса, вул. Дерибасівська",
        MaxWidthMeters = 2.5,
        StartedAt = new DateTime(2026, 11, 5, 8, 0, 0, DateTimeKind.Utc),
        EndedAt = new DateTime(2026, 11, 6, 18, 0, 0, DateTimeKind.Utc),
        IsActive = false
    }
);
                });

                entity.HasIndex(rr => rr.RestrictionType);
                entity.HasIndex(rr => rr.IsActive);
            });

            modelBuilder.Entity<RoadEvent>(entity =>
            {
                entity.HasKey(re => re.Id);

                entity.Property(re => re.EventType)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(re => re.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(re => re.Description)
                    .HasMaxLength(1000);

                entity.Property(re => re.Address)
                    .HasMaxLength(300);

                entity.Property(re => re.Severity)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(re => re.StartedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(re => re.IsActive)
                    .HasDefaultValue(true);

                entity.ToTable(t =>
                {
                    t.HasCheckConstraint(
                        "CK_RoadEvents_Latitude",
                        "\"Latitude\" IS NULL OR (\"Latitude\" >= -90 AND \"Latitude\" <= 90)");

                    t.HasCheckConstraint(
                        "CK_RoadEvents_Longitude",
                        "\"Longitude\" IS NULL OR (\"Longitude\" >= -180 AND \"Longitude\" <= 180)");

                    t.HasCheckConstraint(
                        "CK_RoadEvents_Dates",
                        "\"EndedAt\" IS NULL OR \"EndedAt\" >= \"StartedAt\"");
                    entity.HasData(
    new RoadEvent
    {
        Id = 1,
        EventType = "Ремонт дороги",
        Title = "Ремонт дорожнього покриття",
        Description = "Планові ремонтні роботи на ділянці дороги",
        Address = "м. Київ, вул. Хрещатик",
        StartedAt = new DateTime(2026, 11, 1, 8, 0, 0, DateTimeKind.Utc),
        EndedAt = new DateTime(2026, 11, 2, 18, 0, 0, DateTimeKind.Utc),
        Severity = "Середній",
        IsActive = false
    },
    new RoadEvent
    {
        Id = 2,
        EventType = "Обмеження руху",
        Title = "Тимчасове обмеження руху",
        Description = "Тимчасове обмеження руху через проведення дорожніх робіт",
        Address = "м. Харків, вул. Сумська",
        StartedAt = new DateTime(2026, 11, 3, 9, 0, 0, DateTimeKind.Utc),
        EndedAt = new DateTime(2026, 11, 4, 17, 0, 0, DateTimeKind.Utc),
        Severity = "Низький",
        IsActive = false
    },
    new RoadEvent
    {
        Id = 3,
        EventType = "Дорожні роботи",
        Title = "Ремонт дорожньої ділянки",
        Description = "Завершені роботи з відновлення дорожнього покриття",
        Address = "м. Одеса, вул. Дерибасівська",
        StartedAt = new DateTime(2026, 11, 5, 8, 0, 0, DateTimeKind.Utc),
        EndedAt = new DateTime(2026, 11, 6, 16, 0, 0, DateTimeKind.Utc),
        Severity = "Середній",
        IsActive = false
    }
);
                });

                entity.HasIndex(re => re.EventType);
                entity.HasIndex(re => re.IsActive);
                entity.HasIndex(re => re.StartedAt);
            });

            modelBuilder.Entity<RouteHistory>(entity =>
            {
                entity.HasKey(rh => rh.Id);

                // Связь с маршрутом
                entity.HasOne(rh => rh.Route)
                    .WithMany()
                    .HasForeignKey(rh => rh.RouteId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Сотрудник, изменивший маршрут
                entity.HasOne(rh => rh.ChangedByEmployee)
                    .WithMany()
                    .HasForeignKey(rh => rh.ChangedByEmployeeId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.Property(rh => rh.PreviousStatus)
                    .HasMaxLength(100);

                entity.Property(rh => rh.NewStatus)
                    .HasMaxLength(100);

                entity.Property(rh => rh.Description)
                    .HasMaxLength(1000);

                entity.Property(rh => rh.ChangedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasIndex(rh => rh.RouteId);
                entity.HasIndex(rh => rh.ChangedAt);
                entity.HasData(
    new RouteHistory
    {
        Id = 1,
        RouteId = 1,
        PreviousStatus = "",
        NewStatus = "Створено",
        Description = "Маршрут створено для перевезення з Києва до Львова",
        ChangedAt = new DateTime(2026, 11, 12, 9, 5, 0, DateTimeKind.Utc),
        ChangedByEmployeeId = 1
    },
    new RouteHistory
    {
        Id = 2,
        RouteId = 1,
        PreviousStatus = "Створено",
        NewStatus = "Заплановано",
        Description = "Маршрут заплановано",
        ChangedAt = new DateTime(2026, 11, 12, 9, 10, 0, DateTimeKind.Utc),
        ChangedByEmployeeId = 1
    },
    new RouteHistory
    {
        Id = 3,
        RouteId = 2,
        PreviousStatus = "",
        NewStatus = "Створено",
        Description = "Маршрут створено для перевезення з Харкова до Дніпра",
        ChangedAt = new DateTime(2026, 11, 12, 10, 5, 0, DateTimeKind.Utc),
        ChangedByEmployeeId = 2
    },
    new RouteHistory
    {
        Id = 4,
        RouteId = 2,
        PreviousStatus = "Створено",
        NewStatus = "Заплановано",
        Description = "Маршрут заплановано",
        ChangedAt = new DateTime(2026, 11, 12, 10, 10, 0, DateTimeKind.Utc),
        ChangedByEmployeeId = 2
    },
    new RouteHistory
    {
        Id = 5,
        RouteId = 3,
        PreviousStatus = "",
        NewStatus = "Створено",
        Description = "Маршрут створено для перевезення з Одеси до Миколаєва",
        ChangedAt = new DateTime(2026, 11, 12, 11, 5, 0, DateTimeKind.Utc),
        ChangedByEmployeeId = 3
    },
    new RouteHistory
    {
        Id = 6,
        RouteId = 3,
        PreviousStatus = "Створено",
        NewStatus = "Заплановано",
        Description = "Маршрут заплановано",
        ChangedAt = new DateTime(2026, 11, 12, 11, 10, 0, DateTimeKind.Utc),
        ChangedByEmployeeId = 3
    }
);
            });

            modelBuilder.Entity<RoutePoint>(entity =>
            {
                entity.HasKey(rp => rp.Id);

                entity.HasOne(rp => rp.Route)
                    .WithMany()
                    .HasForeignKey(rp => rp.RouteId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(rp => rp.PointType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(rp => rp.Address)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(rp => rp.Notes)
                    .HasMaxLength(500);

                entity.HasIndex(rp => new
                {
                    rp.RouteId,
                    rp.SequenceNumber
                }).IsUnique();

                entity.ToTable(t =>
                {
                    t.HasCheckConstraint(
                        "CK_RoutePoints_SequenceNumber",
                        "\"SequenceNumber\" > 0");

                    t.HasCheckConstraint(
                        "CK_RoutePoints_Latitude",
                        "\"Latitude\" IS NULL OR (\"Latitude\" >= -90 AND \"Latitude\" <= 90)");

                    t.HasCheckConstraint(
                        "CK_RoutePoints_Longitude",
                        "\"Longitude\" IS NULL OR (\"Longitude\" >= -180 AND \"Longitude\" <= 180)");
                });
                entity.HasData(
    new RoutePoint
    {
        Id = 1,
        RouteId = 1,
        SequenceNumber = 1,
        PointType = "Початкова",
        Address = "м. Київ, вул. Хрещатик, 10",
        Notes = "Початок маршруту"
    },
    new RoutePoint
    {
        Id = 2,
        RouteId = 1,
        SequenceNumber = 2,
        PointType = "Кінцева",
        Address = "м. Львів, вул. Городоцька, 20",
        Notes = "Кінцева точка маршруту"
    },
    new RoutePoint
    {
        Id = 3,
        RouteId = 2,
        SequenceNumber = 1,
        PointType = "Початкова",
        Address = "м. Харків, вул. Сумська, 15",
        Notes = "Початок маршруту"
    },
    new RoutePoint
    {
        Id = 4,
        RouteId = 2,
        SequenceNumber = 2,
        PointType = "Кінцева",
        Address = "м. Дніпро, просп. Дмитра Яворницького, 30",
        Notes = "Кінцева точка маршруту"
    },
    new RoutePoint
    {
        Id = 5,
        RouteId = 3,
        SequenceNumber = 1,
        PointType = "Початкова",
        Address = "м. Одеса, вул. Дерибасівська, 10",
        Notes = "Початок маршруту"
    },
    new RoutePoint
    {
        Id = 6,
        RouteId = 3,
        SequenceNumber = 2,
        PointType = "Кінцева",
        Address = "м. Миколаїв, вул. Соборна, 20",
        Notes = "Кінцева точка маршруту"
    }
);
            });

            modelBuilder.Entity<VehicleStatus>(entity =>
            {
                entity.HasKey(vs => vs.Id);

                entity.Property(vs => vs.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(vs => vs.Description)
                    .HasMaxLength(300);

                entity.Property(vs => vs.IsActive)
                    .HasDefaultValue(true);

                entity.HasIndex(vs => vs.Name)
                    .IsUnique();

                entity.HasData(
                    new VehicleStatus
                    {
                        Id = 1,
                        Name = "Вільний",
                        Description = "Транспорт доступний для призначення"
                    },
                    new VehicleStatus
                    {
                        Id = 2,
                        Name = "Призначений",
                        Description = "Транспорт призначений для виконання замовлення"
                    },
                    new VehicleStatus
                    {
                        Id = 3,
                        Name = "Очікує завантаження",
                        Description = "Транспорт прибув до місця завантаження"
                    },
                    new VehicleStatus
                    {
                        Id = 4,
                        Name = "Завантажений",
                        Description = "Завантаження транспортного засобу завершено"
                    },
                    new VehicleStatus
                    {
                        Id = 5,
                        Name = "У дорозі",
                        Description = "Транспорт виконує маршрут"
                    },
                    new VehicleStatus
                    {
                        Id = 6,
                        Name = "Розвантажується",
                        Description = "Виконується розвантаження"
                    },
                    new VehicleStatus
                    {
                        Id = 7,
                        Name = "Розвантажений",
                        Description = "Розвантаження завершено"
                    },
                    new VehicleStatus
                    {
                        Id = 8,
                        Name = "На стоянці",
                        Description = "Транспорт перебуває на стоянці"
                    },
                    new VehicleStatus
                    {
                        Id = 9,
                        Name = "Тимчасово недоступний",
                        Description = "Транспорт тимчасово не може виконувати замовлення"
                    },
                    new VehicleStatus
                    {
                        Id = 10,
                        Name = "Несправний",
                        Description = "Транспорт потребує технічного обслуговування"
                    }
                );
            });

            modelBuilder.Entity<OrderCargo>(entity =>
            {
                entity.HasKey(oc => oc.Id);

                // Связь с заказом
                entity.HasOne(oc => oc.Order)
                    .WithMany()
                    .HasForeignKey(oc => oc.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с грузом
                entity.HasOne(oc => oc.Cargo)
                    .WithMany()
                    .HasForeignKey(oc => oc.CargoId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(oc => oc.Quantity)
                    .IsRequired();

                entity.Property(oc => oc.Notes)
                    .HasMaxLength(500);

                // Количество должно быть положительным
                entity.ToTable(t =>
                {
                    t.HasCheckConstraint(
                        "CK_OrderCargo_Quantity",
                        "\"Quantity\" > 0");
                });

                // Один и тот же груз не дублируется в заказе
                entity.HasIndex(oc => new { oc.OrderId, oc.CargoId })
                    .IsUnique();
                entity.HasData(
    new OrderCargo
    {
        Id = 1,
        OrderId = 1,
        CargoId = 1,
        Quantity = 1,
        Notes = "Основний вантаж замовлення"
    },
    new OrderCargo
    {
        Id = 2,
        OrderId = 2,
        CargoId = 2,
        Quantity = 1,
        Notes = "Будівельні матеріали"
    },
    new OrderCargo
    {
        Id = 3,
        OrderId = 3,
        CargoId = 3,
        Quantity = 1,
        Notes = "Медичні препарати"
    }
);
            });


            modelBuilder.Entity<TransportIn.Models.Route>(entity =>
            {
                entity.HasKey(r => r.Id);

                // Связь с заказом
                entity.HasOne(r => r.Order)
                    .WithMany()
                    .HasForeignKey(r => r.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с транспортным средством
                entity.HasOne(r => r.Vehicle)
                    .WithMany()
                    .HasForeignKey(r => r.VehicleId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Начальная точка маршрута
                entity.Property(r => r.StartPoint)
                    .IsRequired()
                    .HasMaxLength(300);

                // Конечная точка маршрута
                entity.Property(r => r.EndPoint)
                    .IsRequired()
                    .HasMaxLength(300);

                // Статус маршрута
                entity.Property(r => r.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                // Дата создания
                entity.Property(r => r.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.ToTable(t =>
                {
                    t.HasCheckConstraint(
                        "CK_Routes_DistanceKm",
                        "\"DistanceKm\" >= 0"
                    );

                    t.HasCheckConstraint(
                        "CK_Routes_EstimatedDuration",
                        "\"EstimatedDurationMinutes\" >= 0"
                    );
                    entity.HasData(
    new TransportIn.Models.Route
    {
        Id = 1,
        OrderId = 1,
        VehicleId = 1,
        StartPoint = "м. Київ, вул. Хрещатик, 10",
        EndPoint = "м. Львів, вул. Городоцька, 20",
        DistanceKm = 540,
        EstimatedDurationMinutes = 420,
        CreatedAt = new DateTime(2026, 11, 12, 9, 0, 0, DateTimeKind.Utc),
        Status = "Заплановано"
    },
    new TransportIn.Models.Route
    {
        Id = 2,
        OrderId = 2,
        VehicleId = 2,
        StartPoint = "м. Харків, вул. Сумська, 15",
        EndPoint = "м. Дніпро, просп. Дмитра Яворницького, 30",
        DistanceKm = 220,
        EstimatedDurationMinutes = 180,
        CreatedAt = new DateTime(2026, 11, 12, 10, 0, 0, DateTimeKind.Utc),
        Status = "Заплановано"
    },
    new TransportIn.Models.Route
    {
        Id = 3,
        OrderId = 3,
        VehicleId = 3,
        StartPoint = "м. Одеса, вул. Дерибасівська, 10",
        EndPoint = "м. Миколаїв, вул. Соборна, 20",
        DistanceKm = 135,
        EstimatedDurationMinutes = 120,
        CreatedAt = new DateTime(2026, 11, 12, 11, 0, 0, DateTimeKind.Utc),
        Status = "Заплановано"
    }
);
                });

                entity.HasIndex(r => r.OrderId);
                entity.HasIndex(r => r.VehicleId);
            });

            modelBuilder.Entity<OrderStatusHistory>(entity =>
            {
                entity.HasOne(h => h.Order)
                    .WithMany()
                    .HasForeignKey(h => h.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(h => h.ChangedByEmployee)
                    .WithMany()
                    .HasForeignKey(h => h.ChangedByEmployeeId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.Property(h => h.PreviousStatus)
                    .HasMaxLength(100);

                entity.Property(h => h.NewStatus)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(h => h.Comment)
                    .HasMaxLength(500);

                entity.Property(h => h.ChangedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasIndex(h => h.OrderId);

                entity.HasIndex(h => h.ChangedAt);
                entity.HasData(
    new OrderStatusHistory
    {
        Id = 1,
        OrderId = 1,
        PreviousStatus = "",
        NewStatus = "Створено",
        ChangedAt = new DateTime(2026, 11, 10, 9, 0, 0, DateTimeKind.Utc),
        ChangedByEmployeeId = 1,
        Comment = "Замовлення створено"
    },
    new OrderStatusHistory
    {
        Id = 2,
        OrderId = 1,
        PreviousStatus = "Створено",
        NewStatus = "Підтверджено",
        ChangedAt = new DateTime(2026, 11, 11, 10, 0, 0, DateTimeKind.Utc),
        ChangedByEmployeeId = 1,
        Comment = "Замовлення підтверджено"
    },
    new OrderStatusHistory
    {
        Id = 3,
        OrderId = 2,
        PreviousStatus = "",
        NewStatus = "Створено",
        ChangedAt = new DateTime(2026, 11, 10, 11, 0, 0, DateTimeKind.Utc),
        ChangedByEmployeeId = 2,
        Comment = "Замовлення створено"
    },
    new OrderStatusHistory
    {
        Id = 4,
        OrderId = 2,
        PreviousStatus = "Створено",
        NewStatus = "Підтверджено",
        ChangedAt = new DateTime(2026, 11, 11, 12, 0, 0, DateTimeKind.Utc),
        ChangedByEmployeeId = 2,
        Comment = "Замовлення підтверджено"
    },
    new OrderStatusHistory
    {
        Id = 5,
        OrderId = 3,
        PreviousStatus = "",
        NewStatus = "Створено",
        ChangedAt = new DateTime(2026, 11, 10, 13, 0, 0, DateTimeKind.Utc),
        ChangedByEmployeeId = 3,
        Comment = "Замовлення створено"
    },
    new OrderStatusHistory
    {
        Id = 6,
        OrderId = 3,
        PreviousStatus = "Створено",
        NewStatus = "Підтверджено",
        ChangedAt = new DateTime(2026, 11, 11, 14, 0, 0, DateTimeKind.Utc),
        ChangedByEmployeeId = 3,
        Comment = "Замовлення підтверджено"
    }
);
            });

            modelBuilder.Entity<OrderAssignment>(entity =>
            {
                entity.HasOne(a => a.Order)
                    .WithMany()
                    .HasForeignKey(a => a.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(a => a.Vehicle)
                    .WithMany()
                    .HasForeignKey(a => a.VehicleId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.Driver)
                    .WithMany()
                    .HasForeignKey(a => a.DriverId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(a => a.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(a => a.Notes)
                    .HasMaxLength(500);

                entity.ToTable(t =>
                {
                    t.HasCheckConstraint(
                        "CK_OrderAssignments_PlannedPeriod",
                        "\"PlannedEnd\" > \"PlannedStart\""
                    );

                    t.HasCheckConstraint(
                        "CK_OrderAssignments_ActualPeriod",
                        "\"ActualEnd\" IS NULL OR \"ActualStart\" IS NULL OR \"ActualEnd\" > \"ActualStart\""
                    );
                    entity.HasData(
    new OrderAssignment
    {
        Id = 1,
        OrderId = 1,
        VehicleId = 1,
        DriverId = 1,
        AssignedAt = new DateTime(2026, 11, 12, 9, 0, 0, DateTimeKind.Utc),
        PlannedStart = new DateTime(2026, 11, 15, 9, 0, 0, DateTimeKind.Utc),
        PlannedEnd = new DateTime(2026, 11, 15, 15, 0, 0, DateTimeKind.Utc),
        Status = "Призначено",
        Notes = "Перевезення продуктів харчування"
    },
    new OrderAssignment
    {
        Id = 2,
        OrderId = 2,
        VehicleId = 2,
        DriverId = 2,
        AssignedAt = new DateTime(2026, 11, 12, 10, 0, 0, DateTimeKind.Utc),
        PlannedStart = new DateTime(2026, 11, 16, 8, 0, 0, DateTimeKind.Utc),
        PlannedEnd = new DateTime(2026, 11, 16, 14, 0, 0, DateTimeKind.Utc),
        Status = "Призначено",
        Notes = "Перевезення будівельних матеріалів"
    },
    new OrderAssignment
    {
        Id = 3,
        OrderId = 3,
        VehicleId = 3,
        DriverId = 3,
        AssignedAt = new DateTime(2026, 11, 12, 11, 0, 0, DateTimeKind.Utc),
        PlannedStart = new DateTime(2026, 11, 17, 9, 0, 0, DateTimeKind.Utc),
        PlannedEnd = new DateTime(2026, 11, 17, 13, 0, 0, DateTimeKind.Utc),
        Status = "Призначено",
        Notes = "Перевезення медичних препаратів"
    }
);
                });

                entity.HasIndex(a => new
                {
                    a.VehicleId,
                    a.PlannedStart,
                    a.PlannedEnd
                });

                entity.HasIndex(a => new
                {
                    a.DriverId,
                    a.PlannedStart,
                    a.PlannedEnd
                });
            });


            modelBuilder.Entity<OrderPoint>(entity =>
            {
                entity.HasOne(p => p.Order)
                    .WithMany()
                    .HasForeignKey(p => p.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(p => p.PointType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(p => p.Address)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(p => p.ContactName)
                    .HasMaxLength(150);

                entity.Property(p => p.ContactPhone)
                    .HasMaxLength(30);

                entity.Property(p => p.Status)
                    .HasMaxLength(50);

                entity.Property(p => p.Notes)
                    .HasMaxLength(500);

                entity.HasIndex(p => new { p.OrderId, p.SequenceNumber })
                    .IsUnique();

                entity.HasData(
    new OrderPoint
    {
        Id = 1,
        OrderId = 1,
        PointType = "Завантаження",
        Address = "м. Київ, вул. Хрещатик, 10",
        Latitude = 50.4501,
        Longitude = 30.5234,
        ContactName = "Олександр Петренко",
        ContactPhone = "+380501112233",
        SequenceNumber = 1,
        PlannedArrival = new DateTime(2026, 11, 15, 9, 0, 0, DateTimeKind.Utc),
        Status = "Очікується",
        Notes = "Місце завантаження вантажу"
    },
    new OrderPoint
    {
        Id = 2,
        OrderId = 1,
        PointType = "Розвантаження",
        Address = "м. Львів, вул. Городоцька, 20",
        Latitude = 49.8397,
        Longitude = 24.0297,
        ContactName = "Іван Коваль",
        ContactPhone = "+380671234567",
        SequenceNumber = 2,
        PlannedArrival = new DateTime(2026, 11, 15, 15, 0, 0, DateTimeKind.Utc),
        Status = "Очікується",
        Notes = "Місце отримання вантажу"
    },
    new OrderPoint
    {
        Id = 3,
        OrderId = 2,
        PointType = "Завантаження",
        Address = "м. Харків, вул. Сумська, 15",
        Latitude = 49.9935,
        Longitude = 36.2304,
        ContactName = "Андрій Коваленко",
        ContactPhone = "+380931234567",
        SequenceNumber = 1,
        PlannedArrival = new DateTime(2026, 11, 16, 8, 0, 0, DateTimeKind.Utc),
        Status = "Очікується",
        Notes = "Місце завантаження будівельних матеріалів"
    },
    new OrderPoint
    {
        Id = 4,
        OrderId = 2,
        PointType = "Розвантаження",
        Address = "м. Дніпро, просп. Дмитра Яворницького, 30",
        Latitude = 48.4647,
        Longitude = 35.0462,
        ContactName = "Петро Мельник",
        ContactPhone = "+380991234567",
        SequenceNumber = 2,
        PlannedArrival = new DateTime(2026, 11, 16, 14, 0, 0, DateTimeKind.Utc),
        Status = "Очікується",
        Notes = "Місце отримання будівельних матеріалів"
    },
    new OrderPoint
    {
        Id = 5,
        OrderId = 3,
        PointType = "Завантаження",
        Address = "м. Одеса, вул. Дерибасівська, 10",
        Latitude = 46.4825,
        Longitude = 30.7233,
        ContactName = "Ірина Мельник",
        ContactPhone = "+380931234568",
        SequenceNumber = 1,
        PlannedArrival = new DateTime(2026, 11, 17, 9, 0, 0, DateTimeKind.Utc),
        Status = "Очікується",
        Notes = "Місце завантаження медичних препаратів"
    },
    new OrderPoint
    {
        Id = 6,
        OrderId = 3,
        PointType = "Розвантаження",
        Address = "м. Миколаїв, вул. Соборна, 20",
        Latitude = 46.9750,
        Longitude = 31.9946,
        ContactName = "Марія Шевченко",
        ContactPhone = "+380991234568",
        SequenceNumber = 2,
        PlannedArrival = new DateTime(2026, 11, 17, 13, 0, 0, DateTimeKind.Utc),
        Status = "Очікується",
        Notes = "Місце отримання медичних препаратів"
    }
);
                entity.ToTable(t =>
                {
                    t.HasCheckConstraint(
                        "CK_OrderPoints_Latitude",
                        "\"Latitude\" IS NULL OR (\"Latitude\" >= -90 AND \"Latitude\" <= 90)"
                    );

                    t.HasCheckConstraint(
                        "CK_OrderPoints_Longitude",
                        "\"Longitude\" IS NULL OR (\"Longitude\" >= -180 AND \"Longitude\" <= 180)"
                    );

                    t.HasCheckConstraint(
                        "CK_OrderPoints_SequenceNumber",
                        "\"SequenceNumber\" > 0"
                    );
                });

            });

            modelBuilder.Entity<OrderStatus>().HasData(
    new OrderStatus
    {
        Id = 1,
        Name = "Створено",
        Description = "Замовлення щойно створено",
        IsActive = true
    },
    new OrderStatus
    {
        Id = 2,
        Name = "Очікує транспорту",
        Description = "Очікується призначення транспорту",
        IsActive = true
    },
    new OrderStatus
    {
        Id = 3,
        Name = "Очікує виконання",
        Description = "Транспорт призначено, очікується початок виконання",
        IsActive = true
    },
    new OrderStatus
    {
        Id = 4,
        Name = "У процесі виконання",
        Description = "Замовлення виконується",
        IsActive = true
    },
    new OrderStatus
    {
        Id = 5,
        Name = "Призупинено",
        Description = "Виконання замовлення тимчасово призупинено",
        IsActive = true
    },
    new OrderStatus
    {
        Id = 6,
        Name = "Завершено",
        Description = "Замовлення успішно виконано",
        IsActive = true
    },
    new OrderStatus
    {
        Id = 7,
        Name = "Скасовано",
        Description = "Замовлення скасовано",
        IsActive = true
    }
);
            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.Property(s => s.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasIndex(s => s.Name)
                    .IsUnique();

                entity.Property(s => s.Description)
                    .HasMaxLength(300);

                entity.Property(s => s.IsActive)
                    .HasDefaultValue(true);
            });
            modelBuilder.Entity<ContactPerson>().HasData(
    new ContactPerson
    {
        Id = 1,
        CustomerId = 1,
        FullName = "Іван Петренко",
        Position = "Менеджер з логістики",
        Phone = "+380501112233",
        Email = "ivan@example.com",
        IsPrimary = true,
        IsActive = true
    },
    new ContactPerson
    {
        Id = 2,
        CustomerId = 1,
        FullName = "Олена Коваль",
        Position = "Бухгалтер",
        Phone = "+380671234567",
        Email = "olena@example.com",
        IsPrimary = false,
        IsActive = true
    },
    new ContactPerson
    {
        Id = 3,
        CustomerId = 2,
        FullName = "Андрій Мельник",
        Position = "Директор",
        Phone = "+380931234567",
        Email = "andrii@example.com",
        IsPrimary = true,
        IsActive = true
    },
    new ContactPerson
    {
        Id = 4,
        CustomerId = 3,
        FullName = "Марія Шевченко",
        Position = "Менеджер",
        Phone = "+380991234567",
        Email = "maria@example.com",
        IsPrimary = true,
        IsActive = true
    }
);
            modelBuilder.Entity<ContactPerson>(entity =>
            {
                entity.HasOne(cp => cp.Customer)
                    .WithMany()
                    .HasForeignKey(cp => cp.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(cp => cp.FullName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(cp => cp.Position)
                    .HasMaxLength(100);

                entity.Property(cp => cp.Phone)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(cp => cp.Email)
                    .HasMaxLength(150);

                entity.Property(cp => cp.IsActive)
                    .HasDefaultValue(true);
            });
            modelBuilder.Entity<Customer>().HasData(
    new Customer
    {
        Id = 1,
        CompanyName = "ТОВ Логістик Плюс",
        Edrpou = "12345678",
        Address = "м. Київ, вул. Хрещатик, 10",
        Phone = "+380501112233",
        Email = "logistic@example.com",
        Notes = "Постійний клієнт",
        IsActive = true
    },
    new Customer
    {
        Id = 2,
        CompanyName = "ТОВ Агро Транс",
        Edrpou = "23456789",
        Address = "м. Львів, вул. Зелена, 25",
        Phone = "+380671234567",
        Email = "agro@example.com",
        Notes = "Перевезення сільськогосподарської продукції",
        IsActive = true
    },
    new Customer
    {
        Id = 3,
        CompanyName = "ТОВ Будсервіс",
        Edrpou = "34567890",
        Address = "м. Одеса, вул. Промислова, 15",
        Phone = "+380931234567",
        Email = "build@example.com",
        Notes = "Перевезення будівельних матеріалів",
        IsActive = true
    }
);
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(c => c.CompanyName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(c => c.Edrpou)
                    .HasMaxLength(20);

                entity.Property(c => c.Address)
                    .HasMaxLength(300);

                entity.Property(c => c.Phone)
                    .HasMaxLength(30);

                entity.Property(c => c.Email)
                    .HasMaxLength(150);

                entity.Property(c => c.Notes)
                    .HasMaxLength(1000);

                entity.Property(c => c.IsActive)
                    .HasDefaultValue(true);
            });
            modelBuilder.Entity<VehicleEquipment>().HasData(
    new VehicleEquipment
    {
        Id = 1,
        VehicleId = 1,
        Name = "GPS-трекер",
        Description = "Система отслеживания местоположения автомобиля",
        Quantity = 1,
        IsWorking = true
    },
    new VehicleEquipment
    {
        Id = 2,
        VehicleId = 1,
        Name = "Ремни крепления груза",
        Description = "Ремни для фиксации перевозимого груза",
        Quantity = 10,
        IsWorking = true
    },
    new VehicleEquipment
    {
        Id = 3,
        VehicleId = 2,
        Name = "Холодильная установка",
        Description = "Поддержание заданной температуры при перевозке",
        Quantity = 1,
        IsWorking = true
    },
    new VehicleEquipment
    {
        Id = 4,
        VehicleId = 3,
        Name = "Гидроборт",
        Description = "Оборудование для погрузки и разгрузки",
        Quantity = 1,
        IsWorking = true
    },
    new VehicleEquipment
    {
        Id = 5,
        VehicleId = 4,
        Name = "Огнетушитель",
        Description = "Средство пожарной безопасности",
        Quantity = 2,
        IsWorking = true
    }
);
            modelBuilder.Entity<VehicleEquipment>()
    .HasOne(e => e.Vehicle)
    .WithMany()
    .HasForeignKey(e => e.VehicleId)
    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<VehicleEquipment>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(150);

            modelBuilder.Entity<VehicleEquipment>()
                .Property(e => e.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<VehicleEquipment>()
                .ToTable(t => t.HasCheckConstraint(
                    "CK_VehicleEquipments_Quantity",
                    "\"Quantity\" > 0"
                ));
            modelBuilder.Entity<VehicleDocument>().HasData(
    new VehicleDocument
    {
        Id = 1,
        VehicleId = 1,
        DocumentType = VehicleDocumentType.RegistrationCertificate,
        DocumentNumber = "REG-001",
        IssueDate = new DateOnly(2024, 3, 15),
        ExpiryDate = new DateOnly(2034, 3, 15),
        IssuedBy = "Сервісний центр МВС",
        Details = "Свідоцтво про реєстрацію автомобіля"
    },
    new VehicleDocument
    {
        Id = 2,
        VehicleId = 1,
        DocumentType = VehicleDocumentType.Insurance,
        DocumentNumber = "INS-001",
        IssueDate = new DateOnly(2026, 1, 10),
        ExpiryDate = new DateOnly(2027, 1, 10),
        IssuedBy = "Страхова компанія",
        Details = "Поліс обов'язкового страхування"
    },
    new VehicleDocument
    {
        Id = 3,
        VehicleId = 2,
        DocumentType = VehicleDocumentType.TechnicalInspection,
        DocumentNumber = "TECH-002",
        IssueDate = new DateOnly(2026, 2, 1),
        ExpiryDate = new DateOnly(2027, 2, 1),
        IssuedBy = "Сервісний центр",
        Details = "Протокол технічного огляду"
    },
    new VehicleDocument
    {
        Id = 4,
        VehicleId = 3,
        DocumentType = VehicleDocumentType.CargoLicense,
        DocumentNumber = "LIC-003",
        IssueDate = new DateOnly(2025, 6, 20),
        ExpiryDate = new DateOnly(2027, 6, 20),
        IssuedBy = "Уповноважений орган",
        Details = "Дозвіл на перевезення вантажів"
    },
    new VehicleDocument
    {
        Id = 5,
        VehicleId = 4,
        DocumentType = VehicleDocumentType.TechnicalPassport,
        DocumentNumber = "TP-004",
        IssueDate = new DateOnly(2023, 9, 12),
        IssuedBy = "Сервісний центр МВС",
        Details = "Технічний паспорт транспортного засобу"
    }
);
            modelBuilder.Entity<VehicleDocument>()
    .HasOne(d => d.Vehicle)
    .WithMany()
    .HasForeignKey(d => d.VehicleId)
    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<VehicleDocument>()
                .Property(d => d.DocumentNumber)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<VehicleDocument>()
                .Property(d => d.IssuedBy)
                .HasMaxLength(200);
            modelBuilder.Entity<EmployeeDocument>().HasData(
    new EmployeeDocument
    {
        Id = 1,
        EmployeeId = 1,
        DocumentType = EmployeeDocumentType.Passport,
        DocumentNumber = "МР123456",
        IssueDate = DateTime.SpecifyKind(new DateTime(2020, 5, 10),DateTimeKind.Utc),
        IssuedBy = "МВС України",
        Details = "Паспорт співробітника"
    },
    new EmployeeDocument
    {
        Id = 2,
        EmployeeId = 1,
        DocumentType = EmployeeDocumentType.DriverLicense,
        DocumentNumber = "АА123456",
        IssueDate = DateTime.SpecifyKind(new DateTime(2020, 5, 10), DateTimeKind.Utc),
        ExpiryDate= DateTime.SpecifyKind(new DateTime(2020, 5, 10), DateTimeKind.Utc),
        IssuedBy = "Сервісний центр МВС",
        Details = "Категорії C, CE"
    },
    new EmployeeDocument
    {
        Id = 3,
        EmployeeId = 2,
        DocumentType = EmployeeDocumentType.Education,
        DocumentNumber = "EDU-2021-002",
        IssueDate = new DateTime(2021, 6, 25, 0, 0, 0, DateTimeKind.Utc),
        IssuedBy = "Навчальний заклад",
        Details = "Документ про освіту"
    },
    new EmployeeDocument
    {
        Id = 4,
        EmployeeId = 3,
        DocumentType = EmployeeDocumentType.MedicalCertificate,
        DocumentNumber = "MED-2026-003",
        IssueDate = new DateTime(2026, 1, 10, 0, 0, 0, DateTimeKind.Utc),
        ExpiryDate = new DateTime(2027, 1, 10, 0, 0, 0, DateTimeKind.Utc),
        IssuedBy = "Медичний заклад",
        Details = "Медична довідка"
    }
);
            modelBuilder.Entity<EmployeeDocument>()
    .HasOne(d => d.Employee)
    .WithMany()
    .HasForeignKey(d => d.EmployeeId)
    .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);

            // РОЛІ
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Адміністратор",
                    Description = "Управління системою та працівниками"
                },
                new Role
                {
                    Id = 2,
                    Name = "Менеджер",
                    Description = "Створення та управління замовленнями"
                },
                new Role
                {
                    Id = 3,
                    Name = "Водій",
                    Description = "Виконання призначених перевезень"
                }
            );

            // ЗВ'ЯЗОК СПІВРОБІТНИКІВ І РОЛЕЙ
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.RoleInfo)
                .WithMany()
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            // СПІВРОБІТНИКИ
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    FullName = "Іван Водійченко",
                    RoleId = 3,
                    Role = "Водій",
                    Phone = "0501112233",
                    LicenseCategory = "C, CE",
                    MedicalCertExpiry = "12.10.2026",
                    IsActive = true
                },
                new Employee
                {
                    Id = 2,
                    FullName = "Петро Дальнобій",
                    RoleId = 3,
                    Role = "Водій",
                    Phone = "0672223344",
                    LicenseCategory = "C1, C",
                    MedicalCertExpiry = "05.05.2027",
                    IsActive = true
                },
                new Employee
                {
                    Id = 3,
                    FullName = "Олена Менеджер",
                    RoleId = 2,
                    Role = "Менеджер",
                    Phone = "0933334455",
                    LicenseCategory = "-",
                    MedicalCertExpiry = "-",
                    IsActive = true
                }
            );

            // ДОКУМЕНТИ СПІВРОБІТНИКІВ
            modelBuilder.Entity<EmployeeDocument>()
                .HasOne(d => d.Employee)
                .WithMany()
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmployeeDocument>()
                .Property(d => d.DocumentNumber)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<EmployeeDocument>()
                .Property(d => d.IssuedBy)
                .HasMaxLength(200);

            // ГРАФІКИ ВОДІЇВ
            modelBuilder.Entity<DriverSchedule>()
                .HasOne(s => s.Employee)
                .WithMany()
                .HasForeignKey(s => s.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DriverSchedule>()
                .ToTable(t => t.HasCheckConstraint(
                    "CK_DriverSchedules_Time",
                    "\"EndTime\" > \"StartTime\""
                ));

            // ПОЧАТКОВІ ГРАФІКИ ВОДІЇВ
            modelBuilder.Entity<DriverSchedule>().HasData(
                new DriverSchedule
                {
                    Id = 1,
                    EmployeeId = 1,
                    WorkDate = new DateOnly(2026, 11, 10),
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(17, 0, 0),
                    ShiftType = "Денна",
                    IsAvailable = true,
                    Notes = "Основна денна зміна"
                },
                new DriverSchedule
                {
                    Id = 2,
                    EmployeeId = 2,
                    WorkDate = new DateOnly(2026, 11, 10),
                    StartTime = new TimeSpan(16, 0, 0),
                    EndTime = new TimeSpan(23, 0, 0),
                    ShiftType = "Вечірня",
                    IsAvailable = true,
                    Notes = "Вечірня зміна"
                },
                new DriverSchedule
                {
                    Id = 3,
                    EmployeeId = 1,
                    WorkDate = new DateOnly(2026, 11, 11),
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(17, 0, 0),
                    ShiftType = "Денна",
                    IsAvailable = false,
                    Notes = "Вихідний"
                },
                new DriverSchedule
                {
                    Id = 4,
                    EmployeeId = 2,
                    WorkDate = new DateOnly(2026, 11, 11),
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(16, 0, 0),
                    ShiftType = "Денна",
                    IsAvailable = true,
                    Notes = "Робоча зміна"
                },
                new DriverSchedule
                {
                    Id = 5,
                    EmployeeId = 1,
                    WorkDate = new DateOnly(2026, 11, 12),
                    StartTime = new TimeSpan(9, 0, 0),
                    EndTime = new TimeSpan(18, 0, 0),
                    ShiftType = "Денна",
                    IsAvailable = true,
                    Notes = "Робоча зміна"
                },
                new DriverSchedule
                {
                    Id = 6,
                    EmployeeId = 2,
                    WorkDate = new DateOnly(2026, 11, 12),
                    StartTime = new TimeSpan(16, 0, 0),
                    EndTime = new TimeSpan(23, 0, 0),
                    ShiftType = "Вечірня",
                    IsAvailable = true,
                    Notes = "Вечірня зміна"
                }
            );

            // ПЕРЕТВОРЕННЯ СПИСКІВ АДРЕС У JSON
            var listConverter = new ValueConverter<List<string>, string>(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions?)null)
                     ?? new List<string>()
            );

            var listComparer = new ValueComparer<List<string>>(
                (a, b) => a != null && b != null
                    ? a.SequenceEqual(b)
                    : a == b,
                v => v == null
                    ? 0
                    : v.Aggregate(0, (hash, item) =>
                        HashCode.Combine(hash, item == null ? 0 : StringComparer.Ordinal.GetHashCode(item))),
                v => v == null ? new List<string>() : v.ToList()
            );

            modelBuilder.Entity<Order>()
                .Property(o => o.LoadingPoints)
                .HasConversion(listConverter)
                .Metadata.SetValueComparer(listComparer);

            modelBuilder.Entity<Order>()
                .Property(o => o.DeliveryPoints)
                .HasConversion(listConverter)
                .Metadata.SetValueComparer(listComparer);

            // ПОЧАТКОВІ МАРШРУТИ
            // ПОЧАТКОВІ ВАНТАЖІ
modelBuilder.Entity<Cargo>().HasData(
    new Cargo
    {
        Id = 1,
        Title = "Продукти харчування",
        WeightKg = 12000,
        TransportConditions = "Рефрижератор, +4°C",
        SenderName = "Олександр Петренко",
        SenderPhone = "+380501112233",
        RecipientName = "Іван Коваль",
        RecipientPhone = "+380671234567"
    },
    new Cargo
    {
        Id = 2,
        Title = "Будівельні матеріали",
        WeightKg = 18000,
        TransportConditions = "Звичайні умови перевезення",
        SenderName = "Андрій Коваленко",
        SenderPhone = "+380931234567",
        RecipientName = "Петро Мельник",
        RecipientPhone = "+380991234567"
    },
    new Cargo
    {
        Id = 3,
        Title = "Медичні препарати",
        WeightKg = 5000,
        TransportConditions = "Рефрижератор, +2°C до +8°C",
        SenderName = "Ірина Мельник",
        SenderPhone = "+380931234568",
        RecipientName = "Марія Шевченко",
        RecipientPhone = "+380991234568"
    }
);
            modelBuilder.Entity<TransportRoute>().HasData(
                new TransportRoute
                {
                    Id = 1,
                    DriverId = 1,
                    CargoId = 1,
                    Status = "У дорозі",
                    Latitude = 50.4501,
                    Longitude = 30.5234
                },
                new TransportRoute
                {
                    Id = 2,
                    DriverId = 2,
                    CargoId = 2,
                    Status = "На складі",
                    Latitude = 49.8397,
                    Longitude = 24.0297
                },
                new TransportRoute
                {
                    Id = 3,
                    DriverId = 1,
                    CargoId = 3,
                    Status = "Очікує відправлення",
                    Latitude = 46.4825,
                    Longitude = 30.7233
                }
            );

            // ПОЧАТКОВІ ЗАМОВЛЕННЯ
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    CustomerCompany = "ТОВ АгроСвіт",
                    CustomerName = "Олександр Петренко",
                    CustomerPhone = "+380501112233",
                    CustomerEmail = "agrosvit@gmail.com",
                    CargoName = "Продукти харчування",
                    WeightTons = 12,
                    VolumeM3 = 45,
                    RequiresRefrigerator = true,
                    LoadingPoints = new List<string> { "Київ" },
                    DeliveryPoints = new List<string> { "Львів", "Івано-Франківськ" },
                    AssignedVehiclePlate = "BC5678DE",
                    Status = "В обробці"
                },
                new Order
                {
                    Id = 2,
                    CustomerCompany = "БудТрейд",
                    CustomerName = "Андрій Коваленко",
                    CustomerPhone = "+380671234567",
                    CustomerEmail = "budtrade@gmail.com",
                    CargoName = "Будівельні матеріали",
                    WeightTons = 18,
                    VolumeM3 = 65,
                    RequiresRefrigerator = false,
                    LoadingPoints = new List<string> { "Одеса" },
                    DeliveryPoints = new List<string> { "Київ" },
                    AssignedVehiclePlate = "AA1234BC",
                    Status = "Підтверджено"
                },
                new Order
                {
                    Id = 3,
                    CustomerCompany = "МедТех",
                    CustomerName = "Ірина Мельник",
                    CustomerPhone = "+380931234567",
                    CustomerEmail = "medtech@gmail.com",
                    CargoName = "Медичні препарати",
                    WeightTons = 5,
                    VolumeM3 = 20,
                    RequiresRefrigerator = true,
                    LoadingPoints = new List<string> { "Харків" },
                    DeliveryPoints = new List<string> { "Дніпро", "Запоріжжя" },
                    AssignedVehiclePlate = "BC5678DE",
                    Status = "Нове"
                }
            );

            // ПОЧАТКОВІ ПРАВИЛА ЕКСПЕРТНОЇ СИСТЕМИ
            modelBuilder.Entity<ExpertRule>().HasData(
                new ExpertRule
                {
                    Id = 1,
                    ThreatType = "Поломка транспорту",
                    Condition = "Автомобіль несправний",
                    ActionRecommendation = "Направити автомобіль на технічний огляд та підібрати заміну",
                    Priority = "Високий"
                },
                new ExpertRule
                {
                    Id = 2,
                    ThreatType = "Затримка доставки",
                    Condition = "Перевищено запланований час доставки",
                    ActionRecommendation = "Перевірити маршрут та повідомити менеджера",
                    Priority = "Середній"
                },
                new ExpertRule
                {
                    Id = 3,
                    ThreatType = "Аварійна ситуація",
                    Condition = "Зафіксовано дорожньо-транспортну пригоду",
                    ActionRecommendation = "Повідомити відповідального менеджера та організувати допомогу",
                    Priority = "Критичний"
                },
                new ExpertRule
                {
                    Id = 4,
                    ThreatType = "Порушення температурного режиму",
                    Condition = "Температура вантажу виходить за допустимі межі",
                    ActionRecommendation = "Перевірити холодильне обладнання та стан вантажу",
                    Priority = "Високий"
                },
                new ExpertRule
                {
                    Id = 5,
                    ThreatType = "Втрата зв'язку",
                    Condition = "Відсутній зв'язок із водієм",
                    ActionRecommendation = "Перевірити останнє місцезнаходження та спробувати альтернативний зв'язок",
                    Priority = "Високий"
                },
                new ExpertRule
                {
                    Id = 6,
                    ThreatType = "Перевантаження автомобіля",
                    Condition = "Вага вантажу перевищує вантажопідйомність автомобіля",
                    ActionRecommendation = "Перерозподілити вантаж або підібрати інший транспорт",
                    Priority = "Високий"
                }
            );

            // ПОЧАТКОВІ УМОВИ ЕКСПЕРТНОЇ СИСТЕМИ
            modelBuilder.Entity<RuleCondition>().HasData(
                // Правило 1: Поломка транспорту
                new RuleCondition
                {
                    Id = 1,
                    ExpertRuleId = 1,
                    Parameter = "VehicleStatus",
                    Operator = "==",
                    ExpectedValue = "Несправний",
                    LogicalOperator = "AND",
                    SequenceNumber = 1,
                    Description = "Перевірка технічного стану автомобіля"
                },

                // Правило 2: Затримка доставки
                new RuleCondition
                {
                    Id = 2,
                    ExpertRuleId = 2,
                    Parameter = "DeliveryStatus",
                    Operator = "==",
                    ExpectedValue = "Затримка",
                    LogicalOperator = "AND",
                    SequenceNumber = 1,
                    Description = "Перевірка статусу доставки"
                },

                // Правило 3: Аварійна ситуація
                new RuleCondition
                {
                    Id = 3,
                    ExpertRuleId = 3,
                    Parameter = "RoadEvent",
                    Operator = "==",
                    ExpectedValue = "ДТП",
                    LogicalOperator = "AND",
                    SequenceNumber = 1,
                    Description = "Перевірка наявності дорожньо-транспортної пригоди"
                },

                // Правило 4: Порушення температурного режиму
                new RuleCondition
                {
                    Id = 4,
                    ExpertRuleId = 4,
                    Parameter = "CargoTemperature",
                    Operator = "OUT_OF_RANGE",
                    ExpectedValue = "AllowedRange",
                    LogicalOperator = "AND",
                    SequenceNumber = 1,
                    Description = "Перевірка температури вантажу"
                },

                // Правило 5: Втрата зв'язку
                new RuleCondition
                {
                    Id = 5,
                    ExpertRuleId = 5,
                    Parameter = "LastLocationUpdate",
                    Operator = ">",
                    ExpectedValue = "30",
                    LogicalOperator = "AND",
                    SequenceNumber = 1,
                    Description = "Перевірка часу останнього оновлення місцезнаходження"
                },

                // Правило 6: Перевантаження автомобіля
                new RuleCondition
                {
                    Id = 6,
                    ExpertRuleId = 6,
                    Parameter = "CargoWeight",
                    Operator = ">",
                    ExpectedValue = "VehicleCapacity",
                    LogicalOperator = "AND",
                    SequenceNumber = 1,
                    Description = "Перевірка ваги вантажу відносно вантажопідйомності автомобіля"
                }
            );
            // КОРИСТУВАЧІ
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Password = "123",
                    Role = UserRole.Admin,
                    FullName = "Головний Адмін",
                    Phone = "+380000000001"
                },
                new User
                {
                    Id = 2,
                    Username = "manager",
                    Password = "123",
                    Role = UserRole.Manager,
                    FullName = "Менеджер Складу",
                    Phone = "+380000000002"
                },
                new User
                {
                    Id = 3,
                    Username = "driver",
                    Password = "123",
                    Role = UserRole.Driver,
                    FullName = "Водій Рефрижератора",
                    Phone = "+380000000003"
                }
            );

            // ПОЧАТКОВІ АВТОМОБІЛІ
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle
                {
                    Id = 1,
                    BrandModel = "Mercedes-Benz Actros",
                    LicensePlate = "AA1234BC",
                    VinCode = "WDB96340310123456",
                    BodyType = "Тент",
                    CapacityTons = 20,
                    VolumeM3 = 86,
                    HasRefrigerator = false,
                    AssignedDriver = "Іван Водійченко",
                    Status = "Справний",
                    Lat = 50.4501,
                    Lng = 30.5234
                },
                new Vehicle
                {
                    Id = 2,
                    BrandModel = "Volvo FH",
                    LicensePlate = "BC5678DE",
                    VinCode = "YV2RT40A6KB123456",
                    BodyType = "Рефрижератор",
                    CapacityTons = 22,
                    VolumeM3 = 90,
                    HasRefrigerator = true,
                    AssignedDriver = "Петро Дальнобій",
                    Status = "Справний",
                    Lat = 49.8397,
                    Lng = 24.0297
                },
                new Vehicle
                {
                    Id = 3,
                    BrandModel = "MAN TGX",
                    LicensePlate = "KA9012MH",
                    VinCode = "WMA06XZZ9KP123456",
                    BodyType = "Тент",
                    CapacityTons = 18,
                    VolumeM3 = 82,
                    HasRefrigerator = false,
                    AssignedDriver = "Не призначено",
                    Status = "На обслуговуванні",
                    Lat = 46.4825,
                    Lng = 30.7233
                },
                new Vehicle
                {
                    Id = 4,
                    BrandModel = "DAF XF 480",
                    LicensePlate = "KA4567OP",
                    VinCode = "XLRTE47MS0E123456",
                    BodyType = "Тент",
                    CapacityTons = 20,
                    VolumeM3 = 90,
                    HasRefrigerator = false,
                    AssignedDriver = "Не призначено",
                    Status = "Справний",
                    Lat = 50.4501,
                    Lng = 30.5234
                },
                new Vehicle
                {
                    Id = 5,
                    BrandModel = "Scania R450",
                    LicensePlate = "BC7890KT",
                    VinCode = "YS2R4X20001234567",
                    BodyType = "Рефрижератор",
                    CapacityTons = 21,
                    VolumeM3 = 88,
                    HasRefrigerator = true,
                    AssignedDriver = "Не призначено",
                    Status = "Справний",
                    Lat = 49.8397,
                    Lng = 24.0297
                },
                new Vehicle
                {
                    Id = 6,
                    BrandModel = "Renault T480",
                    LicensePlate = "AX2345MI",
                    VinCode = "VF611A168KD123456",
                    BodyType = "Тент",
                    CapacityTons = 18,
                    VolumeM3 = 85,
                    HasRefrigerator = false,
                    AssignedDriver = "Не призначено",
                    Status = "Справний",
                    Lat = 46.4825,
                    Lng = 30.7233
                },
                new Vehicle
                {
                    Id = 7,
                    BrandModel = "MAN TGX 18.440",
                    LicensePlate = "KH5678BC",
                    VinCode = "WMA06XZZ9KP654321",
                    BodyType = "Рефрижератор",
                    CapacityTons = 18,
                    VolumeM3 = 80,
                    HasRefrigerator = true,
                    AssignedDriver = "Не призначено",
                    Status = "На обслуговуванні",
                    Lat = 49.9935,
                    Lng = 36.2304
                },
                new Vehicle
                {
                    Id = 8,
                    BrandModel = "Iveco S-Way",
                    LicensePlate = "OD9012CA",
                    VinCode = "WJMM62AU00C123456",
                    BodyType = "Тент",
                    CapacityTons = 16,
                    VolumeM3 = 75,
                    HasRefrigerator = false,
                    AssignedDriver = "Не призначено",
                    Status = "Справний",
                    Lat = 48.4647,
                    Lng = 35.0462
                }
            );
        }
    }
}
