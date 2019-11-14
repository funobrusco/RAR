using RAR.DAL.Model.CustomModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.DAL.Repository
{
    interface ISP_new_dettaglio_distinte_storico_dett_immagini_arRepository
    {
        Task<IEnumerable<NewDettaglioDistinteStoricoDettImmagini>> ListAsync(string codiceRaccomandata);
    }
}
