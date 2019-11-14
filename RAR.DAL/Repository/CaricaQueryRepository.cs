using RAR.DAL.Model.CustomModel;
using RAR.DAL.Model.Tabella;
using RAR.DAL.StoredProcedure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.DAL.Repository
{
    public class CaricaQueryRepository: RepositoryBase<NewCaricaQuery>, ICaricaQueryRepository
    {
        public CaricaQueryRepository(RARContext context) :
            base(context)
        {
        }
        async public Task<IEnumerable<NewCaricaQuery>> ListAsync()
        {
            return await new CaricaQuery(RepositoryContext).GetAll();
        }
    }
}
