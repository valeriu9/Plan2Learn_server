using BookingSystem.Data;
using BookingSystem.Helpers;
using BookingSystem.Model;

namespace BookingSystem.Services
{
    public class BookingService : IBookingService
    {
        AuthDbContext dbContext = new AuthDbContext();

        public bool CreateBooking(Booking booking)
        {
            int resourceDefaultQuantity = (from resources in dbContext.Resources where resources.Id == booking.ResourceId select resources.Quantity).FirstOrDefault();
            if (resourceDefaultQuantity == 0)
            {
                return false;
            }
            var bookingsForResource = GetBookingsByResourceId(booking.ResourceId);
            if (bookingsForResource.Count == 0)
            {
                return true;
            }
            var result = new BookingAvailabilityChecker().Check(bookingsForResource, resourceDefaultQuantity, booking);

            if (result) { 
            dbContext.Bookings.Add(booking);
            dbContext.SaveChanges();
            }
            return result;
        }

        public List<Booking> GetBookingsByResourceId(int id)
        {
            var result = from bookings in dbContext.Bookings
                      where bookings.ResourceId == id
                      select bookings;
            return result.ToList();
        }
    }
}
