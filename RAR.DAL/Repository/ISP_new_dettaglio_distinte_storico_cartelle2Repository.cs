using RAR.DAL.Model.CustomModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.DAL.Repository
{
    public interface ISP_new_dettaglio_distinte_storico_cartelle2Repository
    {
        Task<IEnumerable<NewRaccomandateInDistinta>> ListAsync(string distinta);
    }
}
