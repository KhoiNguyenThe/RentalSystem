using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Entities;

public partial class EvsdbContext : DbContext
{
    public EvsdbContext()
    {
    }

    public EvsdbContext(DbContextOptions<EvsdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarDeliveryHistory> CarDeliveryHistories { get; set; }

    public virtual DbSet<CarRentalLocation> CarRentalLocations { get; set; }

    public virtual DbSet<CarReturnHistory> CarReturnHistories { get; set; }

    public virtual DbSet<CitizenId> CitizenIds { get; set; }

    public virtual DbSet<DriverLicense> DriverLicenses { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<RentalContact> RentalContacts { get; set; }

    public virtual DbSet<RentalLocation> RentalLocations { get; set; }

    public virtual DbSet<RentalOrder> RentalOrders { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local);uid=sa;pwd=12345;database=EVSDB;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarDeliveryHistory>(entity =>
        {
            entity.HasIndex(e => e.CarId, "IX_CarDeliveryHistories_CarId");

            entity.HasIndex(e => e.CustomerId, "IX_CarDeliveryHistories_CustomerId");

            entity.HasIndex(e => e.OrderId, "IX_CarDeliveryHistories_OrderId");

            entity.HasIndex(e => e.StaffId, "IX_CarDeliveryHistories_StaffId");

            entity.HasOne(d => d.Car).WithMany(p => p.CarDeliveryHistories)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Customer).WithMany(p => p.CarDeliveryHistoryCustomers)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Order).WithMany(p => p.CarDeliveryHistories)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Staff).WithMany(p => p.CarDeliveryHistoryStaffs)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<CarRentalLocation>(entity =>
        {
            entity.HasIndex(e => e.CarId, "IX_CarRentalLocations_CarId");

            entity.HasIndex(e => e.LocationId, "IX_CarRentalLocations_LocationId");

            entity.HasOne(d => d.Car).WithMany(p => p.CarRentalLocations).HasForeignKey(d => d.CarId);

            entity.HasOne(d => d.Location).WithMany(p => p.CarRentalLocations).HasForeignKey(d => d.LocationId);
        });

        modelBuilder.Entity<CarReturnHistory>(entity =>
        {
            entity.HasIndex(e => e.CarId, "IX_CarReturnHistories_CarId");

            entity.HasIndex(e => e.CustomerId, "IX_CarReturnHistories_CustomerId");

            entity.HasIndex(e => e.OrderId, "IX_CarReturnHistories_OrderId");

            entity.HasIndex(e => e.StaffId, "IX_CarReturnHistories_StaffId");

            entity.HasOne(d => d.Car).WithMany(p => p.CarReturnHistories)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Customer).WithMany(p => p.CarReturnHistoryCustomers)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Order).WithMany(p => p.CarReturnHistories)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Staff).WithMany(p => p.CarReturnHistoryStaffs)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<CitizenId>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_CitizenIds_UserId").IsUnique();

            entity.HasOne(d => d.User).WithOne(p => p.CitizenIdNavigation).HasForeignKey<CitizenId>(d => d.UserId);
        });

        modelBuilder.Entity<DriverLicense>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_DriverLicenses_UserId").IsUnique();

            entity.HasOne(d => d.User).WithOne(p => p.DriverLicense).HasForeignKey<DriverLicense>(d => d.UserId);
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasIndex(e => e.RentalOrderId, "IX_Feedbacks_RentalOrderId");

            entity.HasIndex(e => e.UserId, "IX_Feedbacks_UserId").IsUnique();

            entity.HasOne(d => d.RentalOrder).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.RentalOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithOne(p => p.Feedback)
                .HasForeignKey<Feedback>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_Payments_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.Payments).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<RentalContact>(entity =>
        {
            entity.HasIndex(e => e.LesseeId, "IX_RentalContacts_LesseeId");

            entity.HasIndex(e => e.LessorId, "IX_RentalContacts_LessorId");

            entity.HasIndex(e => e.UserId, "IX_RentalContacts_UserId");

            entity.HasOne(d => d.Lessee).WithMany(p => p.RentalContactLessees)
                .HasForeignKey(d => d.LesseeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Lessor).WithMany(p => p.RentalContacts)
                .HasForeignKey(d => d.LessorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithMany(p => p.RentalContactUsers).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<RentalOrder>(entity =>
        {
            entity.HasIndex(e => e.CarId, "IX_RentalOrders_CarId");

            entity.HasIndex(e => e.RentalContactId, "IX_RentalOrders_RentalContactId").IsUnique();

            entity.HasIndex(e => e.UserId, "IX_RentalOrders_UserId");

            entity.HasOne(d => d.Car).WithMany(p => p.RentalOrders)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.RentalContact).WithOne(p => p.RentalOrder).HasForeignKey<RentalOrder>(d => d.RentalContactId);

            entity.HasOne(d => d.User).WithMany(p => p.RentalOrders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
