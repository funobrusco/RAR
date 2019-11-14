using RAR.DAL.Model.CustomModel;
using RAR.DAL.Model.Tabella;
using StoredProcedureEFCore;
using System;
using System.Threading.Tasks;
using static RAR.DAL.Model.CustomModel.ErrorStoredProcedure;

namespace RAR.DAL.StoredProcedure
{
    public class New_Dispaccio_In_Apertura
    {
        RARContext context;
        public New_Dispaccio_In_Apertura(RARContext _context)
        {
            context = _context;
        }
        public async Task<OutputStored<DateTime>> Execute(string userApertura, long idDispaccio)
        {
            var result = new OutputStored<DateTime>(DateTime.MinValue);
            var STORED_APERTURA_DISPACCIO = "New_Dispaccio_In_Apertura";
            
            await context.LoadStoredProc(STORED_APERTURA_DISPACCIO)
            .AddParam("Usr_Apertura", userApertura)
            .AddParam("Id", idDispaccio)
            .AddParam("Data_Apertura", out IOutParam<string> Data_Apertura, new ParamExtra() { Size = 10 })
                .ExecNonQueryAsync();

            if (!string.IsNullOrEmpty(Data_Apertura.Value))
                result.Entita = Convert.ToDateTime(Data_Apertura.Value);
            else
                result.Error_msg = new Parameter<string>(string.Format("Si è verificato un errore durante l'apertura del dispaccio {0}", idDispaccio));
            
            return result;
        }
    }
}
