using Microsoft.AspNetCore.Mvc;
using WebAPI.HomeTask.NorthwindService.Data;
using WebAPI.HomeTask.NorthwindService.Services.Interfaces;
using WebAPI.HomeTask.NorthwindService.ViewModels;

namespace WebAPI.HomeTask.NorthwindService.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService categoriesService;
		private readonly ILogger<CategoriesController> logger;

		public CategoriesController(ICategoriesService categoriesService, ILogger<CategoriesController> logger)
		{
			this.categoriesService = categoriesService ?? throw new ArgumentNullException(nameof(categoriesService));
			this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		[HttpGet]
		public IEnumerable<CategoryVM> Get()
		{
			logger.LogInformation("Get all categories");
			return categoriesService.GetCategories();
		}

		[HttpGet("{id}")]
		public IActionResult Category(int id)
		{
			logger.LogInformation($"Get category #{id}");
			var category = categoriesService.GetCategory(id);
			return Ok(category);
		}

		[HttpPost]
		public int Post([FromBody] CategoryInsertVM category)
		{
			logger.LogInformation("Add new category");
			return categoriesService.Add(category);
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, CategoryUpdateVM category)
		{
			logger.LogInformation("Update category");
			categoriesService.Update(new CategoryVM { Id = id, Name = category.Name, Description = category.Description });
			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			logger.LogInformation($"Remove category #{id}");
			categoriesService.Remove(id);
			return NoContent();
		}
	}
}
