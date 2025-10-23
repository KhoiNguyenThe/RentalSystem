using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class CarDeliveryHistory
{
    public int Id { get; set; }

    public DateTime DeliveryDate { get; set; }

    public int OdometerStart { get; set; }

    public int BatteryLevelStart { get; set; }

    public string VehicleConditionStart { get; set; } = null!;

    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public int StaffId { get; set; }

    public int CarId { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual User Customer { get; set; } = null!;

    public virtual RentalOrder Order { get; set; } = null!;

    public virtual User Staff { get; set; } = null!;
}
