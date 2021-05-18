using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Entities
{
    public class Wallet
    {
        public int id { get; set; }
        public long balance { get; set; }

        public long avg { get; set; }
    }
}
