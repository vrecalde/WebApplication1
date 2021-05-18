using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Contexts;
using WebApplication1.Entities;

namespace WebApplication1.Utils
{
    public class Utils
    {
        private readonly ApplicationDBContext context;

        public Utils() { 
        }

        public Utils(ApplicationDBContext context)
        {
            this.context = context;
        }

        public string creditAmount(WalletsMoves walletMove) {

            context.WalletsMovements.Add(walletMove);

            var wallet = context.Wallets.FirstOrDefault(x => x.id == walletMove.walletId);
            //it affects the balance and the avg
            wallet.balance = wallet.balance + walletMove.credit;
            var balancesWalletMovmts = (from w in context.WalletsMovements where w.walletId == wallet.id select w.id).ToList();
            //var sumBalances = balancesWalletMovmts.Sum();
            var countBalances = balancesWalletMovmts.Count() + 1;
            wallet.avg = wallet.balance / countBalances;
            context.Entry(wallet).State = EntityState.Modified;
            context.SaveChanges();
            return "Ok";
        }

        public string debitAmount(WalletsMoves walletMove)
        {

            context.WalletsMovements.Add(walletMove);

            var wallet = context.Wallets.FirstOrDefault(x => x.id == walletMove.walletId);
            //it affects the balance and the avg
            wallet.balance = wallet.balance - walletMove.debit;
            var balancesWalletMovmts = (from w in context.WalletsMovements where w.walletId == wallet.id select w.id).ToList();
            //var sumBalances = balancesWalletMovmts.Sum();
            var countBalances = balancesWalletMovmts.Count() + 1;
            wallet.avg = wallet.balance / countBalances;
            context.Entry(wallet).State = EntityState.Modified;
            context.SaveChanges();
            return "Ok";
        }



    }
}
