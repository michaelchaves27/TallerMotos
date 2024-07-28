using Microsoft.EntityFrameworkCore;
using TallerMotos.Infraestructure.Data;
using TallerMotos.Infraestructure.Models;
using TallerMotos.Infraestructure.Repository.Interfaces;

namespace TallerMotos.Infraestructure.Repository.Implementations
{
    public class RepositoryRol : IRepositoryRol
    {
        private readonly TallerMotosContext _context;
        //Alt+Enter
        public RepositoryRol(TallerMotosContext context)
        {
            _context = context;
        }

        public async Task<Rol> FindByIdAsync(int id)
        {
            var @object = await _context.Set<Rol>().FindAsync(id);

            return @object!;
        }

        public async Task<ICollection<Rol>> ListAsync()
        {
            var collection = await _context.Set<Rol>().AsNoTracking().ToListAsync();
            return collection;
        }
    }
}
