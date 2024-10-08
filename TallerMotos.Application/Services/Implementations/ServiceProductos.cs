﻿using AutoMapper;
using TallerMotos.Application.DTO;
using TallerMotos.Application.Services.Interfaces;
using TallerMotos.Infraestructure.Models;
using TallerMotos.Infraestructure.Repository.Interfaces;

namespace TallerMotos.Application.Services.Implementations
{
    public class ServiceProductos : IServiceProductos
    {
        private readonly IRepositoryProductos _repository;
        private readonly IMapper _mapper;

        public ServiceProductos(IRepositoryProductos repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<ProductosDTO>> ListAsync()
        {
            var list = await _repository.ListAsync();
            var collection = _mapper.Map<ICollection<ProductosDTO>>(list);
            return collection;
        }
        public async Task<ProductosDTO> FindByIdAsync(int id)
        {
            var @object = await _repository.FindByIdAsync(id);
            var objectMapped = _mapper.Map<ProductosDTO>(@object);
            return objectMapped;
        }
        public async Task<int> AddAsync(ProductosDTO dto)
        {
            var objectMapped = _mapper.Map<Productos>(dto);
            return await _repository.AddAsync(objectMapped);
        }

        public async Task UpdateAsync(ProductosDTO dto)
        {
            var @object = await _repository.FindByIdAsync(dto.ID);
            var entity = _mapper.Map(dto, @object!);


            await _repository.UpdateAsync(entity);
        }
        public async Task<ICollection<ProductosDTO>> FindByNameAsync(string nombre)
        {
            var list = await _repository.FindByNameAsync(nombre);

            var collection = _mapper.Map<ICollection<ProductosDTO>>(list);

            return collection;
        }

        /*public async Task<ICollection<ProductosDTO>> GetProductosByCategoria(int IdCategoria)
		{
			var list = await _repository.GetProductosByCategoria(IdCategoria);
			var collection = _mapper.Map<ICollection<ProductosDTO>>(list);
			return collection;
		}*/
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }


    }
}
