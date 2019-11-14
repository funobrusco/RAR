using RAR.DAL.Model.CustomModel;
using RAR.DAL.Model.Tabella;
using RAR.DAL.StoredProcedure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.DAL.Repository
{
    public class SP_new_dettaglio_distinte_storico_dett_immagini_arRepository : RepositoryBase<NewDettaglioDistinteStoricoDettImmagini>, ISP_new_dettaglio_distinte_storico_dett_immagini_arRepository
    {
        RARContext context;
        public SP_new_dettaglio_distinte_storico_dett_immagini_arRepository(RARContext context) :
            base(context)
        {
        }
        public async Task<IEnumerable<NewDettaglioDistinteStoricoDettImmagini>> ListAsync(string codiceRaccomandata)
        {
            return await new SP_new_dettaglio_distinte_storico_dett_immagini_ar(context).Get(codiceRaccomandata);
        }
    }
}
