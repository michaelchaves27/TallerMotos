<<<<<<< HEAD
﻿namespace TallerMotos.Application.Services.Implementations
{
    internal class ServiceDetalleFactura
    {
=======
﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerMotos.Application.DTO;
using TallerMotos.Application.Services.Interfaces;
using TallerMotos.Infraestructure.Models;
using TallerMotos.Infraestructure.Repository.Interfaces;

namespace TallerMotos.Application.Services.Implementations
{
    public class ServiceDetalleFactura : IServiceDetalleFactura
    {
        private readonly IRepositoryDetalleFactura _repository;
        private readonly IMapper _mapper;

        public ServiceDetalleFactura (IRepositoryDetalleFactura repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

       /* public async Task<ICollection<DetalleFacturaDTO>> ListAsync()
        {

            //Obtener datos del repositorio
            var list = await _repository.ListAsync();
            // Map List<Autor> a ICollection<BodegaDTO>
            var collection = _mapper.Map<ICollection<DetalleFacturaDTO>>(list);
            // Return lista
            return collection;
        }*/
        public async Task<ICollection<DetalleFacturaDTO>> ListAsync(int id)
        {

            //Obtener datos del repositorio
            var list = await _repository.ListAsync(id);
            // Map List<Autor> a ICollection<BodegaDTO>
            var collection = _mapper.Map<ICollection<DetalleFacturaDTO>>(list);
            // Return lista
            return collection;

        }
>>>>>>> Michael
    }
}
