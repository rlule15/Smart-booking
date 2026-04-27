namespace SmartBooking.API.Models
{
    public class Service
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required int Duration { get; set; }
        public required string Description { get; set; }
    }
}
