using BookingSystem.Model;

namespace BookingSystem.Services
{
    public interface IBookingService
    {
        List<Booking> GetBookingsByResourceId(int id);
        bool CreateBooking(Booking booking);
    }
}
