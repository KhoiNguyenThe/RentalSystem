using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class Payment
{
    public int Id { get; set; }

    public DateTime PaymentDate { get; set; }

    public double Amount { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public int Status { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
