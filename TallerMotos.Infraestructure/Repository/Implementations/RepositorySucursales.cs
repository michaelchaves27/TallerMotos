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
               //   .Include(s => s.Reservas)
               .ToListAsync();
            return collection;
        }

        public async Task<int> AddAsync(Sucursales entity, string[] selectedUsuarios)
        {
            actualizarEncargados(entity, selectedUsuarios);
            await _context.Set<Sucursales>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.ID;
        }

        public async Task UpdateAsync(Sucursales entity, string[] selectedUsuarios)
        {
            // Adjuntar la entidad al contexto de Entity Framework
            _context.Entry(entity).State = EntityState.Modified;

            // Guardar los cambios realizados en el contexto de Entity Framework de forma asíncrona
            await _context.SaveChangesAsync();
        }

        private void actualizarEncargados(Sucursales sucursalesUpdate, string[] selectedUsuarios)
        {
            var listaEncargados = _context.Usuarios.ToList();
            var usuariosObject = new List<Usuarios>();
            foreach (var item in selectedUsuarios)
            {
                usuariosObject.Add(
                listaEncargados.Where(x =>
               x.ID.ToString() == item).First<Usuarios>()
                );
            }
            sucursalesUpdate.Usuarios = usuariosObject;
        }

    }
}
