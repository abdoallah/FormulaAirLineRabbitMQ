using FormulaAirLine.Models;
using FormulaAirLine.Services;
using Microsoft.AspNetCore.Mvc;

namespace FormulaAir.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly ILogger<BookingController> _logger;
        private readonly IMassageProducer _messageProducer;

        public static readonly List<Booking> bookings = new();
        public BookingController(ILogger<BookingController> logger, IMassageProducer messageProducer)
        {
            _logger = logger;
            _messageProducer = messageProducer;
        }
        [HttpPost]
        public IActionResult CreateBooking(Booking booking)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            bookings.Add(booking);
            _messageProducer.SendingMessage(bookings);
            return Ok();
        }
    }
}
