using BLL.Models;
using BLL.Repository.Interfaces;
using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class HostRepository : IHostRepository
    {
        private ApplicationDbContext _context;

        public HostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateHostAsync(Host host)
        {
            try
            {
                await _context.Hosts.AddAsync(host);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Não foi possível cadastrar o host\n{ex.Message}");
            }
            finally
            {
                HostLoggin hostLoggin = new()
                {
                    HostId = host.HostId,
                    Door = host.Door,
                    Enabled = host.Enabled,
                    Name = host.Name,
                };

                await _context.HostLoggins.AddAsync(hostLoggin);
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
                Console.WriteLine($"Não foi possível excluir o host{ex.Message}");
            }
            finally
            {
                HostLoggin hostLoggin = new()
                {
                    HostId = host.HostId,
                    Door = host.Door,
                    Enabled = host.Enabled,
                    Name = host.Name,
                    RemoveAt = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                };

                await _context.HostLoggins.AddAsync(hostLoggin);
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
                Console.WriteLine($"Não foi possível desabilitar o host\n{ex.Message}");
            }
            finally
            {
                HostLoggin hostLoggin = new()
                {
                    HostId = host.HostId,
                    Door = host.Door,
                    Enabled = host.Enabled,
                    Name = host.Name,
                    RemoveAt = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                };

                await _context.HostLoggins.AddAsync(hostLoggin);
            }
        }

        public async Task<IEnumerable<Host>> GetAllHostsAsync()
        {
            try
            {
                var hosts = await _context.Hosts.AsNoTracking().ToListAsync();

                if (hosts != null)
                    return hosts;

                return Enumerable.Empty<Host>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha no método de buscar todos os hosts\n{ex.Message}");
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
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Host> GetByIdAsync(Guid id)
        {
            try
            {
                var host = await _context.Hosts.FirstOrDefaultAsync(x => x.HostId.Equals(id));

                if (host != null)
                    return host;

                return new Host();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<Host> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Host> GetByStatusAsync(bool situation)
        {
            throw new NotImplementedException();
        }

        public Task Update(Host host)
        {
            throw new NotImplementedException();
        }
    }
}
