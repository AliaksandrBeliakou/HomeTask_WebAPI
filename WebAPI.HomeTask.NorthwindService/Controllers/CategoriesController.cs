using Microsoft.AspNetCore.Mvc;
using WebAPI.HomeTask.NorthwindService.Data;
using WebAPI.HomeTask.NorthwindService.Data.Entities;
using WebAPI.HomeTask.NorthwindService.DataTransferObjects;

namespace WebAPI.HomeTask.NorthwindService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly NorthwindContext context;

        public CategoriesController(NorthwindContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return context.Categories;
        }

        [HttpGet("{id}")]
        public IActionResult Category(int id)
        {
            var category = context.Categories.Find(id);
            if (category == null)
            {
                return NotFound("Category is not exist");
            }

            return Ok(category);
        }

        [HttpPost]
        public int Post([FromBody] Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return category.CategoryId;
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CategoryUpdateDto categoryDTO)
        {
            var category = context.Categories.Find(id);
            if (category == null)
            {
                return NotFound("Category is not exist");
            }

            category.CategoryName = categoryDTO.CategoryName;
            category.Description = categoryDTO.Description;
            context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = context.Categories.Find(id);
            if (category == null)
            {
                return NotFound("Category is not exist");
            }

            context.Categories.Remove(category);
            context.SaveChanges();
            return NoContent();
        }
    }
}
