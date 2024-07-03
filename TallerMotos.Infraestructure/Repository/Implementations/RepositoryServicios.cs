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

        public async Task<int> AddAsync(Servicios entity)
        {
            await _context.Set<Servicios>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.ID;
        }
        //public async Task UpdateAsync(Servicios entity)
        //{
        //    entity.IdAutorNavigation = _context.Autor.Find(entity.IdAutor);
        //    //_context.Attach(entity.IdAutorNavigation);
        //    await _context.SaveChangesAsync();
        //}

        public async Task UpdateAsync(Servicios entity)
        {
            // Adjuntar la entidad al contexto de Entity Framework
            _context.Entry(entity).State = EntityState.Modified;

            // Guardar los cambios realizados en el contexto de Entity Framework de forma asíncrona
            await _context.SaveChangesAsync();
        }

    }
}
