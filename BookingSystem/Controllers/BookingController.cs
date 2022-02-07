using BookingSystem.Model;
using BookingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        BookingService bookings = new BookingService();

        [HttpGet("~/get-bookings-by-resource")]
        public IActionResult GetBookingsByResourceId([FromQuery] int id)
        {
            return Ok(bookings.GetBookingsByResourceId(id));
        }

        [HttpPost("~/create-booking")]
        public IActionResult CreateBooking([FromBody] Booking booking)
        {
            if(booking.BookedQuantity == 0 || booking.ResourceId == 0)
            {
                return BadRequest("Some parameters are missing or incorrect");
            }
            var isValid = bookings.CreateBooking(booking);
            return Ok( isValid ? new {statusType = "success", message= "Booked successfuly" } : new { statusType = "error", message = "The resources you are trying to book are not available for these days" });
        }

    }
}
