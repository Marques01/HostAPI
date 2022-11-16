using BLL.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class HostController : Controller
    {
        private IUnitOfWork _uof;

        public HostController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult> GetHosts()
        {
            var hosts = await _uof.HostRepository.GetAllHostsAsync();

            return Ok(hosts);
        }

        [HttpGet]
        [Route("name")]
        public async Task<ActionResult> Name([FromQuery] string name)
        {
            var host = await _uof.HostRepository.GetByNameAsync(name);

            return Ok(host);
        }

        [HttpGet]
        [Route("door")]
        public async Task<ActionResult> Door([FromQuery] int door)
        {
            var host = await _uof.HostRepository.GetByDoorAsync(door);

            return Ok(host);
        }

        [HttpGet]
        [Route("status")]
        public async Task<ActionResult> Status([FromQuery] bool status)
        {
            var host = await _uof.HostRepository.GetByStatusAsync(status);

            return Ok(host);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetHost(int id)
        {
            var host = await _uof.HostRepository.GetByIdAsync(id);

            return Ok(host);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] BLL.Models.Host host)
        {
            var _host = await _uof.HostRepository.GetByIdAsync(id);

            if (_host.Name.Equals(host.Name))
                throw new Exception("Já existe um servidor com este nome!");

            await _uof.HostRepository.UpdateAsync(host);
            
            await _uof.CommitAsync();

            return Ok(host);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] BLL.Models.Host host)
        {
            await _uof.HostRepository.CreateHostAsync(host);

            await _uof.CommitAsync();

            return Ok(host);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] BLL.Models.Host host)
        {
            await _uof.HostRepository.DeleteHostAsync(host);

            await _uof.CommitAsync();

            return Ok(host);
        }
    }
}
