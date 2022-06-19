using WebAPI.HomeTask.NorthwindService.Data.Entities;

namespace WebAPI.HomeTaskRopositories.Interfaces
{
	public interface IProductsRepository
	{
		IEnumerable<Product> GetAll();
		Product GetById(int id);
		void Add(Product product);
		void Update(Product product);
		void Delete(int id);
	}
}
