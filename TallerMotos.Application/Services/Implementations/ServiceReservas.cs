﻿using AutoMapper;
using TallerMotos.Application.DTO;
using TallerMotos.Application.Services.Interfaces;
using TallerMotos.Infraestructure.Models;
using TallerMotos.Infraestructure.Repository.Interfaces;

namespace TallerMotos.Application.Services.Implementations
{
    public class ServiceReservas : IServiceReservas
    {
        private readonly IRepositoryReservas _repository;
        private readonly IMapper _mapper;
        public ServiceReservas(IRepositoryReservas repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ReservasDTO> FindByIdAsync(int id)
        {
            var @object = await _repository.FindByIdAsync(id);
            var objectMapped = _mapper.Map<ReservasDTO>(@object);
            return objectMapped;
        }

        public async Task<ICollection<ReservasDTO>> ListAsync()
        {

            var list = await _repository.ListAsync();

            var collection = _mapper.Map<ICollection<ReservasDTO>>(list);
            // Return lista
            return collection;
        }

        public async Task<ICollection<ReservasDTO>> ListBySucursalAsync(int idSucursal)
        {
            var list = await _repository.ListBySucursalAsync(idSucursal);
            var collection = _mapper.Map<ICollection<ReservasDTO>>(list);
            return collection;
        }

        public async Task<int> AddAsync(ReservasDTO dto)
        {
            var objectMapped = _mapper.Map<Reservas>(dto);
            return await _repository.AddAsync(objectMapped);
        }

    }
}
