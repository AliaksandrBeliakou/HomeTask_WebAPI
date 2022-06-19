using WebAPI.HomeTask.NorthwindService.ViewModels;

namespace WebAPI.HomeTask.NorthwindService.Services.Interfaces
{
	public interface IProductsService
	{
		IEnumerable<ProductVM> GetProducts(int pageNumber, int count);
		IEnumerable<ProductVM> GetProductsByCategory(int categoryId, int pageNumber, int count);
		ProductVM GetProductById(int id);
		int Add(ProductInsertVM product);
		void Update(ProductVM product);
		void Remove(int id);
	}
}
