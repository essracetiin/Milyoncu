using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milyoncu.Entity.Concrete;
using Milyoncu.Repos.Abstract;
using Milyoncu.Repos.Concrete;
using Milyoncu.Uow;
using System.Net.Mime;

namespace Milyoncu.API.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IWalletRep _walletRep;
        IUow _uow;
        public WalletController(IWalletRep walletRep, IUow uow)
        {
            _walletRep = walletRep;
            _uow = uow;
        }
        [HttpGet]
        public IActionResult GetWallet()
        {
            var wallets = _walletRep.GetWallet();
            return this.Ok(wallets);
        }
        [HttpGet("GetWalletById")]
        public IActionResult GetWalletById(int WalletId)
        {
            var wallets = _walletRep.GetWalletById(WalletId);
            return this.Ok(wallets);
        }
        [HttpPost]
        public IActionResult Create(Wallet wallet)
        {
            var wallets = _walletRep.CreateWallet(wallet);
            _uow.Commit();
            return this.Ok(wallets);
        }
        [HttpPut]
        public IActionResult Update(Wallet wallet)
        {
            var wallets = _walletRep.UpdateWallet(wallet);
            _uow.Commit();
            return this.Ok(wallets);
        }
        [HttpDelete]
        public IActionResult Delete(Wallet wallet)
        {
            var wallets = _walletRep.DeleteWallet(wallet);
            _uow.Commit();
            return this.Ok(wallets);
        }
        [HttpDelete("{walletId:int}")]
        public IActionResult DeleteWalletById(int walletId)
        {
            _uow._walletRep.DeleteWalletById(walletId);
            _uow.Commit();
            return this.Ok();
        }
    }
}