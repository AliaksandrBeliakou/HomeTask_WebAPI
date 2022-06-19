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

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService ?? throw new ArgumentNullException(nameof(categoriesService));
        }

		[HttpGet]
		public IEnumerable<CategoryVM> Get()
		{
			return categoriesService.GetCategories();
		}

		[HttpGet("{id}")]
		public IActionResult Category(int id)
		{
			var category = categoriesService.GetCategory(id);
			return Ok(category);
		}

		[HttpPost]
		public int Post([FromBody] CategoryInsertVM category)
		{
			return categoriesService.Add(category);
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, CategoryUpdateVM category)
		{

			categoriesService.Update(new CategoryVM { Id = id, Name = category.Name, Description = category.Description });
			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			categoriesService.Remove(id);
			return NoContent();
		}
	}
}
