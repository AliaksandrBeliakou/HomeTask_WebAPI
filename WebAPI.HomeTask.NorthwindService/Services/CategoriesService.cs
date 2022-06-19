using AutoMapper;
using WebAPI.HomeTask.NorthwindService.Data.Entities;
using WebAPI.HomeTask.NorthwindService.Services.Interfaces;
using WebAPI.HomeTask.NorthwindService.ViewModels;
using WebAPI.HomeTaskRopositories.Interfaces;

namespace WebAPI.HomeTaskServices
{
	public class CategoriesService : ICategoriesService
	{
		private readonly ICategoriesRepository categoriesRepository;
		private readonly IMapper mapper;

		public CategoriesService(ICategoriesRepository categoriesRepository, IMapper mapper)
		{
			this.categoriesRepository = categoriesRepository ?? throw new ArgumentNullException(nameof(categoriesRepository));
			this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		public int Add(CategoryInsertVM category)
		{
			var entity = mapper.Map<Category>(category);
			categoriesRepository.Add(entity);
			return entity.CategoryId;
		}

		public IEnumerable<CategoryVM> GetCategories()
		{
			return categoriesRepository.GetAll().Select(c => mapper.Map<CategoryVM>(c));
		}

		public CategoryVM GetCategory(int id)
		{
			var category = categoriesRepository.GetById(id);
			return mapper.Map<CategoryVM>(category);
		}

		public void Remove(int id)
		{
			categoriesRepository.Delete(id);
		}

		public void Update(CategoryVM category)
		{
			categoriesRepository.Update(mapper.Map<Category>(category));
		}
	}
}
