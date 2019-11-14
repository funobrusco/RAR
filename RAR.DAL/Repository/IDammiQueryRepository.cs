using RAR.DAL.Model.CustomModel;
using System.Threading.Tasks;

namespace RAR.DAL.Repository
{
    public interface IDammiQueryRepository
    {
        Task<NewDammiQuery> ListAsync(int ID_QUERY);
    }
}