using BLL.Models;
using BLL.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "Admin")]
    public class GameCapacityController : Controller
    {
        private IUnitOfWork _uof;

        public GameCapacityController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var gameCapacity = await _uof.GameCapacityRepository.GetByIdAsync(id);

            return Ok(gameCapacity);
        }

        [HttpGet]
        [Route("game")]
        public async Task<ActionResult> Game([FromQuery] int id)
        {
            var games = await _uof.GameCapacityRepository.GetByGameIdAsync(id);

            return Ok(games);
        }

        [HttpGet]
        [Route("slot")]
        public async Task<ActionResult> Capacity([FromQuery] int id)
        {
            var capacities = await _uof.GameCapacityRepository.GetByCapacityAsync(id);

            return Ok(capacities);
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult> GetAll()
        {
            var gameCapacities = await _uof.GameCapacityRepository.GetAllGameCapacitiesAsync();

            return Ok(gameCapacities);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] GameCapacity gameCapacity)
        {
            await _uof.GameCapacityRepository.CreateAsync(gameCapacity);

            await _uof.CommitAsync();

            return Ok(gameCapacity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] GameCapacity gameCapacity)
        {
            await _uof.GameCapacityRepository.UpdateAsync(gameCapacity);

            await _uof.CommitAsync();

            return Ok(gameCapacity);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] GameCapacity gameCapacity)
        {
            await _uof.GameCapacityRepository.DeleteAsync(gameCapacity);

            await _uof.CommitAsync();

            return Ok(gameCapacity);
        }
    }
}
