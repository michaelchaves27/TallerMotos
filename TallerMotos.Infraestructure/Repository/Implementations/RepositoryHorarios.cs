using Microsoft.EntityFrameworkCore;
using TallerMotos.Infraestructure.Data;
using TallerMotos.Infraestructure.Models;
using TallerMotos.Infraestructure.Repository.Interfaces;

namespace TallerMotos.Infraestructure.Repository.Implementations
{
    public class RepositoryHorarios : IRepositoryHorarios
    {
        private readonly TallerMotosContext _context;
        public RepositoryHorarios(TallerMotosContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Horarios>> ListAsync()
        {
            var collection = await _context.Set<Horarios>()
               .Include(s => s.IdsucursalesNavigation)
               .OrderBy(x => x.IDSucursal)
               .AsNoTracking()
               .ToListAsync();
            return collection;
        }
        public async Task<Horarios> FindByIdAsync(int id)
        {
            //var @object=await _context.Set<Horarios>().FindAsync(id);
            var @object = await _context.Set<Horarios>()
               .Include(s => s.IdsucursalesNavigation)
               .Where(x => x.ID == id)
               .FirstOrDefaultAsync();
            return @object!;
        }

        public async Task<int> AddAsync(Horarios entity)
        {
            //actualizarCategorias(selectedCategorias, entity);
            await _context.Set<Horarios>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.ID;
        }
        public async Task UpdateAsync(Horarios entity)
        {
            entity.IdsucursalesNavigation = _context.Sucursales.Find(entity.IDSucursal);
            // Adjuntar la entidad al contexto de Entity Framework
            //_context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<List<string>> GetDiasDisponiblesAsync(int sucursalId)
        {
            // Implementa la lógica para obtener los días disponibles de la tabla Horarios
            var diasDisponibles = await _context.Horarios
                .Where(h => h.IDSucursal == sucursalId)
                .Select(h => h.Dia)
                .Distinct()
                .ToListAsync();

            return diasDisponibles;
        }

        public async Task<List<string>> GetHorasDisponiblesAsync(int sucursalId, string dia)
        {
            // Implementar lógica para obtener las horas disponibles para el sucursalId y dia
            // Ejemplo:
            var horarios = await _context.Horarios
                .Where(h => h.IDSucursal == sucursalId && h.Dia == dia)
                .Select(h => h.Hora)
                .ToListAsync();

            return horarios;
        }


    }
}
