using RAR.DAL.Model.CustomModel;
using RAR.DAL.Model.Tabella;
using StoredProcedureEFCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.DAL.StoredProcedure
{
    public class New_Dispaccio_In_All
    {
        RARContext context;

        public New_Dispaccio_In_All(RARContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<NewDispaccioInStored>> Execute(string userTracciatura)
        {
            Task<List<NewDispaccioInStored>> result = null;
     
            const string STORED_GETALL_DISPACCI = "New_Dispaccio_In_All";

            await context.LoadStoredProc(STORED_GETALL_DISPACCI)
               .AddParam("Usr_Tracciatura", userTracciatura)
               .ExecAsync(r => result = r.ToListAsync<NewDispaccioInStored>());

            return await result;
        }
    }
}
