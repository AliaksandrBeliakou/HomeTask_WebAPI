using Microsoft.AspNetCore.Mvc;
using WebAPI.HomeTask.NorthwindService.Data;
using WebAPI.HomeTask.NorthwindService.Data.Entities;
using WebAPI.HomeTask.NorthwindService.DataTransferObjects;

namespace WebAPI.HomeTask.NorthwindService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly NorthwindContext context;

        public ProductsController(NorthwindContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        
        [HttpGet]
        public IEnumerable<Product>Get()
        {
            return context.Products;
        }

        [HttpGet("{id}")]
        public IActionResult Product(int id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return NotFound("Product is not exist");
            }

            return Ok(product);
        }

        [HttpPost]
        public void Post([FromBody] Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductUpdateDto productDTO)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return NotFound("Product is not exist");
            }

            product.ProductName = productDTO.ProductName;
            product.CategoryID = productDTO.CategoryID;
            product.SupplierID = productDTO.SupplierID;
            product.UnitPrice = productDTO.UnitPrice;
            product.QuantityPerUnit = productDTO.QuantityPerUnit;
            product.UnitsOnOrder = productDTO.UnitsOnOrder;
            product.UnitsInStock = productDTO.UnitsInStock;
            product.ReorderLevel = productDTO.ReorderLevel;
            product.Discontinued = productDTO.Discontinued;
            context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return NotFound("Product is not exist");
            }

            context.Products.Remove(product);
            context.SaveChanges();
            return NoContent();
        }
    }
}
