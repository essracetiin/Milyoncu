using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milyoncu.Entity.Concrete
{
    public class Ticket:BaseTable
    {
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int TicketPrice { get; set; }
        public int EventId { get; set; }
        [ForeignKey("EventId")]
        public Event Event { get; set; }

    }
}
