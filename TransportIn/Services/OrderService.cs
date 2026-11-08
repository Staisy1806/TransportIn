using TransportIn.Models;

namespace TransportIn.Services
{
    public class OrderService
    {
        private List<Order> orders = new();
        public event Action? OnChange;

        public List<Order> GetAllOrders() => orders;

        public void AddOrder(Order order)
        {
            order.Id = orders.Count > 0 ? orders.Max(o => o.Id) + 1 : 1;
            orders.Add(order);
            NotifyStateChanged();
        }

        // Логіка автоматичного підбору транспорту згідно з ТЗ
        public List<Vehicle> GetSuitableVehicles(Order order, List<Vehicle> allVehicles)
        {
            return allVehicles.Where(v =>
                v.CapacityTons >= order.WeightTons && // перевірка вантажопідйомності
                v.VolumeM3 >= order.VolumeM3 &&       // перевірка об'єму кузова
                (!order.RequiresRefrigerator || v.HasRefrigerator) // перевірка холодильної установки
            ).ToList();
        }

        public void AssignVehicle(int orderId, string licensePlate)
        {
            var order = orders.FirstOrDefault(o => o.Id == orderId);
            if (order != null)
            {
                order.AssignedVehiclePlate = licensePlate;
                order.Status = "Призначено транспорт";
                NotifyStateChanged();
            }
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}