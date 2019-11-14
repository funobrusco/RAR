using RAR.DAL.Model.CustomModel;
using RAR.DAL.Model.Tabella;
using StoredProcedureEFCore;
using System;
using System.Threading.Tasks;

namespace RAR.DAL.StoredProcedure
{
    public class New_Dispaccio_In_Arrivo
    {
        RARContext context;

        public New_Dispaccio_In_Arrivo(RARContext _context)
        {
            context = _context;
        }

        public async Task<OutputStored<NewDispaccioIn>> Execute(NewDispaccioIn nuovoDispaccio)
        {
            var result = new OutputStored<NewDispaccioIn>(nuovoDispaccio);

            const string STORED_NEW_DISPACCIO_IN_ARRIVO = "New_Dispaccio_In_Arrivo";

            
            await context.LoadStoredProc(STORED_NEW_DISPACCIO_IN_ARRIVO)
            .AddParam("Code_Racc", result.Entita.CodeRacc)
            .AddParam("Mittente", result.Entita.Mittente)
            .AddParam("Usr_Arrivo", result.Entita.UsrArrivo)
            .AddParam("Identity", out IOutParam<long> identity)
            .AddParam("Data_Arrivo", out IOutParam<string> Data_Arrivo, new ParamExtra() { Size = 10 })
            .AddParam("Error_Msg", out result.Error_msg, new ParamExtra() { Size = 255 })
            .AddParam("Error_Number", out result.Error_Number)
            .ExecNonQueryAsync();

            if (string.IsNullOrEmpty(result.Error_msg.Value))
            {
                result.Entita.DataArrivo = Convert.ToDateTime(Data_Arrivo.Value);
                result.Entita.Id = identity.Value;
            }
            
            return result;
        }
    }
}
