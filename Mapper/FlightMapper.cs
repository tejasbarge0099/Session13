using AutoMapper;
using Session13.Models;
using Session13.DAL;
namespace Session13.Mapper
{
    public class FlightMapper : Profile
    {
        public FlightMapper()
        {
            CreateMap<FlightModel, Flight>().ReverseMap();
        }
    }
}
