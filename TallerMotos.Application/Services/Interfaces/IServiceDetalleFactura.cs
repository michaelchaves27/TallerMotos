<<<<<<< HEAD
﻿namespace TallerMotos.Application.Services.Interfaces
{
    internal interface IServiceDetalleFactura
    {
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerMotos.Application.DTO;

namespace TallerMotos.Application.Services.Interfaces
{
	public interface IServiceDetalleFactura
	{
        //Task<ICollection<DetalleFacturaDTO>> ListAsync();
        Task<ICollection<DetalleFacturaDTO>> ListAsync(int id);
>>>>>>> Michael
    }
}
