using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Turnos.Domain.Model;
using Turnos.Infrastucture.Data.DBContext;
using Turnos.Infrastucture.Data.Repository.Contracts;

namespace Turnos.Infrastucture.Data.Repository
{
    public class ServicioRepository : IServicioRepository
    {
        private readonly DataBaseContext _context;

        public ServicioRepository(DataBaseContext context)
        {
            _context = context;
        }        

        public async Task<IQueryable<Servicio>> Consultar(Expression<Func<Servicio, bool>> filtro = null)
        {
            IQueryable<Servicio> queryEntidad = filtro == null ? _context.Servicios : _context.Servicios.Where(filtro);
            return queryEntidad;
        }

        public async Task<Servicio> Crear(Servicio entidad)
        {
            try
            {
                _context.Set<Servicio>().Add(entidad);
                await _context.SaveChangesAsync();
                return entidad;
            }
            catch (Exception ex)
            {
                throw new Exception("No fue posible crear el registro en la entidad comercio", ex);
            }
        }

        public async Task<bool> Editar(Servicio entidad)
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

        public async Task<bool> Eliminar(Servicio entidad)
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

        public async Task<Servicio> Obtener(Expression<Func<Servicio, bool>> filtro = null)
        {
            try
            {
                return await _context.Servicios.Where(filtro).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("No fue posible obtener el registro", ex);
            }

        }
    }
}
