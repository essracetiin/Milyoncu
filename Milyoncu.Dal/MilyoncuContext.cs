using Microsoft.EntityFrameworkCore;
using Milyoncu.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milyoncu.Dal
{
    public class MilyoncuContext:DbContext
    {
        public MilyoncuContext(DbContextOptions<MilyoncuContext> db) : base(db)
        {

        }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
    }
}
