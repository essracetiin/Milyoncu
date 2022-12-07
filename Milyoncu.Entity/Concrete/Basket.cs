using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milyoncu.Entity.Concrete
{
    public class Basket:BaseTable
    {
        public Basket()
        {
            Tickets = new List<Ticket>();
        }
        public bool Completed { get; set; }
        public int TotalPrice { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public  User User { get; set; }
        public ICollection<Ticket> Tickets { get; set; }

    }
}
