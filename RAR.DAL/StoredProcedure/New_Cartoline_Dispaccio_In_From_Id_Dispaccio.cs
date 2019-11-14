using RAR.DAL.Model.CustomModel;
using RAR.DAL.Model.Tabella;
using StoredProcedureEFCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.DAL.StoredProcedure
{
    public class New_Cartoline_Dispaccio_In_From_Id_Dispaccio
    {
        RARContext context;

        public New_Cartoline_Dispaccio_In_From_Id_Dispaccio(RARContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<NewCartolineDispaccioInFromIdDispaccioStored>> Execute(long idDispaccio)
        {
            Task<List<NewCartolineDispaccioInFromIdDispaccioStored>> result = null;
            const string STORED_NEW_CARTOLINE_DISPACCIO_IN_FROM_ID_DISPACCIO = "New_Cartoline_Dispaccio_In_From_Id_Dispaccio";
            try
            {
                await context.LoadStoredProc(STORED_NEW_CARTOLINE_DISPACCIO_IN_FROM_ID_DISPACCIO)
                .AddParam("IdDispaccioIn", idDispaccio)
                .ExecAsync(r => result = r.ToListAsync<NewCartolineDispaccioInFromIdDispaccioStored>());
            }
            catch (Exception e)
            {
            }
            return await result;
        }
    }
}