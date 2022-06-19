using Microsoft.EntityFrameworkCore;
using WebAPI.HomeTask.NorthwindService.Data;
using WebAPI.HomeTask.NorthwindService.Data.Entities;
using WebAPI.HomeTaskRopositories.Interfaces;

namespace WebAPI.HomeTaskRopositories
{
	public class ProductsRepository : IProductsRepository
	{
		private readonly NorthwindContext context;
		public ProductsRepository(NorthwindContext context)
		{
			this.context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public void Update(Product product)
		{
			if (product is null)
			{
				throw new ArgumentNullException(nameof(product));
			}

			var productEntity = context.Products.Single(x => x.ProductId == product.ProductId);

			productEntity.ProductName = product.ProductName;
			productEntity.CategoryID = product.CategoryID;
			productEntity.SupplierID = product.SupplierID;
			productEntity.QuantityPerUnit = product.QuantityPerUnit;
			productEntity.UnitPrice = product.UnitPrice;
			productEntity.UnitsInStock = product.UnitsInStock;
			productEntity.UnitsOnOrder = product.UnitsOnOrder;
			productEntity.ReorderLevel = product.ReorderLevel;
			productEntity.Discontinued = product.Discontinued;
			context.SaveChanges();
		}

		public Product GetById(int id)
		{
			return context.Products.Single(p => p.ProductId == id);
		}

		public IEnumerable<Product> GetPage(int pageNumber, int count)
		{
			if (pageNumber < 1)
			{
				throw new ArgumentOutOfRangeException(nameof(pageNumber));
			}

			if (count < 1)
			{
				throw new ArgumentOutOfRangeException(nameof(count));
			}
			
			return context.Products.Skip((pageNumber - 1) * count).Take(count);
		}

		public void Add(Product product)
		{
			if (product == null)
			{
				throw new ArgumentNullException(nameof(product));

			}
			context.Products.Add(product);
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			var itemForDeletion = context.Products.Single(x => x.ProductId == id);
			context.Products.Remove(itemForDeletion);
			context.SaveChanges();
		}

		public IEnumerable<Product> GetAll()
		{
			return context.Products;
		}
	}
}
