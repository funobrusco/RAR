using Microsoft.EntityFrameworkCore;
using RAR.DAL.Model.CustomModel;
using RAR.DAL.Model.Tabella;
using StoredProcedureEFCore;
using System.Threading.Tasks;

namespace RAR.DAL.StoredProcedure
{
    public class SP_new_dettaglio_distinte_storico_cartelle_3
    {
        RARContext context;

        public SP_new_dettaglio_distinte_storico_cartelle_3(RARContext _context)
        {
            context = _context;
        }

        public async Task<NewStoricoCartelle.Dettaglio_Distinta> Get(string codiceDistinta)
        {
            Task<NewStoricoCartelle.Dettaglio_Distinta> result = null;


            var STORED = "new_dettaglio_distinte_storico_cartelle_3";


            await context.LoadStoredProc(STORED)
                .AddParam("distinta", codiceDistinta)
                .ExecAsync(r => result = r.FirstOrDefaultAsync<NewStoricoCartelle.Dettaglio_Distinta>());

            return await result;
        }
    }
}
