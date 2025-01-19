using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Flight
    {
        public StronglyTypedId<Flight> Id { get; set; } = StronglyTypedId<Flight>.NewId();
        public StronglyTypedId<Airline> AirlineId { get; set; }
        public string DepartureLocation { get; set; } = string.Empty;
        public string ArrivalLocation { get; set; } = string.Empty;
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int AvailableSeats { get; set; }
        public int ReservedSeats { get; set; }
        public decimal Price { get; set; }
        public FlightStatus Status { get; set; }
    }
}
