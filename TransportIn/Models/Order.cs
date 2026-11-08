namespace TransportIn.Models
{
    public class Order
    {
        public int Id { get; set; }

        // Інформація про замовника
        public string CustomerCompany { get; set; } = "";
        public string CustomerName { get; set; } = "";
        public string CustomerPhone { get; set; } = "";
        public string CustomerEmail { get; set; } = "";

        // Характеристики вантажу
        public string CargoName { get; set; } = "";
        public double WeightTons { get; set; }
        public double VolumeM3 { get; set; }
        public bool RequiresRefrigerator { get; set; }

        // Пункти завантаження та доставки (списки адрес)
        public List<string> LoadingPoints { get; set; } = new();
        public List<string> DeliveryPoints { get; set; } = new();

        // Призначений транспорт та статус
        public string AssignedVehiclePlate { get; set; } = "Не призначено";
        public string Status { get; set; } = "Нове";
    }
}