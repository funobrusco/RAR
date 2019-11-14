using RAR.DAL.Model.CustomModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.DAL.Repository
{
    public interface IQueryManagerRepository
    {
        Task<IEnumerable<NewCaricaQuery>> Elenca();
        Task<NewDammiQuery> GetQuery(int idQuery);
    }
}