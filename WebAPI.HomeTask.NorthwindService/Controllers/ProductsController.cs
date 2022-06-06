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
        public IEnumerable<Product> Get([FromQuery] int? categoryId, [FromQuery] int pageNumber = 1, [FromQuery]int productsOnPage = 10)
        {
            if(pageNumber < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number cant be less one.");
            }

            if(productsOnPage < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(productsOnPage), "Product count on page cant be less one.");
            }

            IQueryable<Product> productQuery = context.Products;
            if(categoryId.HasValue)
            {
                productQuery = productQuery.Where(p => p.CategoryID == categoryId);
            }

            productQuery = productQuery.Skip((pageNumber - 1) * productsOnPage).Take(productsOnPage);
            return productQuery;
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
        public int Post([FromBody] Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product.ProductId;
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
