using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Session13.Models;
using Session13.Repo;

namespace Session13.Controllers
{
    [Route("booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        public readonly IBookingRepo _book;
        public BookingController(IBookingRepo book)
        {
            _book = book;
        }

        [HttpPost("Add")]
        public IActionResult Add(BookingModel b)
        {
            _book.AddBooking(b);
            return Ok("Success");
        }

        [HttpPost("AddBulk")]
        public IActionResult AddBulk(List<BookingModel> l)
        {
            _book.AddBulkBookings(l);
            return Ok("Success");
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            List<BookingModel> l = _book.GetAllBookings();
            return Ok(l);
        }

        [HttpGet("GetWithDateRange")]
        public IActionResult GetWithDateRange(List<DateTime> d)
        {
            List<BookingModel> l = _book.GetBookingsWithDateRange(d[0], d[1]);
            return Ok(l);
        }

        [HttpGet("GetEarnWithDateRange")]
        public IActionResult GetEarnWithDateRange(List<DateTime> d)
        {
            long l = _book.GetEarningsWithDateRange(d[0], d[1]);
            return Ok(l);
        }

        [HttpGet("GetWithId")]
        public IActionResult GetWithId(int id)
        {
            BookingModel l = _book.GetBookingById(id);
            return Ok(l);
        }

        [HttpDelete("DeleteById")]
        public IActionResult DeleteById(int id)
        {
            _book.RemoveBookingById(id);
            return Ok("Success");
        }

        [HttpGet("GetCustByBID")]
        public IActionResult GetCustByBID(int id)
        {
            CustomerModel c = _book.GetCustomerDetailsByBookingId(id);
            return Ok(c);
        }

        [HttpGet("GetFlightBySorceByBID")]
        public IActionResult GetFlightBySourceByBID(int id)
        {
            List<FlightModel> l = _book.GetAllFlightsWithSourceByBookingId(id);
            return Ok(l);
        }

        [HttpPost("AddPass")]
        public IActionResult AddPass(int id, int p)
        {
            _book.AddPassangersToGivenBooking(id, p);
            return Ok("Success");
        }
    }
}
