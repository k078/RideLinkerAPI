using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class Trip
    {
        public int Id { get; set; }
        public Location? Departure { get; set; }
        public Location? Destination { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DriverId { get; set; }
        public int CarId { get; set; }
        public Car? Car { get; set; }
        public User? Driver { get; set; }
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}
