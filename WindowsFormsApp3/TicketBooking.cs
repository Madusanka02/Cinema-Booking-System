using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    internal class TicketBooking
    {
        public string Movie { get; }
        public string Showtime { get; }
        public string Seat { get; }
        public string CustomerName { get; }
        public string Contact { get; }
        private const int PricePerTicket = 10;

        public TicketBooking(string movie, string showtime, string seat, string customerName, string contact)
        {
            Movie = movie;
            Showtime = showtime;
            Seat = seat;
            CustomerName = customerName;
            Contact = contact;
        }

        public string GetBookingDetails()
        {
            return $"Customer: {CustomerName}\nContact: {Contact}\nMovie: {Movie}\nShowtime: {Showtime}\nSeat: {Seat}\nTotal Price: ${PricePerTicket}";
        }
    }
}
