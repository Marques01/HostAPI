using BLL.Models;
using BLL.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "Admin")]
    public class HostCapacityController : Controller
    {
        private IUnitOfWork _uof;

        public HostCapacityController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var hostCapacity = await _uof.HostCapacityRepository.GetByIdAsync(id);

            return Ok(hostCapacity);
        }

        [HttpGet]
        [Route("gamecapacity")]
        public async Task<ActionResult> GameCapacityId([FromQuery] int id)
        {
            var hostCapacity = await _uof.HostCapacityRepository.GetByGameCapacityId(id);

            return Ok(hostCapacity);
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult> GetAll()
        {
            var hostCapacities = await _uof.HostCapacityRepository.GetAllHostCapacitiesAsync();

            return Ok(hostCapacities);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] HostCapacity hostCapacity)
        {
            await _uof.HostCapacityRepository.CreateAsync(hostCapacity);

            await _uof.CommitAsync();

            return Ok(hostCapacity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] HostCapacity hostCapacity)
        {
            await _uof.HostCapacityRepository.UpdateAsync(hostCapacity);

            await _uof.CommitAsync();

            return Ok(hostCapacity);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] HostCapacity hostCapacity)
        {
            await _uof.HostCapacityRepository.DeleteAsync(hostCapacity);

            await _uof.CommitAsync();

            return Ok(hostCapacity);
        }
    }
}
