using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    
    public class ProductsController :BaseApiController
    {
        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
           // return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            #pragma warning disable CS8604 // Possible null reference argument.
            return await _context.Products.FindAsync(id);
            #pragma warning restore CS8604 // Possible null reference argument.
             //return Ok(product);
        }
    }
}
