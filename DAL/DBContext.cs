using Microsoft.EntityFrameworkCore;

namespace Session13.DAL
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base (options) 
        {

        }
        public DbSet<Flight> Flight {  get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Booking> Booking { get; set; }

    }
}
