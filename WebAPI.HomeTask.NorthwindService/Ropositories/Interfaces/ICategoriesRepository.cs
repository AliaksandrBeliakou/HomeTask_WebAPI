using WebAPI.HomeTask.NorthwindService.Data.Entities;

namespace WebAPI.HomeTaskRopositories.Interfaces
{
	public interface ICategoriesRepository
	{
		IEnumerable<Category> GetAll();
		Category GetById(int id);
		void Add (Category category);
		void Update (Category category);
		void Delete (int id);
	}
}
