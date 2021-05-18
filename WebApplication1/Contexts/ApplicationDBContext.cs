using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;

namespace WebApplication1.Contexts
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options) 
        { 
            
        }

        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletsMoves> WalletsMovements { get; set; }

    }
}
