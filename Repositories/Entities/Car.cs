using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class Car
{
    public int Id { get; set; }

    public string Model { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Seats { get; set; }

    public string SizeType { get; set; } = null!;

    public int TrunkCapacity { get; set; }

    public string BatteryType { get; set; } = null!;

    public int BatteryDuration { get; set; }

    public double RentPricePerDay { get; set; }

    public double RentPricePerHour { get; set; }

    public double RentPricePerDayWithDriver { get; set; }

    public double RentPricePerHourWithDriver { get; set; }

    public string ImageUrl { get; set; } = null!;

    public int Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<CarDeliveryHistory> CarDeliveryHistories { get; set; } = new List<CarDeliveryHistory>();

    public virtual ICollection<CarRentalLocation> CarRentalLocations { get; set; } = new List<CarRentalLocation>();

    public virtual ICollection<CarReturnHistory> CarReturnHistories { get; set; } = new List<CarReturnHistory>();

    public virtual ICollection<RentalOrder> RentalOrders { get; set; } = new List<RentalOrder>();
}
