
using Microsoft.EntityFrameworkCore;
using TransportIn.Data;
using TransportIn.Models;

namespace TransportIn.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        // Отримання всіх замовлень
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .AsNoTracking()
                .OrderByDescending(o => o.Id)
                .ToListAsync();
        }

        // Отримання замовлення за ID
        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        // Додавання замовлення
        public async Task AddOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        // Редагування замовлення
        public async Task UpdateOrderAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        // Видалення замовлення
        public async Task DeleteOrderAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

        // Автоматичний підбір транспорту
        public List<Vehicle> GetSuitableVehicles(
            Order order,
            List<Vehicle> allVehicles)
        {
            return allVehicles.Where(v =>
                v.CapacityTons >= order.WeightTons &&
                v.VolumeM3 >= order.VolumeM3 &&
                (!order.RequiresRefrigerator || v.HasRefrigerator) &&
                v.Status == "Справний"
            ).ToList();
        }

        // Призначення транспорту замовленню
        public async Task AssignVehicleAsync(int orderId, string licensePlate)
        {
            var order = await _context.Orders.FindAsync(orderId);

            if (order != null)
            {
                order.AssignedVehiclePlate = licensePlate;
                order.Status = "Призначено транспорт";

                await _context.SaveChangesAsync();
            }
        }
    }
}
