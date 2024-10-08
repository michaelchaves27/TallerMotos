﻿using TallerMotos.Infraestructure.Models;

namespace TallerMotos.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryServicios
    {
        Task<ICollection<Servicios>> ListAsync();
        Task<Servicios> FindByIdAsync(int id);
        Task<int> AddAsync(Servicios entity);
        Task UpdateAsync(Servicios entity);
    }
}
