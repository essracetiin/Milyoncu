using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milyoncu.Entity.Concrete
{
    public class Ticket : BaseTable
    {

        public int TicketPrice { get; set; }
        public int EventId { get; set; }
        public int ?BasketId { get; set; }

        public Event ?Event { get; set; }
        [ForeignKey("BasketId")]
        public Basket ?Basket{ get; set; }

    }

}

