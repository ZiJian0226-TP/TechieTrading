using System.Threading.Tasks;
using TechieTrading.Shared.Domain;
using TechieTrading.Server.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TechieTrading.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public ProductsController(ApplicationDbContext context)
        public ProductsController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Products
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        public async Task<IActionResult> GetProducts()
        {
            //Refactored
            //return await _context.Products.ToListAsync();
            var Products = await _unitOfWork.Products.GetAll();
            return Ok(Products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<Product>> GetProduct(int id)
        public async Task<IActionResult> GetProduct(int id)
        {
            //Refactored
            //var Product = await _context.Products.FindAsync(id);
            var Product = await _unitOfWork.Products.Get(q => q.Id == id);

            if (Product == null)
            {
                return NotFound();
            }

            //Refactored
            //return Product;
            return Ok(Product);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product Product)
        {
            if (id != Product.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(Product).State = EntityState.Modified;
            _unitOfWork.Products.Update(Product);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!ProductExists(id))
                if (!await ProductExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product Product)
        {
            //Refactored
            //_context.Products.Add(Product);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Products.Insert(Product);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetProduct", new { id = Product.Id }, Product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            //Refactored
            //var Product = await _context.Products.FindAsync(id);
            var Product = await _unitOfWork.Products.Get(q => q.Id == id);
            if (Product == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.Products.Remove(Product);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Products.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool ProductExists(int id)
        private async Task<bool> ProductExists(int id)
        {
            //Refactored
            //return _context.Products.Any(e => e.Id == id);
            var Product = await _unitOfWork.Products.Get(q => q.Id == id);
            return Product != null;
        }
    }
}
