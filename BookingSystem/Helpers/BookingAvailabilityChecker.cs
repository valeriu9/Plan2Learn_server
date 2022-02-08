using BookingSystem.Model;

namespace BookingSystem.Helpers
{
    public class BookingAvailabilityChecker
    {
        public bool Check(List<Booking> bookings, Resource actualResource, Booking bookingToCompare)
        {
            DateTimeHelper dateTimeHelper = new();
            // Check for all data needed.
            if( bookings == null || actualResource == null || bookingToCompare == null )
            {
                return false;
            }
            var bookedQuantity = 0;
            foreach (var booking in bookings)
            {
                if (booking.ResourceId == bookingToCompare.ResourceId)
                {
                    if(dateTimeHelper.AreDateTimeRangesOverlap(booking.DateFrom, booking.DateTo, bookingToCompare.DateFrom, bookingToCompare.DateTo))
                    {
                        bookedQuantity += booking.BookedQuantity;
                    }
                }
            }
            var remainQuantity = actualResource.Quantity - bookedQuantity;
            return remainQuantity - bookingToCompare.BookedQuantity >= 0;
        }
    }
}
