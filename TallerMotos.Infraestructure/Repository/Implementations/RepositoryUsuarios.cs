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

        public async Task<Usuarios> LoginAsync(string id, string password)
        {
            var @object = await _context.Set<Usuarios>()
                                        .Include(b => b.IdrolNavigation)
                                        .Where(p => p.Correo == id && p.Contrasenna.ToString() == password)
                                        .FirstOrDefaultAsync();
            return @object!;
        }
        public async Task<string> AddAsync(Usuarios entity)
        {
            await _context.Set<Usuarios>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Correo;
        }

        public async Task UpdateAsync(Usuarios entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

    }
}
