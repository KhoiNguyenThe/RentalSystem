using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class RentalOrder
{
    public int Id { get; set; }

    public DateTime OrderDate { get; set; }

    public double? SubTotal { get; set; }

    public double? Total { get; set; }

    public int? Discount { get; set; }

    public double? ExtraFee { get; set; }

    public int Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int UserId { get; set; }

    public int CarId { get; set; }

    public int RentalContactId { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual ICollection<CarDeliveryHistory> CarDeliveryHistories { get; set; } = new List<CarDeliveryHistory>();

    public virtual ICollection<CarReturnHistory> CarReturnHistories { get; set; } = new List<CarReturnHistory>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual RentalContact RentalContact { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
