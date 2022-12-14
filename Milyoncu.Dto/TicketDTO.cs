using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milyoncu.Dto
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public int TicketPrice { get; set; }
        public string EventName { get; set; }
        public bool ?Completed { get; set; }
        public int BasketId { get; set; }
    }
}
