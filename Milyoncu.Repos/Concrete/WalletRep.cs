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
    public class WalletRep<T> : BaseRepository<Wallet>, IWalletRep where T : class
    {
        public MilyoncuContext _db;

        public WalletRep(MilyoncuContext db) : base(db)
        {
            _db = db;
        }

        public Wallet CreateWallet(Wallet wallet)
        {
            _db.Set<Wallet>().Add(wallet);
            return wallet;
        }

        public Wallet DeleteWallet(Wallet wallet)
        {
            _db.Set<Wallet>().Remove(wallet);
            return wallet;
        }

        public IEnumerable<Wallet> GetWallet()
        {
            return _db.Wallets.ToList();
        }

        public Wallet GetWalletById(int WalletId)
        {
            return _db.Wallets.FirstOrDefault(c => c.Id == WalletId);
        }

        public Wallet UpdateWallet(Wallet wallet)
        {
            _db.Set<Wallet>().Update(wallet);
            return wallet;
        }
    }
}
