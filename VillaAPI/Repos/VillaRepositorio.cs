using VillaAPI.Data;
using VillaAPI.Models;
using VillaAPI.Repos.IRepo;

namespace VillaAPI.Repos
{
    public class VillaRepositorio : Repo<Villa>, IVillaRepositorio
    {
        private readonly ApplicationDbContext _db;


        public VillaRepositorio(ApplicationDbContext db) :base(db)
        {
                _db = db;
        }


        public async Task<Villa> Update(Villa entidad)
        {
            entidad.Fecha = DateTime.Now;
            _db.Villas.Update(entidad);
            await _db.SaveChangesAsync();

            return entidad;
        }

    }
}
