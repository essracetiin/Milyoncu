using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milyoncu.Dto.Models
{
    public class BasketModel
    {
        public BasketDTO BasketDTO { get; set; }
        public int TicketId { get; set; }
        public int TicketPrice { get; set; }
        public int Total { get; set; }
        public int Amount { get; set; }
    }
}
