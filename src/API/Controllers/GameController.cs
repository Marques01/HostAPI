using BLL.Models;
using BLL.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private IUnitOfWork _uof;

        public GameController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var game = await _uof.GameRepository.GetByIdAsync(id);

            return Ok(game);
        }

        [HttpGet]
        [Route("name")]
        public async Task<ActionResult> Name([FromQuery] string name)
        {
            var game = await _uof.GameRepository.GetByNameAsync(name);

            return Ok(game);
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult> GetAll()
        {
            var games = await _uof.GameRepository.GetAllGamesAsync();

            return Ok(games);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Game game)
        {
            await _uof.GameRepository.CreateAsync(game);

            await _uof.CommitAsync();

            return Ok(game);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] Game game)
        {
            var _game = await _uof.GameRepository.GetByNameAsync(game.Name);

            if (_game.Name.Equals(game.Name))
                throw new Exception("Já existe um game com esse nome");

            await _uof.GameRepository.UpdateAsync(game);

            await _uof.CommitAsync();

            return Ok(game);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] Game game)
        {
            await _uof.GameRepository.DeleteAsync(game);

            await _uof.CommitAsync();

            return Ok(game);
        }
    }
}
