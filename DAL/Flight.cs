using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Session13.DAL
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }
        public DateTime jrndate { get; set; }
        public string src { get; set; }
        public string destn { get; set; }
        public DateTime arrive { get; set; }
        public DateTime departure { get; set; }
        public long cost { get; set; }
        public long cap { get; set; }
        public long total { get; set; }

        public Flight() 
        { 

        }
    }
}
