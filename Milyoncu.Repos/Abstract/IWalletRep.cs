using Milyoncu.Core;
using Milyoncu.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milyoncu.Repos.Abstract
{
    public interface IWalletRep : IBaseRepository<Wallet>
    {
        IEnumerable<Wallet> GetWallet();
        Wallet GetWalletById(int WalletId);
        Wallet CreateWallet(Wallet wallet);
        Wallet UpdateWallet(Wallet wallet);
        Wallet DeleteWallet(Wallet wallet);
    }
}
