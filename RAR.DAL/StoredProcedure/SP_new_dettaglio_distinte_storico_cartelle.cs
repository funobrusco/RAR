using RAR.DAL.Model.CustomModel;
using RAR.DAL.Model.Tabella;
using StoredProcedureEFCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.DAL.StoredProcedure
{
    public class SP_new_dettaglio_distinte_storico_cartelle
    {
        RARContext context;

        public SP_new_dettaglio_distinte_storico_cartelle(RARContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<NewStoricoCartelle.Elenco_Distinte>> Get(DateTime dalGiorno, DateTime alGiorno)
        {
            Task<List<NewStoricoCartelle.Elenco_Distinte>> result = null;
            
                
            var STORED = "new_dettaglio_distinte_storico_cartelle";

            
            await context.LoadStoredProc(STORED)
                .AddParam("Data_Inizio", string.Format("{0:dd/MM/yyyy}", dalGiorno))
                .AddParam("Data_Fine", string.Format("{0:dd/MM/yyyy}", alGiorno))
                .ExecAsync(r => result = r.ToListAsync<NewStoricoCartelle.Elenco_Distinte>());

            return await result;
        }
    }
}
