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
    public class RepositoryReservas : IRepositoryReservas
    {
        private readonly TallerMotosContext _context;
        public RepositoryReservas(TallerMotosContext context)
        {
            _context = context;
        }
        public Task<Reservas> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Reservas>> ListAsync()
        {
            var collection = await _context.Set<Reservas>().ToListAsync();
            return collection;
        }
    }
}
