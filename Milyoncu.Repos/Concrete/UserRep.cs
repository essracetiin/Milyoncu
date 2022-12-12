using Milyoncu.Core;
using Milyoncu.Dal;
using Milyoncu.Entity.Concrete;
using Milyoncu.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milyoncu.Repos.Concrete
{
    public class UserRep<T> : BaseRepository<User>, IUserRep where T : class
    {
        public MilyoncuContext _db;
        public UserRep(MilyoncuContext db) : base(db)
        {
            _db = db;
        }

        public User CreateUser(User u)
        {
            _db.Set<User>().Add(u);
            return u;
        }

        public bool DeletebyUserId(int UserId)
        {
            Set().Remove(Find(UserId));
            return true;
        }

        public User DeleteUser(User u)
        {
            _db.Set<User>().Remove(u);
            return u;
        }

        public User GetUserbyId(int UserId)
        {
            return _db.Users.FirstOrDefault(u => u.Id == UserId);
        }

        public IEnumerable<User> GetUsers()
        {
            return _db.Users.ToList();
        }

        public User UpdateUser(User u)
        {
            _db.Set<User>().Update(u);
            return u;
        }
    }
}
