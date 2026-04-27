namespace SmartBooking.API.Models
{
    public class AvailabilitySlot
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsBooked { get; set; }

        public Guid? AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }
    }
}
