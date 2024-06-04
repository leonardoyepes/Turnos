using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Turnos.Domain.Model;
using Turnos.Infrastucture.Data.DBContext;
using Turnos.Infrastucture.Data.Repository.Contracts;

namespace Turnos.Infrastucture.Data.Repository
{
    public class ComercioRepository : IComercioRepository
    {
        private readonly DataBaseContext _context;

        public ComercioRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Comercio>> Consultar(Expression<Func<Comercio, bool>> filtro = null)
        {
            IQueryable<Comercio> queryEntidad = filtro == null ? _context.Comercios : _context.Comercios.Where(filtro);
            return queryEntidad;
        }

        public async Task<Comercio> Crear(Comercio entidad)
        {
            try
            {
                _context.Set<Comercio>().Add(entidad);
                await _context.SaveChangesAsync();
                return entidad;
            }
            catch (Exception ex)
            {
                throw new Exception("No fue posible crear el registro en la entidad comercio", ex);
            }
        }

        public async Task<bool> Editar(Comercio entidad)
        {
            try
            {
                _context.Update(entidad);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No fue posible actualizar la entidad comercio", ex);
            }
        }

        public async Task<bool> Eliminar(Comercio entidad)
        {
            try
            {
                _context.Remove(entidad);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No fue posible eliminar el registro en la entidad comercio", ex);
            }
        }

        public async Task<Comercio> Obtener(Expression<Func<Comercio, bool>> filtro = null)
        {
            try
            {
                return await _context.Comercios.Where(filtro).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("No fue posible obtener el registro", ex);
            }
            
        }
    }
}
