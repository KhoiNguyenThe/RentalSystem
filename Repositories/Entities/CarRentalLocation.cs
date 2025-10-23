using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class CarRentalLocation
{
    public int Id { get; set; }

    public int Quantity { get; set; }

    public int CarId { get; set; }

    public int LocationId { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual RentalLocation Location { get; set; } = null!;
}
