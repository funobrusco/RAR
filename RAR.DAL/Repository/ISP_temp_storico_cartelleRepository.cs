using RAR.DAL.Model.CustomModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.DAL.Repository
{
    public interface ISP_temp_storico_cartelleRepository
    {
        Task<IEnumerable<NewTempStoricoCartelle>> ListAsync();
    }
}
