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
        public bool Completed { get; set; }
        public int TotalPrice { get; set; }
        public int TicketQuantity { get; set; }
        public int TicketId { get; set; }
        [ForeignKey("TicketId")]
        public ICollection<Ticket> Ticket { get; set; }
    }
}
