using RAR.DAL.Model.CustomModel;
using RAR.DAL.Model.Tabella;
using StoredProcedureEFCore;
using System;
using System.Threading.Tasks;

namespace RAR.DAL.StoredProcedure
{
    public class New_Dispaccio_In_Chiusura
    {
        RARContext context;

        public New_Dispaccio_In_Chiusura(RARContext _context)
        {
            context = _context;
        }

        public async Task<OutputStored<NewDispaccioIn>> Execute(long idDispaccio, string userChiusura)
        {
            var dispaccio = new NewDispaccioIn()
            {
                UsrChiusura = userChiusura,
                Id = idDispaccio
            };

            var result = new OutputStored<NewDispaccioIn>(dispaccio);

            const string STORED_NEW_DISPACCIO_IN_CHIUSURA = "New_Dispaccio_In_Chiusura";
           
                    await context.LoadStoredProc(STORED_NEW_DISPACCIO_IN_CHIUSURA)
                    .AddParam("Usr_Chiusura", result.Entita.UsrChiusura)
                    .AddParam("Id", result.Entita.Id)
                    .AddParam("Error_Number", out result.Error_Number)
                    .AddParam("Error_Msg", out result.Error_msg, new ParamExtra() { Size = 255 })
                    .AddParam("Data_Chiusura", out IOutParam<string> Data_Chiusura, new ParamExtra() { Size = 10 })
                    .ExecNonQueryAsync();

                    if (string.IsNullOrEmpty(result.Error_msg.Value))
                        result.Entita.DataChiusura = Convert.ToDateTime(Data_Chiusura.Value);

            return result;
        }
    }
}
