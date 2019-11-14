using RAR.DAL.Model.CustomModel;
using RAR.DAL.Model.Tabella;
using StoredProcedureEFCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.DAL.StoredProcedure
{
    public class SP_new_dettaglio_elenco_racc_storico_cartelle
    {
        RARContext context;

        public SP_new_dettaglio_elenco_racc_storico_cartelle(RARContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<NewStoricoCartelle.Raccomandata>> GetAll()
        {
            Task<List<NewStoricoCartelle.Raccomandata>> result = null;
            var STORED = "new_dettaglio_elenco_racc_storico_cartelle";

                await context.LoadStoredProc(STORED)
                .ExecAsync(r => result = r.ToListAsync<NewStoricoCartelle.Raccomandata>());
            
            
            return await result;
        }
    }
}
