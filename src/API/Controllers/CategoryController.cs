using BLL.Models;
using BLL.Repository.Interfaces;
using BLL.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private IUnitOfWork _uof;

        public CategoryController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {
            var categories = await _uof.CategoryRepository.GetCategories();

            if (categories.Count() > 0)
                return Ok(categories);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdCategory(int id)
        {
            var categories = await _uof.CategoryRepository.GetById(id);            

            return Ok(categories);
        }
        [HttpGet]
        [Route("name")]
        public async Task<ActionResult<IEnumerable<Category>>> GetByName([FromQuery] string name)
        {
            var categories = await _uof.CategoryRepository.GetByName(name);

            if (categories.Count() > 0)
                return Ok(categories);

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Category category)
        {
            CategoryValidations categoryValidations = new();

            categoryValidations.Validate(category);

            await _uof.CategoryRepository.Create(category);

            await _uof.CommitAsync();

            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Category category)
        {
            CategoryValidations categoryValidations = new();

            categoryValidations.Validate(category);

            _uof.CategoryRepository.Update(category);

            await _uof.CommitAsync();

            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id, [FromBody] Category category)
        {
            _uof.CategoryRepository.Update(category);

            await _uof.CommitAsync();

            return Ok(category);
        }
    }
}
