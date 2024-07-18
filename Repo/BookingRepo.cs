using AutoMapper;
using Session13.DAL;
using Session13.Models;
namespace Session13.Repo
{
    public interface IBookingRepo
    {
        public void AddBooking(BookingModel b);
        public void AddBulkBookings(List<BookingModel> b);
        public List<BookingModel> GetAllBookings();
        public List<BookingModel> GetBookingsWithDateRange(DateTime d1, DateTime d2);
        public long GetEarningsWithDateRange(DateTime d1, DateTime d2);
        public BookingModel GetBookingById(int id);
        public void RemoveBookingById(int id);
        public CustomerModel GetCustomerDetailsByBookingId(int id);
        public List<FlightModel> GetAllFlightsWithSourceByBookingId(int id);
        public void AddPassangersToGivenBooking(int id, int p);
    }
    public class BookingRepo : IBookingRepo
    {
        public readonly DBContext context;
        public readonly IMapper _mapper;
        public BookingRepo(IMapper mapper, DBContext _context)
        {
            this.context = _context;
            this._mapper = mapper;
        }
        public void AddBooking(BookingModel b)
        {
            var fl = context.Flight.Find(b.FID);
            var cm = context.Customer.Find(b.CID);
            if (fl != null && cm != null)
            {
                if (fl.cap - fl.total > b.Pass)
                {
                    var v = _mapper.Map<Booking>(b);
                    v.Fli = fl;
                    v.Cust = cm;
                    context.Booking.Add(v);
                    fl.total += b.Pass;
                    context.SaveChanges();
                }
            }
        }
        public void AddBulkBookings(List<BookingModel> b)
        {
            foreach (BookingModel m in b)
            {
                var cm = context.Customer.Find(m.CID);
                var fl = context.Flight.Find(m.FID);
                if (fl != null)
                {
                    if (fl.cap - fl.total > m.Pass)
                    {
                        var v = _mapper.Map<Booking>(m);
                        v.Fli = fl;
                        v.Cust = cm;
                        context.Booking.Add(v);
                        fl.total += m.Pass;
                        context.SaveChanges();
                    }
                }
            }
        }
        public List<BookingModel> GetAllBookings()
        {
            return _mapper.Map<List<BookingModel>>(context.Booking.ToList());
        }
        public List<BookingModel> GetBookingsWithDateRange(DateTime d1, DateTime d2)
        {
            return _mapper.Map<List<BookingModel>>(context.Booking.Where(b => (b.BookDate >= d1 && b.BookDate <= d2)).ToList());
        }
        public long GetEarningsWithDateRange(DateTime d1, DateTime d2)
        {
            long ans = 0;
            List<Booking> l = context.Booking.Where(b => (b.BookDate >= d1 && b.BookDate <= d2)).ToList();
            foreach (Booking c in l)
            {
                if (c.BookDate >= d1 && c.BookDate <= d2)
                    ans += c.BookCost;
            }
            return ans;
        }
        public BookingModel GetBookingById(int id)
        {
            return _mapper.Map<BookingModel>(context.Booking.FirstOrDefault(b => b.BID == id));
        }
        public void RemoveBookingById(int id)
        {
            var v = context.Booking.FirstOrDefault(b => b.BID == id);
            if (v != null)
            {
                var t = context.Flight.FirstOrDefault(f => f.Id == v.FID);
                t.total += v.Pass;
                context.Booking.Remove(v);
                context.SaveChanges();
            }
        }
        public CustomerModel GetCustomerDetailsByBookingId(int id)
        {
            var v = context.Booking.FirstOrDefault(b => b.BID == id);
            if (v != null)
                return _mapper.Map<CustomerModel>(context.Customer.FirstOrDefault(c => c.id == v.CID));
            return null;
        }
        public List<FlightModel> GetAllFlightsWithSourceByBookingId(int id)
        {
            var bk = context.Booking.FirstOrDefault(b => b.BID == id);
            if (bk != null)
            {
                var fl = context.Flight.FirstOrDefault(f => f.Id == bk.FID);
                if (fl != null)
                    return _mapper.Map<List<FlightModel>>(context.Flight.Where(f => f.src.Equals(fl.src)).ToList());
            }
            return null;
        }
        public void AddPassangersToGivenBooking(int id, int p)
        {
            var bk = context.Booking.FirstOrDefault(b => b.BID == id);
            if (bk != null)
            {
                var fl = context.Flight.FirstOrDefault(f => f.Id == bk.FID);
                if (fl != null)
                {
                    if (fl.cap - fl.total >= bk.Pass + p)
                    {
                        bk.Pass += p;
                        fl.total += p;
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
