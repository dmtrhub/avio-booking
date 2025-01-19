using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Reservation
    {
        public StronglyTypedId<Reservation> Id { get; set; } = StronglyTypedId<Reservation>.NewId();
        public StronglyTypedId<User> UserId { get; set; }
        public StronglyTypedId<Flight> FlightId { get; set; }
        public int PassengerCount { get; set; }
        public decimal TotalPrice { get; set; }
        public ReservationStatus Status { get; set; }
    }
}
