using Milyoncu.Core;
using Milyoncu.Dal;
using Milyoncu.Dto;
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

        public UserDTO CreateUser(UserDTO u)
        {
            var duplicateControl = _db.Users.FirstOrDefault(c => c.Mail == u.Mail);
            if (duplicateControl != null)
            {
                u.Error = true;
                u.Message = "Bu mail adresi kayıtlıdır.";
                return u;
            }
            else
            {
                u.Error = false;
                u.Message = "Kayıt Başarıyla Oluşturuldu";
            }
            Wallet wallet = new Wallet()
            {
                Amount = 0
            };
            _db.Wallets.Add(wallet);
            _db.SaveChanges();
            User user = new User()
            {
                UserName = u.UserName,
                Name = u.Name,
                SurName = u.SurName,
                Role = u.Role,
                Mail = u.Mail,
                Password = BCrypt.Net.BCrypt.HashPassword(u.Password),
                Error = u.Error,
                WalletId = wallet.Id

            };
            _db.Users.Add(user);
            _db.SaveChanges();
            Basket basket = new Basket()
            {
                UserId = user.Id,
                TotalPrice=0,
                Completed=false,
            };
            _db.Baskets.Add(basket);
            _db.SaveChanges();
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

        public UserDTO Login(string Mail, string Password)
        {
            User selectedUser = _db.Set<User>().FirstOrDefault(x => x.Mail == Mail);
            UserDTO user = new UserDTO();
            user.Mail = Mail;
            if (selectedUser != null)
            {
                user.Error = false;
                bool verified = BCrypt.Net.BCrypt.Verify(Password, selectedUser.Password);
                if (verified == true)
                {
                    user.Role = selectedUser.Role;
                    user.Id = selectedUser.Id;
                    user.Error = false;
                }
                else user.Error = true;
            }
            else user.Error = true;
            return user;
        }

        public User UpdateUser(User u)
        {
            _db.Set<User>().Update(u);
            return u;
        }
    }
}
