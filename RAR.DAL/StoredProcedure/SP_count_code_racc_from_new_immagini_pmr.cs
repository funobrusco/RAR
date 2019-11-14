using Microsoft.EntityFrameworkCore;
using RAR.DAL.Model.CustomModel;
using RAR.DAL.Model.Tabella;
using StoredProcedureEFCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.DAL.StoredProcedure
{
    public class SP_count_code_racc_from_new_immagini
    {
        RARContext context;

        public SP_count_code_racc_from_new_immagini(RARContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<NewCountCodeRacc>> Get(string code_racc)
        {
            Task<List<NewCountCodeRacc>> result = null;
            var STORED = "dbo.SP_count_code_racc_from_new_immagini";
            try
            {
                await context.LoadStoredProc(STORED)
                    .AddParam("code_racc", code_racc)
                    .ExecAsync(r => result = r.ToListAsync<NewCountCodeRacc>());
            }
            catch (Exception ex)
            {
                return null;
            }
            return await result;
        }
    }
}
