using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;
using Turnos.Domain.Model;
using Turnos.Domain.Model.Custom;
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

        public async Task<bool> GenerarTurnos(GenerarTurnos modelo)
        {
            SqlConnection connection;

            try
            {
                using (connection = (SqlConnection)_context.Database.GetDbConnection())
                {
                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        connection.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "usp_CrearTurnos";
                        cmd.Parameters.Add("@FechaInicio", SqlDbType.DateTime).Value = modelo.FechaInicio;
                        cmd.Parameters.Add("@FechaFin", SqlDbType.DateTime).Value = modelo.FechaFin;
                        cmd.Parameters.Add("@IdServicio", SqlDbType.Int).Value = modelo.IdServicio;
                        var reader = await cmd.ExecuteReaderAsync();
                        connection.Close();
                        return true;                        
                    }
                }
            }
            catch (Exception ex)
            {                
                throw new Exception("Error ejecutando el procedimiento", ex);
            }            
        }
    }
}
