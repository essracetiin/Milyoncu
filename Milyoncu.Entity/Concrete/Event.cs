using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milyoncu.Entity.Concrete
{
    public class Event:BaseTable
    {
        public string EventName { get; set; }
        public int Capacity { get; set; }
        public int TicketPrice { get; set; }
        public int TicketQuantity { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public  Category ?Category { get; set; }

        public ICollection<Ticket> ?Tickets { get; set; }
    }
}
