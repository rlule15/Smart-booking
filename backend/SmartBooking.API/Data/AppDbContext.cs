using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartBooking.API.Models;

namespace SmartBooking.API.Data
{
    public class AppDbContext: IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Appointment> Appointments { get; set; } = null!;

        public DbSet<Service> Services { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Service>(s =>
            {
                s.HasKey(s => s.Id);
                s.Property(x => x.Id).IsRequired();
                s.Property(x => x.Name).IsRequired().HasMaxLength(100);
                s.Property(x => x.Duration).IsRequired();
                s.Property(x => x.Description).IsRequired();
                s.HasData(
                    new Service { Id = Guid.Parse("72559556-9810-4412-B2D8-5B77353C430B"), Name = "Classic Full Set", Duration = 120, Description = "A natural 1:1 application of extensions to natural lashes for added length." },
                    new Service { Id = Guid.Parse("A194685D-7859-4E61-8C52-039B6F57A88C"), Name = "Hybrid Full Set", Duration = 135, Description = "A textured blend of Classic and Volume lashes for a wispy, multidimensional look." },
                    new Service { Id = Guid.Parse("B294685D-7859-4E61-8C52-039B6F57A88D"), Name = "Volume Full Set", Duration = 150, Description = "Advanced technique using fans of extensions for maximum density and drama." },
                    new Service { Id = Guid.Parse("C394685D-7859-4E61-8C52-039B6F57A88E"), Name = "Lash Lift & Tint", Duration = 60, Description = "Lifts and curls natural lashes from the base and adds a dark tint for a 'mascara' look." }
                    );
            });

            builder.Entity<Appointment>(a =>
            {
                a.HasKey(x => x.Id);
                a.Property(x => x.StartTime).IsRequired();
                a.HasOne(x => x.AvailabilitySlot)
                 .WithOne(x => x.Appointment)
                 .HasForeignKey<Appointment>(x => x.AvailabilitySlotId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<IdentityRole<Guid>>().HasData(new IdentityRole<Guid> { Id = Guid.NewGuid(), Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole<Guid> { Id = Guid.NewGuid(), Name = "Customer", NormalizedName = "CUSTOMER" });

        }
    }
}
