using System.Threading.Tasks;
using TechieTrading.Shared.Domain;
using TechieTrading.Server.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TechieTrading.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public StaffsController(ApplicationDbContext context)
        public StaffsController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Staffs
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<Staff>>> GetStaffs()
        public async Task<IActionResult> GetStaffs()
        {
            //Refactored
            //return await _context.Staffs.ToListAsync();
            var Staffs = await _unitOfWork.Staffs.GetAll();
            return Ok(Staffs);
        }

        // GET: api/Staffs/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<Staff>> GetStaff(int id)
        public async Task<IActionResult> GetStaff(int id)
        {
            //Refactored
            //var Staff = await _context.Staffs.FindAsync(id);
            var Staff = await _unitOfWork.Staffs.Get(q => q.Id == id);

            if (Staff == null)
            {
                return NotFound();
            }

            //Refactored
            //return Staff;
            return Ok(Staff);
        }

        // PUT: api/Staffs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaff(int id, Staff Staff)
        {
            if (id != Staff.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(Staff).State = EntityState.Modified;
            _unitOfWork.Staffs.Update(Staff);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!StaffExists(id))
                if (!await StaffExists(id))
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

        // POST: api/Staffs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Staff>> PostStaff(Staff Staff)
        {
            //Refactored
            //_context.Staffs.Add(Staff);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Staffs.Insert(Staff);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetStaff", new { id = Staff.Id }, Staff);
        }

        // DELETE: api/Staffs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            //Refactored
            //var Staff = await _context.Staffs.FindAsync(id);
            var Staff = await _unitOfWork.Staffs.Get(q => q.Id == id);
            if (Staff == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.Staffs.Remove(Staff);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Staffs.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool StaffExists(int id)
        private async Task<bool> StaffExists(int id)
        {
            //Refactored
            //return _context.Staffs.Any(e => e.Id == id);
            var Staff = await _unitOfWork.Staffs.Get(q => q.Id == id);
            return Staff != null;
        }
    }
}
