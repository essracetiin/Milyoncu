using Microsoft.EntityFrameworkCore;
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
    public class BasketRep<T>: BaseRepository<Basket>,IBasketRep where T : class
    {
        public MilyoncuContext _db;
        public BasketRep(MilyoncuContext db) : base(db)
        {
            _db = db;
        }

        public Basket CreateCategory(Basket basket)
        {
            _db.Set<Basket>().Add(basket);
            return basket;
        }

        public bool DeleteBasketById(int basketId)
        {
            Set().Remove(Find(basketId));
            return true;
        }

        public Basket DeleteCategory(Basket basket)
        {
            _db.Set<Basket>().Remove(basket);
            return basket;
        }


        //IEnumerable<Basket> IBasketRep.GetBaskets => GetBaskets();

        public IEnumerable<Basket> GetBaskets()
        {
            return _db.Baskets.Include(r => r.User).Include(x => x.Tickets).ToList();
        }

        public Basket UpdateCategory(Basket basket)
        {
            _db.Set<Basket>().Update(basket);
            return basket;
        }

        Basket IBasketRep.GetBasketByUserId(int UserId)
        {
            return _db.Baskets.Include(r => r.User).Include(t => t.Tickets).Include(w => w.User.Wallet).FirstOrDefault(u => u.UserId == UserId);
        }
        public BasketDTO ConfirmBasket(int userId,int ticketId)
        {
            var basket = _db.Baskets.Include(n => n.Tickets).Include(h => h.User.Wallet).FirstOrDefault(f => f.UserId == userId);
            var quant = _db.Tickets.Include(s => s.Event).FirstOrDefault(e => e.Id == ticketId);
            basket.Completed = true;
            basket.Tickets.ToList().ForEach(item => item.Completed = true);
            

            
           
            if (basket.Completed == true)
            {
                //var bilets = basket.Tickets.ToList();
                // foreach (var tick in bilets)
                // {
                //     var query = (from t in _db.Tickets
                //                  join e in _db.Events
                //                  on t.EventId equals e.Id
                //                  select new
                //                  {
                //                      t.EventId,
                //                      e.Id,
                //                  }
                //         );

                // }
                var sayac = quant.Event.TicketQuantity++;
                var bakiye = basket.User.Wallet.Amount - basket.TotalPrice;
                basket.User.Wallet.Amount = bakiye;
                
                
            }
            
            
            _db.Baskets.Entry(basket).State = EntityState.Modified; //basket entitysinde değişiklik yapıldığı bilgisini yolluyor.
            _db.SaveChanges();
            BasketDTO basketdto = new BasketDTO();
            basketdto.Message = "Sepetiniz Onaylanmıştır.";
            basketdto.Error = false;
            return basketdto;
            
        }

       
    }
}
