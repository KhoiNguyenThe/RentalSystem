using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string? ConfirmEmailToken { get; set; }

    public bool IsEmailConfirmed { get; set; }

    public string? ResetPasswordToken { get; set; }

    public DateTime? ResetPasswordTokenExpiry { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; }

    public int? DriverLicenseId { get; set; }

    public int? CitizenId { get; set; }

    public int? FeedbackId { get; set; }

    public virtual ICollection<CarDeliveryHistory> CarDeliveryHistoryCustomers { get; set; } = new List<CarDeliveryHistory>();

    public virtual ICollection<CarDeliveryHistory> CarDeliveryHistoryStaffs { get; set; } = new List<CarDeliveryHistory>();

    public virtual ICollection<CarReturnHistory> CarReturnHistoryCustomers { get; set; } = new List<CarReturnHistory>();

    public virtual ICollection<CarReturnHistory> CarReturnHistoryStaffs { get; set; } = new List<CarReturnHistory>();

    public virtual CitizenId? CitizenIdNavigation { get; set; }

    public virtual DriverLicense? DriverLicense { get; set; }

    public virtual Feedback? Feedback { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<RentalContact> RentalContactLessees { get; set; } = new List<RentalContact>();

    public virtual ICollection<RentalContact> RentalContactUsers { get; set; } = new List<RentalContact>();

    public virtual ICollection<RentalOrder> RentalOrders { get; set; } = new List<RentalOrder>();
}
