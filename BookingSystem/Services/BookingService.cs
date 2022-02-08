using BookingSystem.Data;
using BookingSystem.Helpers;
using BookingSystem.Model;

namespace BookingSystem.Services
{
    public class BookingService : IBookingService
    {
        readonly AuthDbContext dbContext = new();

        public bool CreateBooking(Booking booking)
        {
            Resource actualResource = (from resources in dbContext.Resources where resources.Id == booking.ResourceId select resources).FirstOrDefault();
            if (actualResource == null || actualResource.Quantity == 0)
            {
                return false;
            }
            var bookingsForResource = GetBookingsByResourceId(booking.ResourceId);
            var result = new BookingAvailabilityChecker().Check(bookingsForResource, actualResource, booking);

            if (result)
            {
                dbContext.Bookings.Add(booking);
                dbContext.SaveChanges();
                Console.WriteLine("EMAIL SENT TO admin@admin.com FOR CREATED BOOKING WITH ID = " + booking.Id);
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
