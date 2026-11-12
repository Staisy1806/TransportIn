
using TransportIn.Models;

namespace TransportIn.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order?> GetOrderByIdAsync(int id);
        Task AddOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(int id);

        List<Vehicle> GetSuitableVehicles(
            Order order,
            List<Vehicle> allVehicles);

        Task AssignVehicleAsync(int orderId, string licensePlate);
    }
}
