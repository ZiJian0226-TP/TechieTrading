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
    public class TradeOrderItemsController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public TradeOrderItemsController(ApplicationDbContext context)
        public TradeOrderItemsController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/TradeOrderItems
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<TradeOrderItem>>> GetTradeOrderItems()
        public async Task<IActionResult> GetTradeOrderItems()
        {
            //Refactored
            //return await _context.TradeOrderItems.ToListAsync();
            var TradeOrderItems = await _unitOfWork.TradeOrderItems.GetAll();
            return Ok(TradeOrderItems);
        }

        // GET: api/TradeOrderItems/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<TradeOrderItem>> GetTradeOrderItem(int id)
        public async Task<IActionResult> GetTradeOrderItem(int id)
        {
            //Refactored
            //var TradeOrderItem = await _context.TradeOrderItems.FindAsync(id);
            var TradeOrderItem = await _unitOfWork.TradeOrderItems.Get(q => q.Id == id);

            if (TradeOrderItem == null)
            {
                return NotFound();
            }

            //Refactored
            //return TradeOrderItem;
            return Ok(TradeOrderItem);
        }

        // PUT: api/TradeOrderItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTradeOrderItem(int id, TradeOrderItem TradeOrderItem)
        {
            if (id != TradeOrderItem.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(TradeOrderItem).State = EntityState.Modified;
            _unitOfWork.TradeOrderItems.Update(TradeOrderItem);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!TradeOrderItemExists(id))
                if (!await TradeOrderItemExists(id))
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

        // POST: api/TradeOrderItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TradeOrderItem>> PostTradeOrderItem(TradeOrderItem TradeOrderItem)
        {
            //Refactored
            //_context.TradeOrderItems.Add(TradeOrderItem);
            //await _context.SaveChangesAsync();
            await _unitOfWork.TradeOrderItems.Insert(TradeOrderItem);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetTradeOrderItem", new { id = TradeOrderItem.Id }, TradeOrderItem);
        }

        // DELETE: api/TradeOrderItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTradeOrderItem(int id)
        {
            //Refactored
            //var TradeOrderItem = await _context.TradeOrderItems.FindAsync(id);
            var TradeOrderItem = await _unitOfWork.TradeOrderItems.Get(q => q.Id == id);
            if (TradeOrderItem == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.TradeOrderItems.Remove(TradeOrderItem);
            //await _context.SaveChangesAsync();
            await _unitOfWork.TradeOrderItems.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool TradeOrderItemExists(int id)
        private async Task<bool> TradeOrderItemExists(int id)
        {
            //Refactored
            //return _context.TradeOrderItems.Any(e => e.Id == id);
            var TradeOrderItem = await _unitOfWork.TradeOrderItems.Get(q => q.Id == id);
            return TradeOrderItem != null;
        }
    }
}
