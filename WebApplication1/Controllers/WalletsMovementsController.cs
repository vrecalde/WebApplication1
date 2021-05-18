using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Contexts;
using WebApplication1.Utils;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletsMovementsController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private Utils.Utils utils = null;

        public WalletsMovementsController(ApplicationDBContext context)
        {
            this.context = context;
            utils = new Utils.Utils(context);
        }

        [HttpPost]
        public ActionResult Post([FromBody] WalletsMoves walletMove)
        {

            var resp = "";
            //if this is a credit operation
            if (walletMove.debit == 0 && walletMove.credit > 0) {
                resp = utils.creditAmount(walletMove);
            }
            //if this is a debit operation
            else if (walletMove.debit > 0 && walletMove.credit == 0)
            {
                resp = utils.debitAmount(walletMove);
            }
            if (resp == "Ok")
                return new CreatedAtRouteResult("ObtenerWalletMoves", new { id = walletMove.id }, walletMove);
            else
                return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult<List<WalletsMoves>> Get(int id)
        {
            List<WalletsMoves> walletMoves = context.WalletsMovements.Where(x=> x.walletId == id).ToList();

            if (walletMoves == null)
            {
                //return NotFound();
            }

            return walletMoves;

        }

        [HttpPost("Transfer")]
        public ActionResult Post([FromBody] Transfer transfer)
        {

            

            WalletsMoves walletMoveFrom = new WalletsMoves();
            walletMoveFrom.walletId = transfer.fromWallet;
            walletMoveFrom.debit = transfer.amount;
            walletMoveFrom.credit = 0;
            var resp = utils.debitAmount(walletMoveFrom);


            WalletsMoves walletMoveTo = new WalletsMoves();
            walletMoveTo.walletId = transfer.toWallet;
            walletMoveTo.debit = 0;
            walletMoveTo.credit = transfer.amount;
            resp = utils.creditAmount(walletMoveTo);



            context.SaveChanges();
            return Ok();
        }

    }
}
