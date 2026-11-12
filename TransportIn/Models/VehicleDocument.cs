
using System;

namespace TransportIn.Models
{
    public class VehicleDocument
    {
        public int Id { get; set; }

        // Автомобиль, которому принадлежит документ
        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }

        // Тип документа
        public VehicleDocumentType DocumentType { get; set; }

        public string DocumentNumber { get; set; } = "";

        // Даты действия документа
        public DateOnly IssueDate { get; set; }
        public DateOnly? ExpiryDate { get; set; }

        public string IssuedBy { get; set; } = "";

        // Дополнительная информация
        public string Details { get; set; } = "";
    }

    public enum VehicleDocumentType
    {
        RegistrationCertificate,
        TechnicalPassport,
        TechnicalInspection,
        Insurance,
        CargoLicense
    }
}
