using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class CitizenId
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string CitizenIdNumber { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public string ImageUrl { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
