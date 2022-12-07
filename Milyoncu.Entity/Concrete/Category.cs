using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milyoncu.Entity.Concrete
{
    public class Category:BaseTable
    {
        public string CategoryName { get; set; }
        public int EventId { get; set; }
        [ForeignKey("EventId")]
        public ICollection<Event> Events { get; set; }
    }
}
