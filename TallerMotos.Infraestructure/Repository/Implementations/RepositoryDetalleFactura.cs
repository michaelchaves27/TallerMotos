<<<<<<< HEAD
﻿namespace TallerMotos.Infraestructure.Repository.Implementations
{
    internal class RepositoryDetalleFactura
    {
=======
﻿using Microsoft.EntityFrameworkCore;
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
    public class RepositoryDetalleFactura : IRepositoryDetalleFactura
    {
        private readonly TallerMotosContext _context;
        public RepositoryDetalleFactura(TallerMotosContext context)
        {
            _context = context;
        }
        public async Task<ICollection<DetalleFacturas>> ListAsync(int id)
        {
            var collection = await _context.Set<DetalleFacturas>().Where(x => x.IDFactura == id).ToListAsync();
                
            return collection;
        }

       /* public async Task<ICollection<DetalleFacturas>> ListAsync()
        {
            var collection = await _context.Set<DetalleFacturas>().ToListAsync();
            return collection;
        }*/
>>>>>>> Michael
    }
}
