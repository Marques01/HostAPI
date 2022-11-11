using BLL.Models;
using BLL.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "Admin")]
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

            if (products.Count() > 0)
                return Ok(products);

            return Ok();
        }

        [HttpGet]
        [Route("name")]
        public async Task<ActionResult<IEnumerable<Product>>> GetByName([FromQuery] string name)
        {
            var products = await _uof.ProductRepository.GetByName(name);

            if (products.Count() > 0)
                return Ok(products);

            return Ok();
        }

        [HttpGet]
        [Route("price")]
        public async Task<ActionResult<IEnumerable<Product>>> GetByPricing(decimal price)
        {
            var products = await _uof.ProductRepository.GetByPricing(price);

            if (products.Count() > 0)
                return Ok(products);

            return Ok();
        }

        [HttpGet]
        [Route("category")]
        public async Task<ActionResult<IEnumerable<Product>>> GetByCategory(int id)
        {
            var products = await _uof.ProductRepository.GetByCategory(id);

            if (products.Count() > 0)
                return Ok(products);

            return Ok();
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

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] Product product)
        {
            _uof.ProductRepository.Delete(product);

            await _uof.CommitAsync();

            return Ok(product);
        }
    }
}
