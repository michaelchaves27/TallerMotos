﻿using TallerMotos.Infraestructure.Models;

namespace TallerMotos.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryProductos
    {
        Task<ICollection<Productos>> ListAsync();
        Task<Productos> FindByIdAsync(int id);
        Task<int> AddAsync(Productos entity);
        Task UpdateAsync(Productos entity);
        //Task<ICollection<Productos>> GetProductosByCategoria(int IdCategoria);
        Task<ICollection<Productos>> FindByNameAsync(string nombre);
        Task DeleteAsync(int id);
    }
}
