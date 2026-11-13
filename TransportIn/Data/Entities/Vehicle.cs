using System;
using System.Collections.Generic;

namespace TransportIn.Data.Entities;

public partial class Vehicle
{
    public int Id { get; set; }

    public string BrandModel { get; set; } = null!;

    public string LicensePlate { get; set; } = null!;

    public string VinCode { get; set; } = null!;

    public string BodyType { get; set; } = null!;

    public double CapacityTons { get; set; }

    public double VolumeM3 { get; set; }

    public bool HasRefrigerator { get; set; }

    public string AssignedDriver { get; set; } = null!;

    public string Status { get; set; } = null!;

    public double Lat { get; set; }

    public double Lng { get; set; }

    public virtual ICollection<OrderAssignment> OrderAssignments { get; set; } = new List<OrderAssignment>();

    public virtual ICollection<Route> Routes { get; set; } = new List<Route>();

    public virtual ICollection<VehicleDocument> VehicleDocuments { get; set; } = new List<VehicleDocument>();

    public virtual ICollection<VehicleEquipment> VehicleEquipments { get; set; } = new List<VehicleEquipment>();

    public virtual ICollection<VehicleLocation> VehicleLocations { get; set; } = new List<VehicleLocation>();
}
