using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class DriverLicense
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public int Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
