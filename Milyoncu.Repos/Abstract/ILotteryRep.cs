using Milyoncu.Core;
using Milyoncu.Dal.Migrations;
using Milyoncu.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milyoncu.Repos.Abstract
{
    public interface ILotteryRep : IBaseRepository<Lottery>
    {
        public Lottery CreateLottery(int eventId);
    }
}
