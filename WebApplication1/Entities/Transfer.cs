using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Entities
{
    public class Transfer
    {
        public int id { get; set; }
        public int fromWallet { get; set; }
        public int toWallet { get; set; }
        public long amount { get; set; }
    }
}
