using RAR.DAL.Model.CustomModel;
using RAR.DAL.Model.Tabella;
using StoredProcedureEFCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.DAL.StoredProcedure
{
    public class SP_new_dettaglio_distinte_storico_cartelle2
    {
        RARContext context;

        public SP_new_dettaglio_distinte_storico_cartelle2(RARContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<NewStoricoCartelle.Elenco_Raccomandate_In_Distinta>> Get(string distinta)
        {
            Task<List<NewStoricoCartelle.Elenco_Raccomandate_In_Distinta>> result = null;
            var STORED = "new_dettaglio_distinte_storico_cartelle_2";

            await context.LoadStoredProc(STORED)
                .AddParam("distinta", distinta)
                .ExecAsync(r => result = r.ToListAsync<NewStoricoCartelle.Elenco_Raccomandate_In_Distinta>());

            return await result;
        }
    }
}
