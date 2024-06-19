using Microsoft.EntityFrameworkCore;
using TallerMotos.Infraestructure.Data;
using TallerMotos.Infraestructure.Models;
using TallerMotos.Infraestructure.Repository.Interfaces;

namespace TallerMotos.Infraestructure.Repository.Implementations
{
    public class RepositoryFacturas : IRepositoryFacturas
    {
        private readonly TallerMotosContext _context;
        public RepositoryFacturas(TallerMotosContext context)
        {
            _context = context;
        }

        public async Task<Facturas> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Facturas>> ListAsync()
        {
            var collection = await _context.Set<Facturas>().ToListAsync();
            return collection;
        }
    }
}
