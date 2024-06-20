using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerMotos.Infraestructure.Data;
using TallerMotos.Infraestructure.Models;
using TallerMotos.Infraestructure.Repository.Interfaces;

namespace TallerMotos.Infraestructure.Repository.Implementations
{
	public class RepositoryFactura:IRepositoryFactura
	{
        private readonly TallerMotosContext _context;
        public RepositoryFactura(TallerMotosContext context)
        {
            _context = context;
        }

        public async Task<Factura> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Factura>> ListAsync()
        {
            var collection = await _context.Set<Factura>().ToListAsync();
            return collection;
        }
    }
}
