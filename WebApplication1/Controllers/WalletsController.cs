using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Contexts;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class WalletsController : ControllerBase
    {
        private readonly ApplicationDBContext context;

        public WalletsController(ApplicationDBContext context) {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Wallet>> Get() {
            return context.Wallets.ToList();
        }

        [HttpGet("{id}", Name = "ObtenerWallet")]
        public ActionResult<Wallet> Get(int id) {
            var wallet = context.Wallets.FirstOrDefault(x => x.id == id);

            if (wallet == null) {
                return NotFound();
            }

            return wallet;

        }

        [HttpPost]
        public ActionResult Post([FromBody] Wallet wallet) {

            context.Wallets.Add(wallet);
            context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerWallet", new { id = wallet.id }, wallet);
        }

       

        /* [HttpPost]
         public ActionResult Credit([FromBody] Wallet wallet)
         {

             context.Wallets.Add(wallet);
             context.SaveChanges();
             return new CreatedAtRouteResult("ObtenerWallet", new { id = wallet.id }, wallet);
         }
         */
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Wallet value) {

            if (id != value.id) {
                return BadRequest();
            }

            context.Entry(value).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();

        }

       

    }
}
