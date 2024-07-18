using AutoMapper;
using Session13.Models;
using Session13.DAL;
namespace Session13.Mapper
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<CustomerModel, Customer>().ReverseMap();
        }
    }
}
