using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class RentalLocation
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<CarRentalLocation> CarRentalLocations { get; set; } = new List<CarRentalLocation>();

    public virtual ICollection<RentalContact> RentalContacts { get; set; } = new List<RentalContact>();
}
