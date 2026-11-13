using System;
using System.Collections.Generic;

namespace TransportIn.Data.Entities;

public partial class Cargo
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public double WeightKg { get; set; }

    public string TransportConditions { get; set; } = null!;

    public string SenderName { get; set; } = null!;

    public string SenderPhone { get; set; } = null!;

    public string RecipientName { get; set; } = null!;

    public string RecipientPhone { get; set; } = null!;

    public virtual ICollection<OrderCargo> OrderCargos { get; set; } = new List<OrderCargo>();
}
