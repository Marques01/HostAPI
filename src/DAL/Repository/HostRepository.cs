using BLL.Models;
using BLL.Repository.Interfaces;
using DAL.Context;
using DAL.Logger;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class HostRepository : IHostRepository
    {
        private ApplicationDbContext _context;

        private Log Log { get; set; }

        public HostRepository(ApplicationDbContext context)
        {
            _context = context;

            Log = new();
        }

        public async Task CreateHostAsync(Host host)
        {
            try
            {
                await _context.Hosts.AddAsync(host);
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi possível cadastrar o host {ex.Message}";

                await Log.Create(errorMessage, this.GetType().ToString());                
            }            
        }

        public async Task DeleteHostAsync(Host host)
        {
            try
            {
                _context.Hosts.Remove(host);
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi possível excluir o host {ex.Message}";

                Console.WriteLine(errorMessage);

                await Log.Create(errorMessage, this.GetType().ToString());
            }
        }

        public async Task DisableHostAsync(Host host)
        {
            try
            {
                _context.Hosts.Update(host);
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi possível desabilitar o host {ex.Message}";

                Console.WriteLine(errorMessage);

                await Log.Create(errorMessage, this.GetType().ToString());
            }
        }

        public async Task<IEnumerable<Host>> GetAllHostsAsync()
        {
            try
            {
                var hosts = await _context.Hosts.AsNoTracking().OrderBy(x => x.Name).ToListAsync();

                if (hosts != null)
                    return hosts;

                return Enumerable.Empty<Host>();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Falha no método de buscar todos os hosts {ex.Message}";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }

        public async Task<Host> GetByDoorAsync(int door)
        {
            try
            {
                var host = await _context.Hosts.FirstOrDefaultAsync(x => x.Door.Equals(door));

                if (host != null)
                    return host;

                return new Host();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Falha no método de buscar host pela porta {ex.Message}";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }

        public async Task<Host> GetByIdAsync(int id)
        {
            try
            {
                var host = await _context.Hosts.AsNoTracking().FirstOrDefaultAsync(x => x.HostId.Equals(id));

                if (host != null)
                    return host;

                return new Host();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Falha no método de buscar host pelo id {ex.Message}";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }

        public async Task<Host> GetByNameAsync(string name)
        {
            try
            {
                var host = await _context.Hosts.FirstOrDefaultAsync(x => x.Name.Contains(name));

                if (host != null)
                    return host;

                return new Host();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Falha no método de buscar host pelo nome {ex.Message}";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }

        public async Task<IEnumerable<Host>> GetByStatusAsync(bool situation)
        {
            try
            {
                var hosts = await _context.Hosts.AsNoTracking().Where(x => x.Enabled.Equals(situation)).ToListAsync();

                if (hosts != null)
                    return hosts;

                return Enumerable.Empty<Host>();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Falha no método de buscar host pelo status {ex.Message}";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }

        public async Task UpdateAsync(Host host)
        {
            try
            {
                _context.Hosts.Update(host);
            }
            catch (Exception ex)
            {
                string errorMessage = $"Falha no método de atualizar host {ex.Message}";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }
    }
}
