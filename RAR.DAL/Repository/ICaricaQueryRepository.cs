using RAR.DAL.Model.CustomModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.DAL.Repository
{
    public interface ICaricaQueryRepository: IRepositoryBase<NewCaricaQuery>
    {
        Task<IEnumerable<NewCaricaQuery>> ListAsync();
    }
}
