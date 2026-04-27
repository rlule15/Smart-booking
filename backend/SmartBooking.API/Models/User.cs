using Microsoft.AspNetCore.Identity;

namespace SmartBooking.API.Models
{
    public class User: IdentityUser
    {
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
