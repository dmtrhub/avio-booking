namespace Domain.Entities
{
    public class Airline
    {
        public StronglyTypedId<Airline> Id { get; set; } = StronglyTypedId<Airline>.NewId();
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ContactInfo { get; set; } = string.Empty;
        public List<Flight> Flights { get; set; } = new();
        public List<Review> Reviews { get; set; } = new();
    }
}
