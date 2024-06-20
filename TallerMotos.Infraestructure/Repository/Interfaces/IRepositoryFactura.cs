using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerMotos.Infraestructure.Models;

namespace TallerMotos.Infraestructure.Repository.Interfaces
{
	public interface IRepositoryFactura
	{
        Task<ICollection<Factura>> ListAsync();
        Task<Factura> FindByIdAsync(int id);
    }
}
