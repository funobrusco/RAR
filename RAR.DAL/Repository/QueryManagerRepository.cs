using RAR.DAL.Model.CustomModel;
using RAR.DAL.Model.Tabella;
using RAR.DAL.StoredProcedure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.DAL.Repository
{
    public class QueryManagerRepository : RepositoryBase<NewCaricaQuery>, IQueryManagerRepository
    {

        public QueryManagerRepository(RARContext context) :
            base(context)
        {
        }

         public async Task<IEnumerable<NewCaricaQuery>> Elenca()
        {
            return await new CaricaQuery(RepositoryContext).GetAll();
        }

        public async Task<NewDammiQuery> GetQuery(int idQuery)
        {
            return await new DammiQuery(RepositoryContext).Get(idQuery);
        }
    }
}
