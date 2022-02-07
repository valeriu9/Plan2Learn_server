
namespace BookingSystem.Model
{
    public class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public List<Booking> Bookings { get; } = new();
    }
}
