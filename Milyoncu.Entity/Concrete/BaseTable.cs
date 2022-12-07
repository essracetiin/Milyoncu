using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milyoncu.Entity.Concrete
{
    public class BaseTable
    {
        [Key]
        public int Id { get; set; }
    }
}
