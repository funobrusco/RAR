using RAR.ViewModel;
using System.Threading.Tasks;

namespace RAR.Service
{
    public interface IStoricoCartelleService
    {
        Task<StoricoCartelleViewModel> RicercaRaccomandate(StoricoCartelleViewModel filtroRicerca);
    }
}
