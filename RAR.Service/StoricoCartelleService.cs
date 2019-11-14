using System.Threading.Tasks;
using RAR.ViewModel;

namespace RAR.Service
{
    public class StoricoCartelleService : IStoricoCartelleService
    {
        //#region membri
        //private readonly IStoricoCartelleRepository _storicoCartelleRepository;
        //private readonly INewStoricoCartelleInRepository _newStoricoCartelleInRepository;
        //#endregion membri

        //public StoricoCartelleService(IStoricoCartelleRepository storicoCartellleRepository, INewStoricoCartelleInRepository newStoricoCartelleInRepository)
        //{
        //    _storicoCartelleRepository = storicoCartellleRepository;
        //    _newStoricoCartelleInRepository = newStoricoCartelleInRepository;
        //}
        public Task<StoricoCartelleViewModel> RicercaRaccomandate(StoricoCartelleViewModel filtroRicerca)
        {
            //var result = new StoricoCartelleViewModel();

            //return Task.FromResult(result);
            throw new System.NotImplementedException();
        }
    }
}
