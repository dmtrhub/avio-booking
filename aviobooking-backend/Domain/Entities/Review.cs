namespace Domain.Entities
{
    public class Review
    {
        public StronglyTypedId<Review> Id { get; set; } = StronglyTypedId<Review>.NewId();
        public StronglyTypedId<User> ReviewerId { get; set; }
        public StronglyTypedId<Airline> AirlineId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public ReviewStatus Status { get; set; }
    }
}
