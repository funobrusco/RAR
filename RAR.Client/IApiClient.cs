using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RAR.DAL.Model.Tabella;
using RAR.ViewModel;

namespace RAR.Client
{
    public interface IApiClient
    {
        Task<ResultStoredViewModel<DateTime>> ApriDispaccio(string usrApertura, long idDispaccio);
        Task<ResultStoredViewModel<DispaccioViewModel>> ChiudiDispaccio(string usrChiusura, long idDispaccio);
        Task<DispaccioViewModel> Dettaglio(long idDispaccio);
        Task<IEnumerable<DispaccioViewModel>> GetDispacciByUsrArrivo(string userArrivo);
        Task<IEnumerable<CartolinaViewModel>> GetCartoline(long idDispaccio);
        Task<ResultStoredViewModel<DispaccioViewModel>> NuovoDispaccio(NewDispaccioIn nuovoDispaccio);
    }
}