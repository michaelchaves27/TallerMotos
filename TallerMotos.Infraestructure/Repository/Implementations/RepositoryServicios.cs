using Microsoft.EntityFrameworkCore;
using TallerMotos.Infraestructure.Data;
using TallerMotos.Infraestructure.Models;
using TallerMotos.Infraestructure.Repository.Interfaces;

namespace TallerMotos.Infraestructure.Repository.Implementations
{
    public class RepositoryServicios : IRepositoryServicios
    {
        private readonly TallerMotosContext _context;
        public RepositoryServicios(TallerMotosContext context)
        {
            _context = context;
        }
        public async Task<Servicios> FindByIdAsync(int id)
        {
            //var @object=await _context.Set<Servicios>().FindAsync(id);
            var @object = await _context.Set<Servicios>()
               .Include(s => s.Reservas)
               .Where(x => x.ID == id)
               .FirstOrDefaultAsync();
            return @object!;
        }

        public async Task<ICollection<Servicios>> ListAsync()
        {
            var collection = await _context.Set<Servicios>()
               .Include(s => s.Reservas)
               .ToListAsync();
            return collection;
        }
    }
}
