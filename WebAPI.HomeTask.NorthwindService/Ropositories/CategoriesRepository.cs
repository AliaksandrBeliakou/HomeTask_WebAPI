using WebAPI.HomeTask.NorthwindService.Data;
using WebAPI.HomeTask.NorthwindService.Data.Entities;
using WebAPI.HomeTaskRopositories.Interfaces;

namespace WebAPI.HomeTaskRopositories
{
	public class CategoriesRepository : ICategoriesRepository
	{
		private readonly NorthwindContext context;
		public CategoriesRepository(NorthwindContext context)
		{
			this.context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public void Add(Category category)
		{
			if (category == null)
			{
				throw new ArgumentNullException(nameof(category));

			}
			context.Categories.Add(category);
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			var itemForDeletion = context.Categories.Single(x => x.CategoryId == id);
			context.Categories.Remove(itemForDeletion);
			context.SaveChanges();
		}

		public IEnumerable<Category> GetAll()
		{
			return context.Categories;
		}

		public Category GetById(int id)
		{
			return context.Categories.Single(x => x.CategoryId == id);
		}

		public void Update(Category category)
		{
			if (category is null)
			{
				throw new ArgumentNullException(nameof(category));
			}

			var entity = context.Categories.Single(x => x.CategoryId == category.CategoryId);
			entity.CategoryName = category.CategoryName;
			entity.Description = category.Description;
			context.SaveChanges();
		}
	}
}
