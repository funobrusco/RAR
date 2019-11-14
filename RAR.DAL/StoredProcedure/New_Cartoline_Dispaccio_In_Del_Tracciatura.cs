using RAR.DAL.Model.CustomModel;
using RAR.DAL.Model.Tabella;
using StoredProcedureEFCore;
using System;
using System.Threading.Tasks;

namespace RAR.DAL.StoredProcedure
{
    public class New_Cartoline_Dispaccio_In_Del_Tracciatura
    {
        RARContext context;

        public New_Cartoline_Dispaccio_In_Del_Tracciatura(RARContext _context)
        {
            context = _context;
        }

        public async Task<OutputStored<NewCartolineDispaccioIn>> Execute(long codeRacc)
        {
            var result = new OutputStored<NewCartolineDispaccioIn>(new NewCartolineDispaccioIn());
            result.Entita.CodeRacc = codeRacc.ToString();
            const string STORED_NEW_CARTOLINE_DISPACCIO_IN_TRACCIATURA = "New_Cartoline_Dispaccio_In_Del_Tracciatura";

            try
            {
                await context.LoadStoredProc(STORED_NEW_CARTOLINE_DISPACCIO_IN_TRACCIATURA)
                .AddParam("Code_Racc", result.Entita.CodeRacc)
                .AddParam("Error_Msg", out result.Error_msg, new ParamExtra() { Size = 255 })
                .AddParam("Error_Number", out result.Error_Number)
                .ExecNonQueryAsync();
            }
            catch (Exception e)
            {
            }
            return result;
        }
    }
}
