using System.Threading.Tasks;
using TechieTrading.Shared.Domain;
using TechieTrading.Server.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TechieTrading.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeOrdersController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public TradeOrdersController(ApplicationDbContext context)
        public TradeOrdersController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/TradeOrders
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<TradeOrder>>> GetTradeOrders()
        public async Task<IActionResult> GetTradeOrders()
        {
            //Refactored
            //return await _context.TradeOrders.ToListAsync();
            var TradeOrders = await _unitOfWork.TradeOrders.GetAll();
            return Ok(TradeOrders);
        }

        // GET: api/TradeOrders/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<TradeOrder>> GetTradeOrder(int id)
        public async Task<IActionResult> GetTradeOrder(int id)
        {
            //Refactored
            //var TradeOrder = await _context.TradeOrders.FindAsync(id);
            var TradeOrder = await _unitOfWork.TradeOrders.Get(q => q.Id == id);

            if (TradeOrder == null)
            {
                return NotFound();
            }

            //Refactored
            //return TradeOrder;
            return Ok(TradeOrder);
        }

        // PUT: api/TradeOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTradeOrder(int id, TradeOrder TradeOrder)
        {
            if (id != TradeOrder.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(TradeOrder).State = EntityState.Modified;
            _unitOfWork.TradeOrders.Update(TradeOrder);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!TradeOrderExists(id))
                if (!await TradeOrderExists(id))
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

        // POST: api/TradeOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TradeOrder>> PostTradeOrder(TradeOrder TradeOrder)
        {
            //Refactored
            //_context.TradeOrders.Add(TradeOrder);
            //await _context.SaveChangesAsync();
            await _unitOfWork.TradeOrders.Insert(TradeOrder);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetTradeOrder", new { id = TradeOrder.Id }, TradeOrder);
        }

        // DELETE: api/TradeOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTradeOrder(int id)
        {
            //Refactored
            //var TradeOrder = await _context.TradeOrders.FindAsync(id);
            var TradeOrder = await _unitOfWork.TradeOrders.Get(q => q.Id == id);
            if (TradeOrder == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.TradeOrders.Remove(TradeOrder);
            //await _context.SaveChangesAsync();
            await _unitOfWork.TradeOrders.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool TradeOrderExists(int id)
        private async Task<bool> TradeOrderExists(int id)
        {
            //Refactored
            //return _context.TradeOrders.Any(e => e.Id == id);
            var TradeOrder = await _unitOfWork.TradeOrders.Get(q => q.Id == id);
            return TradeOrder != null;
        }
    }
}
