using RAR.DAL.Model.Tabella;
using RAR.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.Service
{
    public interface ICartolinaService
    {
        Task<ResultStoredViewModel<CartolinaViewModel>> Nuova(NewCartolineDispaccioIn nuovaCartolina);
        Task<ResultStoredViewModel<CartolinaViewModel>> Cancella(long codiceRaccomandata);
        Task<IEnumerable<CartolinaViewModel>> Elenca(long idDispaccio);
    }
}
