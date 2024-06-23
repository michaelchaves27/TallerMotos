using Microsoft.EntityFrameworkCore;
using TallerMotos.Infraestructure.Data;
using TallerMotos.Infraestructure.Models;
using TallerMotos.Infraestructure.Repository.Interfaces;

namespace TallerMotos.Infraestructure.Repository.Implementations
{
    public class RepositorySucursales : IRepositorySucursales
    {
        private readonly TallerMotosContext _context;
        public RepositorySucursales(TallerMotosContext context)
        {
            _context = context;
        }
        public async Task<Sucursales> FindByIdAsync(int id)
        {
            //var @object=await _context.Set<Sucursales>().FindAsync(id);
            var @object = await _context.Set<Sucursales>()
               .Include(s => s.Reservas)
               .Where(x => x.ID == id)
               .FirstOrDefaultAsync();
            return @object!;
        }

        public async Task<ICollection<Sucursales>> ListAsync()
        {
            var collection = await _context.Set<Sucursales>()
               .Include(s => s.Reservas)
               .ToListAsync();
            return collection;
        }
    }
}
