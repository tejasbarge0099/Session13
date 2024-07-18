using Session13.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Runtime.Intrinsics.X86;
using Session13.DAL;
using AutoMapper;
namespace Session13.Repo
{
    public interface ICustomerRepo
    {
        public void AddCustomer(CustomerModel c);
        public void AddBulkCustomers(List<CustomerModel> c);
        public List<CustomerModel> GetAllCustomers();
        public CustomerModel GetCustomerByID(int id);
        public List<CustomerModel> GetCutomersByBloodGroup(string s);
        public void RemoveCustomerById(int id);
        public void UpdateCustomer(int id, JsonPatchDocument j);
    }
    public class CustomerRepo : ICustomerRepo
    {
        public readonly DBContext context;
        public readonly IMapper _mapper;
        public CustomerRepo(IMapper mapper, DBContext _context)
        {
            _mapper = mapper;
            context = _context;
        }
        public void AddCustomer(CustomerModel c)
        {
            context.Customer.Add(_mapper.Map<Customer>(c));
            context.SaveChanges();
        }
        public void AddBulkCustomers(List<CustomerModel> c)
        {
            foreach (CustomerModel i in c)
            {
                context.Customer.Add(_mapper.Map<Customer>(i));
                context.SaveChanges();
            }
        }
        public List<CustomerModel> GetAllCustomers()
        {
            return _mapper.Map<List<CustomerModel>>(context.Customer.ToList());
        }
        public CustomerModel GetCustomerByID(int id)
        {
            return _mapper.Map<CustomerModel>(context.Customer.FirstOrDefault(c => c.id == id));
        }
        public List<CustomerModel> GetCutomersByBloodGroup(string s)
        {
            return _mapper.Map<List<CustomerModel>>(context.Customer.Where(c => c.bg.Equals(s)).ToList());
        }
        public void RemoveCustomerById(int id)
        {
            var cm = context.Customer.FirstOrDefault(c => c.id == id);
            if (cm != null)
            {
                context.Customer.Remove(cm);
                context.SaveChanges();
            }
        }
        public void UpdateCustomer(int id, JsonPatchDocument j)
        {
            var cm = context.Customer.FirstOrDefault(c => c.id == id);
            if (cm != null)
            {
                j.ApplyTo(cm);
                context.SaveChanges();
            }
        }
    }
}
