using Microsoft.EntityFrameworkCore;
using TallerMotos.Infraestructure.Data;
using TallerMotos.Infraestructure.Models;
using TallerMotos.Infraestructure.Repository.Interfaces;

namespace TallerMotos.Infraestructure.Repository.Implementations
{
    public class RepositoryUsuarios : IRepositoryUsuarios
    {
        private readonly TallerMotosContext _context;
        public RepositoryUsuarios(TallerMotosContext context)
        {
            _context = context;
        }
        public async Task<Usuarios> FindByIdAsync(int id)
        {
            //var @object=await _context.Set<Usuarios>().FindAsync(id);
            var @object = await _context.Set<Usuarios>()
           .Include(x => x.IdrolNavigation)
           .Where(x => x.ID == id)
           .FirstOrDefaultAsync();
            return @object!;
        }

        public async Task<ICollection<Usuarios>> ListAsync()
        {
            var collection = await _context.Set<Usuarios>()
           .Include(x => x.IdrolNavigation)
           .AsNoTracking()
           .ToListAsync();
            return collection;
        }
    }
}
