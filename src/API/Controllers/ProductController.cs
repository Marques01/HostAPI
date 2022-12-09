using API.Utils;
using BLL.Models;
using BLL.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]

    public class ProductController : Controller
    {
        private IUnitOfWork _uof;

        public ProductController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet]
        public async Task<ActionResult> Products()
        {
            var products = await _uof.ProductRepository.GetProductsAsync();

			return Ok(products);
		}

        [HttpGet]
        [Route("name")]
        public async Task<ActionResult<IEnumerable<Product>>> GetByName([FromQuery] string name)
        {
            var products = await _uof.ProductRepository.GetByNameAsync(name);

			return Ok(products);
		}

        [HttpGet]
        [Route("price")]
        public async Task<ActionResult<IEnumerable<Product>>> GetByPricing(decimal price)
        {
            var products = await _uof.ProductRepository.GetByPricingAsync(price);

            return Ok(products);
        }

        [HttpGet]
        [Route("category")]
        public async Task<ActionResult<IEnumerable<Product>>> GetByCategory(int id)
        {
            var products = await _uof.ProductRepository.GetByCategoryAsync(id);

            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Product product)
        {
            await _uof.ProductRepository.CreateAsync(product);

            await _uof.CommitAsync();

            return Ok(product);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Product product)
        {
            _uof.ProductRepository.Update(product);

            await _uof.CommitAsync();

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _uof.ProductRepository.GetByIdAsync(id);

            _uof.ProductRepository.Delete(product);

            await _uof.CommitAsync();

            return Ok(product);
        }

        [HttpPost]
        [Route("image")]
        public async Task<ActionResult> UploadImage([FromForm] IFormFile files)
        {
            if (files is not null)
            {
                ImageUtils imageUtils = new();

                await imageUtils.CopyImageToFolder(files);
            }            

            return Ok();
        }
    }
}
