using RAR.DAL.Model.CustomModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.DAL.Repository
{
    public interface ISP_new_dettaglio_elenco_racc_storico_cartelle
    {
        Task<IEnumerable<NewStoricoCartelle.Raccomandata>> ListAsync();
    }
}
