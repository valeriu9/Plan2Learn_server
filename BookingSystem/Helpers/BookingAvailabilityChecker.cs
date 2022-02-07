using BookingSystem.Model;

namespace BookingSystem.Helpers
{
    public class BookingAvailabilityChecker
    {
        public bool Check(List<Booking> bookings, int resourceDefaultQuantity , Booking bookingToCompare)
        {
            var bookedQuantity = 0;
            foreach (var booking in bookings)
            {
                if(booking.ResourceId == bookingToCompare.ResourceId)
                {
                    if(booking.DateFrom < bookingToCompare.DateTo && bookingToCompare.DateFrom < booking.DateTo)
                    {
                        bookedQuantity += booking.BookedQuantity;
                    }
                }
            }
            var remainQuantity = resourceDefaultQuantity - bookedQuantity;
            return  remainQuantity - bookingToCompare.BookedQuantity >= 0;
        }
    }
}
