using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Session13.DAL
{
    public class Customer
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public long no { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public string bg { get; set; }
        public string passport { get; set; }

        public Customer()
        {

        }
    }
}
