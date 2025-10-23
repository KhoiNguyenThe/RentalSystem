using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class CarReturnHistory
{
    public int Id { get; set; }

    public DateTime ReturnDate { get; set; }

    public int OdometerEnd { get; set; }

    public int BatteryLevelEnd { get; set; }

    public string VehicleConditionEnd { get; set; } = null!;

    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public int StaffId { get; set; }

    public int CarId { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual User Customer { get; set; } = null!;

    public virtual RentalOrder Order { get; set; } = null!;

    public virtual User Staff { get; set; } = null!;
}
