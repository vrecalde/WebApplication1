using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Entities
{
    public class WalletsMoves
    {
        public int id { get; set; }
        public int walletId { get; set; }
        public long debit { get; set; }
        public long credit { get; set; }
    }
}
