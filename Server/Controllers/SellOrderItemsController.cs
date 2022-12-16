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
    public class SellOrderItemsController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public SellOrderItemsController(ApplicationDbContext context)
        public SellOrderItemsController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/SellOrderItems
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<SellOrderItem>>> GetSellOrderItems()
        public async Task<IActionResult> GetSellOrderItems()
        {
            //Refactored
            //return await _context.SellOrderItems.ToListAsync();
            var SellOrderItems = await _unitOfWork.SellOrderItems.GetAll();
            return Ok(SellOrderItems);
        }

        // GET: api/SellOrderItems/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<SellOrderItem>> GetSellOrderItem(int id)
        public async Task<IActionResult> GetSellOrderItem(int id)
        {
            //Refactored
            //var SellOrderItem = await _context.SellOrderItems.FindAsync(id);
            var SellOrderItem = await _unitOfWork.SellOrderItems.Get(q => q.Id == id);

            if (SellOrderItem == null)
            {
                return NotFound();
            }

            //Refactored
            //return SellOrderItem;
            return Ok(SellOrderItem);
        }

        // PUT: api/SellOrderItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSellOrderItem(int id, SellOrderItem SellOrderItem)
        {
            if (id != SellOrderItem.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(SellOrderItem).State = EntityState.Modified;
            _unitOfWork.SellOrderItems.Update(SellOrderItem);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!SellOrderItemExists(id))
                if (!await SellOrderItemExists(id))
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

        // POST: api/SellOrderItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SellOrderItem>> PostSellOrderItem(SellOrderItem SellOrderItem)
        {
            //Refactored
            //_context.SellOrderItems.Add(SellOrderItem);
            //await _context.SaveChangesAsync();
            await _unitOfWork.SellOrderItems.Insert(SellOrderItem);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetSellOrderItem", new { id = SellOrderItem.Id }, SellOrderItem);
        }

        // DELETE: api/SellOrderItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSellOrderItem(int id)
        {
            //Refactored
            //var SellOrderItem = await _context.SellOrderItems.FindAsync(id);
            var SellOrderItem = await _unitOfWork.SellOrderItems.Get(q => q.Id == id);
            if (SellOrderItem == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.SellOrderItems.Remove(SellOrderItem);
            //await _context.SaveChangesAsync();
            await _unitOfWork.SellOrderItems.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool SellOrderItemExists(int id)
        private async Task<bool> SellOrderItemExists(int id)
        {
            //Refactored
            //return _context.SellOrderItems.Any(e => e.Id == id);
            var SellOrderItem = await _unitOfWork.SellOrderItems.Get(q => q.Id == id);
            return SellOrderItem != null;
        }
    }
}
