using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechieTrading.Server.Data;
using TechieTrading.Shared.Domain;
using TechieTrading.Server.IRepository;

namespace TechieTrading.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellOrdersController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public SellOrdersController(ApplicationDbContext context)
        public SellOrdersController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/SellOrders
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<SellOrder>>> GetSellOrders()
        public async Task<IActionResult> GetSellOrders()
        {
            //Refactored
            //return await _context.SellOrders.ToListAsync();
            var SellOrders = await _unitOfWork.SellOrders.GetAll();
            return Ok(SellOrders);
        }

        // GET: api/SellOrders/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<SellOrder>> GetSellOrder(int id)
        public async Task<IActionResult> GetSellOrder(int id)
        {
            //Refactored
            //var SellOrder = await _context.SellOrders.FindAsync(id);
            var SellOrder = await _unitOfWork.SellOrders.Get(q => q.Id == id);

            if (SellOrder == null)
            {
                return NotFound();
            }

            //Refactored
            //return SellOrder;
            return Ok(SellOrder);
        }

        // PUT: api/SellOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSellOrder(int id, SellOrder SellOrder)
        {
            if (id != SellOrder.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(SellOrder).State = EntityState.Modified;
            _unitOfWork.SellOrders.Update(SellOrder);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!SellOrderExists(id))
                if (!await SellOrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SellOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SellOrder>> PostSellOrder(SellOrder SellOrder)
        {
            //Refactored
            //_context.SellOrders.Add(SellOrder);
            //await _context.SaveChangesAsync();
            await _unitOfWork.SellOrders.Insert(SellOrder);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetSellOrder", new { id = SellOrder.Id }, SellOrder);
        }

        // DELETE: api/SellOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSellOrder(int id)
        {
            //Refactored
            //var SellOrder = await _context.SellOrders.FindAsync(id);
            var SellOrder = await _unitOfWork.SellOrders.Get(q => q.Id == id);
            if (SellOrder == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.SellOrders.Remove(SellOrder);
            //await _context.SaveChangesAsync();
            await _unitOfWork.SellOrders.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool SellOrderExists(int id)
        private async Task<bool> SellOrderExists(int id)
        {
            //Refactored
            //return _context.SellOrders.Any(e => e.Id == id);
            var SellOrder = await _unitOfWork.SellOrders.Get(q => q.Id == id);
            return SellOrder != null;
        }
    }
}
