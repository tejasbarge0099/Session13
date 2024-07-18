using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Session13.DAL
{
    public class Booking
    {
        [Key]
        public int BID { get; set; }
        public int CID { get; set; }
        public int FID { get; set; }
        public long Pass { get; set; }
        public DateTime BookDate { get; set; }
        public long BookCost { get; set; }

        [ForeignKey("CID")]
        public Customer Cust { get; set; }

        [ForeignKey("FID")]
        public Flight Fli { get; set; }

        public Booking()
        { 
        }
    }
}
