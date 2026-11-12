

using System;
using TransportIn.Services;

namespace TransportIn.Models
{
    public class EmployeeDocument
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public EmployeeDocumentType DocumentType { get; set; }

        public string DocumentNumber { get; set; } = "";

        public DateTime IssueDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public string IssuedBy { get; set; } = "";

        public string Details { get; set; } = "";

        public Employee? Employee { get; set; }
    }


    public enum EmployeeDocumentType
    {
        Passport,
        TaxNumber,
        Education,
        MedicalCertificate,
        DriverLicense,
        MilitaryDocument,
        WorkBook
    }
}
