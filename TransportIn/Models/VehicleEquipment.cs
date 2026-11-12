
namespace TransportIn.Models
{
    public class VehicleEquipment
    {
        public int Id { get; set; }

        // Автомобиль
        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }

        // Название оборудования
        public string Name { get; set; } = "";

        // Описание
        public string Description { get; set; } = "";

        // Количество
        public int Quantity { get; set; } = 1;

        // Исправно ли оборудование
        public bool IsWorking { get; set; } = true;
    }
}
