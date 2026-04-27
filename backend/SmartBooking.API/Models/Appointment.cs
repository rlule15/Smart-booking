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
        public required Guid userId { get; set; }
        public required User User { get; set; }
        public required Guid ServiceId { get; set; }
        public required Service Service { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime => StartTime.AddMinutes(Service?.Duration ?? 0);
        public required Guid AvailabilitySlotId { get; set; }
        public required AvailabilitySlot AvailabilitySlot { get; set; }
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
    } 
}
