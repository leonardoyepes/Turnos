using System.Linq.Expressions;

namespace Turnos.Infrastucture.Data.Repository.Contracts
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        Task<TModel> Obtener(Expression<Func<TModel, bool>> filtro);
        Task<TModel> Crear(TModel model);
        Task<bool> Editar(TModel model);
        Task<bool> Eliminar(TModel model);
        Task<IQueryable<TModel>> Consultar(Expression<Func<TModel, bool>> filtro = null);
    }
}
