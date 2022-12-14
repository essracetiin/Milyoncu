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
        public string Mail { get; set; }
        public string Role { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public string Password { get; set; }
        public User ?User { get; set; }

        public User Map()
        {
            User user = new User();
            user.Id = Id;
            user.Mail = Mail;
            user.Password = Password;
            user.Role = Role;
            return user;
        }
    }
}
