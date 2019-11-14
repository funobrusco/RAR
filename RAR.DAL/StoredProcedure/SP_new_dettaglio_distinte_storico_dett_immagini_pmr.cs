using System;
using System.Collections.Generic;
using RAR.DAL.Model.CustomModel;
using RAR.DAL.Model.Tabella;
using StoredProcedureEFCore;
using System.Threading.Tasks;

namespace RAR.DAL.StoredProcedure
{
    public class SP_new_dettaglio_distinte_storico_dett_immagini_pmr
    {
        RARContext context;
        public SP_new_dettaglio_distinte_storico_dett_immagini_pmr(RARContext _context)
        {
            context = _context;
        }

      
        public async Task<IEnumerable<NewDettaglioDistinteStoricoDettImmagini>> Get(string codiceRaccomandata)
        {
            Task<List<NewDettaglioDistinteStoricoDettImmagini>> result = null;
            var STORED = "new_dettaglio_distinte_storico_dett_immagini_pmr";
            try
            {
                await context.LoadStoredProc(STORED)
                    .AddParam("code_racc", codiceRaccomandata)
                    .ExecAsync(r => result = r.ToListAsync<NewDettaglioDistinteStoricoDettImmagini>());
            }
            catch (Exception ex)
            {
                return null;
            }
            return await result;
        }
    }

}
