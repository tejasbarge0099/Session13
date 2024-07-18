using System.Runtime.Intrinsics.X86;
using Session13.Models;
using Microsoft.AspNetCore.JsonPatch;
using Session13.DAL;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
namespace Session13.Repo
{
    public interface IFlightRepo
    {
        public void AddFlight(FlightModel f);
        public void AddBulkFlights(List<FlightModel> l);
        public List<FlightModel> GetAllFlights();
        public FlightModel GetFlightWithID(int id);
        public List<FlightModel> GetFlightsWithSource(string s);
        public long GetRemainingCapacity(int id);
        public void UpdateFlight(int id, JsonPatchDocument j);
        public void RemoveFlightById(int id);
    }
    public class FlightRepo : IFlightRepo
    {
        public readonly DBContext context;
        public readonly IMapper _mapper;
        public FlightRepo(IMapper mapper, DBContext _context)
        {
           context = _context;
           _mapper = mapper;
        }

        public void AddFlight(FlightModel f)
        {
            context.Flight.Add(_mapper.Map<Flight>(f));
            context.SaveChanges();       
        }
        public void AddBulkFlights(List<FlightModel> f)
        {
            foreach (FlightModel c in f)
            {
                context.Flight.Add(_mapper.Map<Flight>(c));
                context.SaveChanges();
            }
        }
        public List<FlightModel> GetAllFlights()
        {
            return _mapper.Map<List<FlightModel>>(context.Flight.ToList());
        }
        public FlightModel GetFlightWithID(int id)
        {
            return _mapper.Map<FlightModel>(context.Flight.FirstOrDefault(f => f.Id == id));
        }
        public List<FlightModel> GetFlightsWithSource(string s)
        {
           return _mapper.Map<List<FlightModel>>(context.Flight.Where(f => f.src.Equals(s)).ToList());
        }
        public long GetRemainingCapacity(int id)
        {
            var fl = context.Flight.FirstOrDefault(f => f.Id == id);
            return fl.cap - fl.total;
        }
        public void UpdateFlight(int id, JsonPatchDocument j)
        {
            var fl = context.Flight.FirstOrDefault(f => f.Id == id);
            if(fl != null)
            {
                j.ApplyTo(fl);
                context.SaveChanges();
            } 
        }
        public void RemoveFlightById(int id)
        {
            var fl = context.Flight.FirstOrDefault(f => f.Id == id);
            if (fl != null)
            {
                context.Flight.Remove(fl);
                context.SaveChanges();
            }
        }
    }
}
