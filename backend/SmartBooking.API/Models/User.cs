using Microsoft.AspNetCore.Identity;

namespace SmartBooking.API.Models
{
    public class User: IdentityUser<Guid>
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public virtual ICollection<Appointment>? Appointments { get; set; } = new List<Appointment>();
    }
}
