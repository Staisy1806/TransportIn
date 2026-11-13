using System;
using System.Collections.Generic;

namespace TransportIn.Data.Entities;

public partial class EmployeeDocument
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public int DocumentType { get; set; }

    public string DocumentNumber { get; set; } = null!;

    public DateTime IssueDate { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public string IssuedBy { get; set; } = null!;

    public string Details { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
