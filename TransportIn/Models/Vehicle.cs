    namespace TransportIn.Models
    {
        public class Vehicle
        {
            public int Id { get; set; }
            public string BrandModel { get; set; } = ""; // Марка, модель
            public string LicensePlate { get; set; } = ""; // Держномер (напр. АА 1234 ВР)
            public string VinCode
            { get; set; } = ""; // VIN-код (17 символов)
            public string BodyType { get; set; } = "Тент"; // Тент, рефрижератор, цільнометалічний фургон
            public double CapacityTons { get; set; } // Вантажопідйомність (т)
            public double VolumeM3 { get; set; } // Об'єм кузова (m³)
            public bool HasRefrigerator { get; set; } // Наявність холодильної установки
            public string AssignedDriver { get; set; } = "Не призначено";
            public string Status { get; set; } = "Справний";
            public double Lat { get; set; } = 50.4501;
            public double Lng { get; set; } = 30.5234;
        }
    }