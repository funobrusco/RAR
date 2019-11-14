using RAR.DAL.Model.Tabella;
using StoredProcedureEFCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.DAL.StoredProcedure
{
    public class SP_controlla_esiti_scartati
    {
        RARContext context;

        public SP_controlla_esiti_scartati(RARContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<CodiciSmarriti>> Get(string dataOggi)
        {
            Task<List<CodiciSmarriti>> result = null;
            var STORED_DAMMI_QUERY = "SP_controlla_esiti_scartati";
            
            await context.LoadStoredProc(STORED_DAMMI_QUERY)
                .AddParam("dataOggi", dataOggi)
                .ExecAsync(r => result = r.ToListAsync<CodiciSmarriti>());
            
            return await result;
        }
    }
}
