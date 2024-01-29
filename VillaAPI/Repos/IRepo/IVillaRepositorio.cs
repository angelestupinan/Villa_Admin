using VillaAPI.Models;

namespace VillaAPI.Repos.IRepo
{
    public interface IVillaRepositorio : IRepo<Villa>
    {
        Task<Villa> Update(Villa entidad);
    }
}
