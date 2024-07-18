using AutoMapper;
using Session13.Models;
using Session13.DAL;
namespace Session13.Mapper
{
    public class BookingMapper : Profile
    {
        public BookingMapper()
        {
            CreateMap<BookingModel, Booking>()
            .ForMember(ds => ds.BID, s => s.MapFrom(s => s.BID))
            .ForMember(ds => ds.CID, s => s.MapFrom(s => s.CID))
            .ForMember(ds => ds.FID, s => s.MapFrom(s => s.FID))
            .ForMember(ds => ds.Pass, s => s.MapFrom(s => s.Pass))
            .ForMember(ds => ds.BookDate, s => s.MapFrom(s => s.BookDate))
            .ForMember(ds => ds.BookCost, s => s.MapFrom(s => s.BookCost));
            CreateMap<Booking, BookingModel>();
        }
    }
}
