using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class RentalContact
{
    public int Id { get; set; }

    public DateTime RentalDate { get; set; }

    public string RentalPeriod { get; set; } = null!;

    public DateTime ReturnDate { get; set; }

    public string TerminationClause { get; set; } = null!;

    public int RentalOrderId { get; set; }

    public int LesseeId { get; set; }

    public int LessorId { get; set; }

    public bool IsDeleted { get; set; }

    public int? UserId { get; set; }

    public virtual User Lessee { get; set; } = null!;

    public virtual RentalLocation Lessor { get; set; } = null!;

    public virtual RentalOrder? RentalOrder { get; set; }

    public virtual User? User { get; set; }
}
