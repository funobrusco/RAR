using RAR.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.Service
{
    public interface IQueryManagerService
    {
        Task<IEnumerable<QueryViewModel>> Elenca();
        Task<QueryViewModel> GetQuery(int idQuery);
    }
}