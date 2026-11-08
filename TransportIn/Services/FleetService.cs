using TransportIn.Models;

namespace TransportIn.Services
{
    public class FleetService
    {
        private List<Vehicle> vehicles = new()
        {
            new Vehicle { Id = 1, BrandModel = "Mercedes-Benz Sprinter", LicensePlate = "AA 1234 ВР", VinCode = "1YVBR12E34567890X", BodyType = "Цільнометалічний фургон", CapacityTons = 2.5, VolumeM3 = 12, HasRefrigerator = false, AssignedDriver = "Водій: Іван", Lat = 50.4551, Lng = 30.5334 },
            new Vehicle { Id = 2, BrandModel = "MAN TGX", LicensePlate = "AI 5678 СЕ", VinCode = "WMAXXXXXXXXXXXXXX", BodyType = "Рефрижератор", CapacityTons = 20.0, VolumeM3 = 86, HasRefrigerator = true, AssignedDriver = "Водій: Петро", Lat = 50.4401, Lng = 30.5134 }
        };

        public event Action? OnChange;

        public List<Vehicle> GetAllVehicles() => vehicles;

        public void AddVehicle(Vehicle vehicle)
        {
            vehicle.Id = vehicles.Count > 0 ? vehicles.Max(v => v.Id) + 1 : 1;
            vehicles.Add(vehicle);
            NotifyStateChanged();
        }

        public void DeleteVehicle(int id)
        {
            var vehicle = vehicles.FirstOrDefault(v => v.Id == id);
            if (vehicle != null)
            {
                vehicles.Remove(vehicle);
                NotifyStateChanged();
            }
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}