using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Turnos.Domain.Model;
using Turnos.Infrastucture.Data.DBContext;
using Turnos.Infrastucture.Data.Repository.Contracts;

namespace Turnos.Infrastucture.Data.Repository
{
    public class TurnoRepository : ITurnoRepository
    {
        private readonly DataBaseContext _context;

        public TurnoRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Turno>> Consultar(Expression<Func<Turno, bool>> filtro = null)
        {
            IQueryable<Turno> queryEntidad = filtro == null ? _context.Turnos : _context.Turnos.Where(filtro);            
            return queryEntidad;
        }

        public async Task<Turno> Obtener(Expression<Func<Turno, bool>> filtro = null)
        {
            try
            {
                return await _context.Turnos.Where(filtro).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("No fue posible obtener el registro", ex);
            }
        }
    }
}
