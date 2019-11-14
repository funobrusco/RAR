using RAR.DAL.Model.CustomModel;
using RAR.DAL.Model.Tabella;
using StoredProcedureEFCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.DAL.StoredProcedure
{
    public class SP_temp_storico_cartelle
    {
        RARContext context;

        public SP_temp_storico_cartelle(RARContext _context)
        {
            context = _context;
        }


        public async Task<IEnumerable<NewTempStoricoCartelle>> Get()
        {
            Task<List<NewTempStoricoCartelle>> result = null;
            var STORED = "SP_temp_storico_cartelle";
            try
            {
                await context.LoadStoredProc(STORED)
                .ExecAsync(r => result = r.ToListAsync<NewTempStoricoCartelle>());
            }
            catch (Exception ex)
            {
                return null;
            }
            return await result;
        }
    }
}
