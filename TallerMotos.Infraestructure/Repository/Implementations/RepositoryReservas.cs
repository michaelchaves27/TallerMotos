﻿using Microsoft.EntityFrameworkCore;
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
        public async Task<Reservas> FindByIdAsync(int id)
        {
            //var @object=await _context.Set<Reservas>().FindAsync(id);
            var @object = await _context.Set<Reservas>()
           .Include(x => x.IdservicioNavigation)
           .Include(x => x.IdsucursalNavigation)
           .Include(x => x.IdusuarioNavigation)
           .OrderByDescending(x => x.Dia)
           .Where(x => x.ID == id)
           .FirstOrDefaultAsync();
            return @object!;
        }

        public async Task<ICollection<Reservas>> ListAsync()
        {
            var collection = await _context.Set<Reservas>()
           .Include(x => x.IdservicioNavigation)
           .Include(x => x.IdsucursalNavigation)
           .Include(x => x.IdusuarioNavigation)
           .OrderByDescending(x => x.Dia)
           .ToListAsync();
            return collection;
        }

        public async Task<ICollection<Reservas>> ListBySucursalAsync(int idSucursal)
        {
            var collection = await _context.Set<Reservas>()
                .Include(r => r.IdservicioNavigation)
                .Include(r => r.IdusuarioNavigation)
                .Where(r => r.IDSucursal == idSucursal)
                .ToListAsync();
            return collection;
        }

        public async Task<int> AddAsync(Reservas entity)
        {
            //ActualizarCategorias(selectedCategorias, entity);
            await _context.Set<Reservas>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.ID;
        }

    }
}
