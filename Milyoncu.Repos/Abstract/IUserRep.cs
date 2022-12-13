using Milyoncu.Core;
using Milyoncu.Dto;
using Milyoncu.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milyoncu.Repos.Abstract
{
    public interface IUserRep : IBaseRepository<User>
    {
        public IEnumerable<User> GetUsers();
        public User GetUserbyId(int UserId);
        public User CreateUser(User u);
        public User UpdateUser(User u);
        public User DeleteUser(User u);
        
        public bool DeletebyUserId(int UserId);
        public UserDTO Login(string Mail, string Password);
    }
}
