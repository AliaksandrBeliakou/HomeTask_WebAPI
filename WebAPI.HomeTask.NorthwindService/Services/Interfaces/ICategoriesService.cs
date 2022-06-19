using WebAPI.HomeTask.NorthwindService.ViewModels;

namespace WebAPI.HomeTask.NorthwindService.Services.Interfaces
{
	public interface ICategoriesService
	{
		IEnumerable<CategoryVM> GetCategories();
		CategoryVM GetCategory(int id);
		int Add(CategoryInsertVM category);
		void Update(CategoryVM category);
		void Remove(int id);
	}
}
