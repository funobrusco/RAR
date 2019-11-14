using RAR.DAL.Model.CustomModel;
using RAR.DAL.Model.Tabella;
using StoredProcedureEFCore;
using System;
using System.Threading.Tasks;

namespace RAR.DAL.StoredProcedure
{
    public class New_Cartoline_Dispaccio_In_Tracciatura
    {
        RARContext context;

        public New_Cartoline_Dispaccio_In_Tracciatura(RARContext _context)
        {
            context = _context;
        }
        public async Task<OutputStored<NewCartolineDispaccioIn>> Execute(NewCartolineDispaccioIn cartolinaDispaccio)
        {
            var result = new OutputStored<NewCartolineDispaccioIn>(cartolinaDispaccio);

            const string STORED_NEW_CARTOLINE_DISPACCIO_IN_DEL_TRACCIATURA = "New_Cartoline_Dispaccio_In_Tracciatura";
           
            await context.LoadStoredProc(STORED_NEW_CARTOLINE_DISPACCIO_IN_DEL_TRACCIATURA)
            .AddParam("Id_Dispaccio_In", cartolinaDispaccio.IdDispaccioIn)
            .AddParam("Code_Racc", cartolinaDispaccio.CodeRacc)
            .AddParam("Data_Notifica", cartolinaDispaccio.DataNotifica)
            .AddParam("Usr_Tracciatura", cartolinaDispaccio.UsrTracciatura)
            .AddParam("CodeTipoConsegna", cartolinaDispaccio.CodiceTipoConsegna)
            .AddParam("Identity", out IOutParam<int> Identity)
            .AddParam("Data_Tracciatura", out IOutParam<string> Data_Tracciatura, new ParamExtra() { Size = 10 })
            .AddParam("Error_Msg", out result.Error_msg, new ParamExtra() { Size = 255 })
            .AddParam("Error_Number",  out result.Error_Number)
            .ExecNonQueryAsync();

            if (string.IsNullOrEmpty(result.Error_msg.Value))
            {
                result.Entita.Id = Identity.Value;
                result.Entita.DataTracciatura = Convert.ToDateTime(Data_Tracciatura.Value);
            }
           
            return result;
        }
    }
}


