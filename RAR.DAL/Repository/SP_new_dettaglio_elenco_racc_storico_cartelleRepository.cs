using RAR.DAL.Model.CustomModel;
using RAR.DAL.Model.Tabella;
using RAR.DAL.StoredProcedure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.DAL.Repository
{
    public class SP_new_dettaglio_elenco_racc_storico_cartelleRepository : RepositoryBase<NewStoricoCartelle.Raccomandata>, ISP_new_dettaglio_elenco_racc_storico_cartelle
    {
        public SP_new_dettaglio_elenco_racc_storico_cartelleRepository(RARContext context) :
            base(context)
        {
        }
        public async Task<IEnumerable<NewStoricoCartelle.Raccomandata>> ListAsync()
        {
            return await new SP_new_dettaglio_elenco_racc_storico_cartelle(RepositoryContext).GetAll();
        }
    }
}
