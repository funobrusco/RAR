using RAR.DAL.Model.CustomModel;
using RAR.DAL.Model.Tabella;
using RAR.DAL.StoredProcedure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.DAL.Repository
{
    public class CartolinaRepository : RepositoryBase<NewCartolineDispaccioIn>, ICartolinaRepository
    {
        public CartolinaRepository(RARContext context) : 
            base(context)
        {
        }

        async public Task<OutputStored<NewCartolineDispaccioIn>> Nuova(NewCartolineDispaccioIn nuovaCartolina)
        {
            return await new New_Cartoline_Dispaccio_In_Tracciatura(RepositoryContext).Execute(nuovaCartolina);
        }

        async public Task<OutputStored<NewCartolineDispaccioIn>> Cancella(long codeRracc)
        {
            return await new New_Cartoline_Dispaccio_In_Del_Tracciatura(RepositoryContext).Execute(codeRracc);
        }

        async public Task<IEnumerable<NewCartolineDispaccioInFromIdDispaccioStored>> Elenca(long idDispaccio)
        {
            return await new New_Cartoline_Dispaccio_In_From_Id_Dispaccio(RepositoryContext).Execute(idDispaccio);
        }
    }
}
