using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milyoncu.Dto
{
    public class BasketDTO : ResponseModel
    {
        public int Id { get; set; }
        public int Total { get; set; }
        public bool Completed { get; set; }
        public int Amount { get; set; }
        
        public List<TicketDTO> Tickets { get; set; }


    }
}
