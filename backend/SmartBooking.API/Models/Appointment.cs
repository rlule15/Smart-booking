namespace SmartBooking.API.Models
{
    public class Appointment
    {
        public enum AppointmentStatus 
        {
            Pending = 0,
            Confirmed = 1,
            Completed = 2,
            Cancelled = 3,
            NoShow = 4
        }
        public Guid Id { get; set; }
        public required string userId { get; set; }
        public required User User { get; set; }
        public required string ServiceId { get; set; }
        public required Service Service { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        
    } 
}
