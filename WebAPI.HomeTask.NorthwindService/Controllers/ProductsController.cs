using Microsoft.AspNetCore.Mvc;
using WebAPI.HomeTask.NorthwindService.Data;
using WebAPI.HomeTask.NorthwindService.Data.Entities;
using WebAPI.HomeTask.NorthwindService.Services.Interfaces;
using WebAPI.HomeTask.NorthwindService.ViewModels;

namespace WebAPI.HomeTask.NorthwindService.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
        }

        [HttpGet]
        public IEnumerable<ProductVM> Get([FromQuery] int? categoryId, [FromQuery] int pageNumber = 1, [FromQuery] int productsOnPage = 10)
        {
            if (pageNumber < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number cant be less one.");
            }

            if (productsOnPage < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(productsOnPage), "Product count on page cant be less one.");
            }
            if (categoryId.HasValue)
            {
                return productsService.GetProductsByCategory(categoryId.Value, pageNumber, productsOnPage);
            }

            return productsService.GetProducts(pageNumber, productsOnPage);
        }

		[HttpGet("{id}")]
		public ProductVM Product(int id)
		{
			return productsService.GetProductById(id);
		}

		[HttpPost]
		public int Post([FromBody] ProductInsertVM product)
		{
			return productsService.Add(product);
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] ProductUpdateVM product)
		{
			productsService.Update(new ProductVM
			{
				Id = id,
				ProductName = product.ProductName,
				CategoryID = product.CategoryID,
				SupplierID = product.SupplierID,
				UnitPrice = product.UnitPrice,
				QuantityPerUnit = product.QuantityPerUnit,
				UnitsOnOrder = product.UnitsOnOrder,
				UnitsInStock = product.UnitsInStock,
				ReorderLevel = product.ReorderLevel,
				Discontinued = product.Discontinued,
			});
			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			productsService.Remove(id);
			return NoContent();
		}
	}
}
