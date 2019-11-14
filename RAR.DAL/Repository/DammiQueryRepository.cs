using RAR.DAL.Model.CustomModel;
using RAR.DAL.Model.Tabella;
using System.Threading.Tasks;
using RAR.DAL.StoredProcedure;

namespace RAR.DAL.Repository
{
    public class DammiQueryRepository : RepositoryBase<NewDammiQuery>, IDammiQueryRepository
    {
        public DammiQueryRepository(RARContext context) :
            base(context)
        {
        }
        public async Task<NewDammiQuery> ListAsync(int ID_QUERY)
        {
            return await new DammiQuery(RepositoryContext).Get(ID_QUERY);
        }

        //public async Task<NewDammiQuery> ListAsync(int ID_QUERY)
        //{
        //    return await new DammiQuery(RepositoryContext).Get(ID_QUERY);
        //}

        //public async Task<NewDammiQuery> ListAsync(int ID_QUERY)
        //{
        //    return await new DammiQuery(RepositoryContext).Get(ID_QUERY);
        //}
    }
}
