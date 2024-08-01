using Microsoft.EntityFrameworkCore;
using TallerMotos.Infraestructure.Data;
using TallerMotos.Infraestructure.Models;
using TallerMotos.Infraestructure.Repository.Interfaces;

namespace TallerMotos.Infraestructure.Repository.Implementations
{
    public class RepositoryFacturas : IRepositoryFacturas
    {
        private readonly TallerMotosContext _context;
        public RepositoryFacturas(TallerMotosContext context)
        {
            _context = context;
        }

        public async Task<Facturas> FindByIdAsync(int id)
        {
            //var @object=await _context.Set<Facturas>().FindAsync(id);
            var @object = await _context.Set<Facturas>()
           //.Include(x => x.IdsucursalNavigation)
           .Include(x => x.IdusuarioNavigation)
           .OrderByDescending(x => x.Fecha)
           .Where(x => x.ID == id)
           .FirstOrDefaultAsync();
            return @object!;
        }

        public async Task<ICollection<Facturas>> ListAsync()
        {
            var collection = await _context.Set<Facturas>()
           //.Include(x => x.IdsucursalNavigation)
           .Include(x => x.IdusuarioNavigation)
           .OrderByDescending(x => x.Fecha)
           .ToListAsync();
            return collection;
        }
        public async Task<int> AddAsync(Facturas entity)
        {
            //ActualizarCategorias(selectedCategorias, entity);
            await _context.Set<Facturas>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.ID;
        }

        public async Task<int> GetNextNumberOrden()
        {
            int current = 0;

            string sql = string.Format("SELECT IDENT_CURRENT ('Facturas') AS Current_Identity;");

            System.Data.DataTable dataTable = new System.Data.DataTable();

            System.Data.Common.DbConnection connection = _context.Database.GetDbConnection();
            System.Data.Common.DbProviderFactory dbFactory = System.Data.Common.DbProviderFactories.GetFactory(connection!)!;
            using (var cmd = dbFactory!.CreateCommand())
            {
                cmd!.Connection = connection;
                cmd.CommandText = sql;
                using (System.Data.Common.DbDataAdapter adapter = dbFactory.CreateDataAdapter()!)
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dataTable);
                }
            }
            current = Convert.ToInt32(dataTable.Rows[0][0].ToString());
            return await Task.FromResult(current);
        }
    }
}
