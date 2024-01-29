using System.Linq.Expressions;

namespace VillaAPI.Repos.IRepo
{
    public interface IRepo<T> where T : class
    {
        Task Create(T entidad);

        Task<List<T>> GettAll(Expression<Func<T, bool>>? filtro = null);

        Task<T> GetOne(Expression<Func<T, bool>>? filtro = null, bool tracked = true);

        Task Delete(T entidad);

        Task Save();
    }
}
