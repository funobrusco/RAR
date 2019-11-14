using RAR.DAL.Model.CustomModel;
using RAR.DAL.Model.Tabella;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.DAL.Repository
{
    public interface ICartolinaRepository: IRepositoryBase<NewCartolineDispaccioIn>
    {
        Task<OutputStored<NewCartolineDispaccioIn>> Nuova(NewCartolineDispaccioIn nuovaCartolina);
        Task<OutputStored<NewCartolineDispaccioIn>> Cancella(long codeRacc);
        Task<IEnumerable<NewCartolineDispaccioInFromIdDispaccioStored>> Elenca(long idDispaccio);
    }
}
