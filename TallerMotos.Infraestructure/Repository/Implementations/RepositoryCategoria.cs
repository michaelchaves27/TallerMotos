using Microsoft.EntityFrameworkCore;
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
	public class RepositoryCategoria : IRepositoryCategoria
	{
		private readonly TallerMotosContext _context;
		//Alt+Enter
		public RepositoryCategoria(TallerMotosContext context)
		{
			_context = context;
		}

		public async Task<Categoria> FindByIdAsync(int id)
		{
			var @object = await _context.Set<Categoria>().FindAsync(id);

			return @object!;
		}

		public async Task<ICollection<Categoria>> ListAsync()
		{
			var collection = await _context.Set<Categoria>().AsNoTracking().ToListAsync();
			return collection;
		}
	}
}
