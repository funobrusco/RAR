using RAR.DAL.Model.CustomModel;
using RAR.DAL.Model.Tabella;
using RAR.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.Service
{
    public interface IDispaccioService
    {
        Task<ResultStoredViewModel<DateTime>> Apri(string userApertura, long idDispaccio);
        Task<ResultStoredViewModel<DispaccioViewModel>> Chiudi(string userChiudi, long idDispaccio);
        Task<IEnumerable<NewCartolineDispaccioInFromIdDispaccioStored>> GetCartoline(long idDispaccio);
        Task<DispaccioViewModel> Dettaglio(long idDispaccio);
        Task<IEnumerable<DispaccioViewModel>> Elenca(string userArrivo);
        Task<ResultStoredViewModel<DispaccioViewModel>> Nuovo(NewDispaccioIn nuovoDispaccio);
    }
}
