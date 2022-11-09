using BLL.Models;
using BLL.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CapacityController : Controller
    {
        private IUnitOfWork _uof;

        public CapacityController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var capacity = await _uof.CapacityRepository.GetBydIdAsync(id);

            return Ok(capacity);
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult> GetAll()
        {
            var capacities = await _uof.CapacityRepository.GetAllCapacitiesAsync();

            return Ok(capacities);
        }

        [HttpGet]
        [Route("slots")]
        public async Task<ActionResult> Slots([FromQuery] int slots)
        {
            var capacities = await _uof.CapacityRepository.GetBySlotsAsync(slots);

            return Ok(capacities);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Capacity capacity)
        {
            await _uof.CapacityRepository.CreateAsync(capacity);

            await _uof.CommitAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody] Capacity capacity)
        {
            await _uof.CapacityRepository.UpdateAsync(capacity);

            await _uof.CommitAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] Capacity capacity)
        {
            await _uof.CapacityRepository.DeleteAsync(capacity);

            await _uof.CommitAsync();

            return Ok();
        }

    }
}
