using Microsoft.EntityFrameworkCore;
using TallerMotos.Infraestructure.Data;
using TallerMotos.Infraestructure.Models;
using TallerMotos.Infraestructure.Repository.Interfaces;

namespace TallerMotos.Infraestructure.Repository.Implementations
{
    public class RepositoryReservas : IRepositoryReservas
    {
        private readonly TallerMotosContext _context;
        public RepositoryReservas(TallerMotosContext context)
        {
            _context = context;
        }
        public async Task<Reservas> FindByIdAsync(int id)
        {
            //var @object=await _context.Set<Reservas>().FindAsync(id);
            var @object = await _context.Set<Reservas>()
           .Include(x => x.IdservicioNavigation)
           .Include(x => x.IdsucursalNavigation)
           .Include(x => x.IdusuarioNavigation)
           .Where(x => x.ID == id)
           .FirstOrDefaultAsync();
            return @object!;
        }

        public async Task<ICollection<Reservas>> ListAsync()
        {
            var collection = await _context.Set<Reservas>()
           .Include(x => x.IdservicioNavigation)
           .Include(x => x.IdsucursalNavigation)
           .Include(x => x.IdusuarioNavigation)
           .ToListAsync();
            return collection;
        }
    }
}
