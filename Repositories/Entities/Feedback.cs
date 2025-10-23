using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class Feedback
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int UserId { get; set; }

    public int RentalOrderId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual RentalOrder RentalOrder { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
