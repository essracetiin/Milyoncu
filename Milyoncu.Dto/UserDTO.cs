using Milyoncu.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milyoncu.Dto
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Role { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public bool Error { get; set; }
        public int WalletId { get; set; }
        public string Message { get; set; }

    }
}
