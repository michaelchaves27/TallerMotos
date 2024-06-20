using Microsoft.EntityFrameworkCore;
using TallerMotos.Infraestructure.Data;
using TallerMotos.Infraestructure.Models;
using TallerMotos.Infraestructure.Repository.Interfaces;

namespace TallerMotos.Infraestructure.Repository.Implementations
{
    public class RepositoryDetalleFactura : IRepositoryDetalleFactura
    {
        private readonly TallerMotosContext _context;
        public RepositoryDetalleFactura(TallerMotosContext context)
        {
            _context = context;
        }

        public async Task<DetalleFactura> FindByIdAsync(int id)
        {
            //var @object=await _context.Set<Facturas>().FindAsync(id);
            var @object = await _context.Set<DetalleFactura>()
           //.Include(x => x.IdsucursalNavigation)
           .Include(x => x.IdfacturaNavigation)
           .ThenInclude(f => f.IdsucursalNavigation)
           .Include(x => x.IdfacturaNavigation)
           .ThenInclude(d => d.IdusuarioNavigation)
           .Where(x => x.ID == id)
           .FirstOrDefaultAsync();
            return @object!;
        }

        public async Task<ICollection<DetalleFactura>> ListAsync(int id)
        {
            var collection = await _context.Set<DetalleFactura>().Where(x => x.IDFactura == id)
           //.Include(x => x.IdsucursalNavigation)
           .Include(x => x.IdfacturaNavigation)
           .ThenInclude(f => f.IdsucursalNavigation)
           .Include(x => x.IdfacturaNavigation)
           .ThenInclude(d => d.IdusuarioNavigation)
           .ToListAsync();
            return collection;
        }
    }
}
