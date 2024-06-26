﻿using TallerMotos.Infraestructure.Models;

namespace TallerMotos.Infraestructure.Repository.Interfaces
{
    public interface IRepositorySucursales
    {
        Task<ICollection<Sucursales>> ListAsync();
        Task<Sucursales> FindByIdAsync(int id);
    }
}
