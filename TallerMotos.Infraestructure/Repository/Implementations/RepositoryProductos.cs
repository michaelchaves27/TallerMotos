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
	public class RepositoryProductos : IRepositoryProductos
	{
		private readonly TallerMotosContext _context;
		public RepositoryProductos(TallerMotosContext context)
		{
			_context = context;
		}
		public async Task<ICollection<Productos>> ListAsync()
		{
			var collection = await _context.Set<Productos>()
			//.Include(x => x.IdcategoriaNavigation)
		    .OrderBy(x => x.IDCategoria)
			.AsNoTracking()
			.ToListAsync();
			return collection;
		}
		public async Task<Productos> FindByIdAsync(int id)
		{
			//var @object=await _context.Set<Productos>().FindAsync(id);
			var @object = await _context.Set<Productos>()
			//.Include(x => x.IdAutorNavigation)
		   .Include(x => x.IDCategoria)
		   .Where(x => x.ID == id)
		   .FirstOrDefaultAsync();
			return @object!;
		}
		public async Task<int> AddAsync(Productos entity, string[] selectedCategorias)
		{
			ActualizarCategorias(selectedCategorias, entity);
			await _context.Set<Productos>().AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity.ID;
		}
		public async Task UpdateAsync(Productos entity, string[] selectedCategorias)
		{
			//entity.IdAutorNavigation = _context.Autor.Find(entity.IdAutor);
			//_context.Attach(entity.IdAutorNavigation);
			ActualizarCategorias(selectedCategorias, entity);
			await _context.SaveChangesAsync();
		}
		private void ActualizarCategorias(string[] selectedCategorias, Productos ProductosToUpdate)
		{
			var listaCategorias = _context.Categoria.ToList();
			var categoriasObject = new List<Categoria>();
			foreach (var item in selectedCategorias)
			{
				categoriasObject.Add(
				listaCategorias.Where(x =>
			   x.Id.ToString() == item).First<Categoria>()
				);
			}
			ProductosToUpdate.IDCategoria = categoriasObject;
		}
		public async Task<ICollection<Productos>> FindByNameAsync(string nombre)
		{
			var collection = await _context
			.Set<Productos>()
		   .Where(p => p.Nombre.Contains(nombre))
		   .ToListAsync();
			return collection;
		}
		public async Task<ICollection<Productos>> GetProductosByCategoria(int idCategoria)
		{
			var collection = await _context.Set<Productos>()
			.Include(c => c.IDCategoria)
			.Where(c => c.IDCategoria.Any(o => o.Id == idCategoria))
			.AsNoTracking()
		   .ToListAsync();
			return collection;
		}
		public Task DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}
	}
}
