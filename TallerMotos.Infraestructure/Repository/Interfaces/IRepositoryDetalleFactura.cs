using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerMotos.Infraestructure.Models;

namespace TallerMotos.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryDetalleFactura
    {

        //Task<ICollection<DetalleFacturas>> ListAsync();
        Task<ICollection<DetalleFacturas>> ListAsync(int id);
    }
}
