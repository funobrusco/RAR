using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using RAR.DAL.Model.CustomModel;
using RAR.DAL.Model.Tabella;
using RAR.DAL.Repository;
using RAR.ViewModel;

namespace RAR.Service
{
    public class DispaccioService : IDispaccioService
    {
        #region membri
        private readonly IDispaccioRepository _dispaccioRepository;
        private readonly INewDispaccioInRepository _newDispaccioInRepository;
        #endregion membri

        public DispaccioService(IDispaccioRepository dispaccioRepository, INewDispaccioInRepository newDispaccioInRepository)
        {
            _dispaccioRepository = dispaccioRepository;
            _newDispaccioInRepository = newDispaccioInRepository;
        }

        public async Task<ResultStoredViewModel<DateTime>> Apri(string userApertura, long idDispaccio)
        {
            var dataChiusura = await _dispaccioRepository.Apri(userApertura, idDispaccio);
            var result = Traslate(dataChiusura);
            return result;
        }

        public async Task<ResultStoredViewModel<DispaccioViewModel>> Chiudi(string userChiusura, long idDispaccio)
        {
            var dispaccio = await _dispaccioRepository.Chiudi(userChiusura, idDispaccio);
            var result = Traslate(dispaccio);
            return result;
        }

        public async Task<IEnumerable<NewCartolineDispaccioInFromIdDispaccioStored>> GetCartoline(long idDispaccio)
        {
            return await _dispaccioRepository.Cartoline(idDispaccio);
        }

        public async Task<IEnumerable<DispaccioViewModel>> Elenca(string userArrivo)
        {
            var result = new List<DispaccioViewModel>();

            var result1 = await _dispaccioRepository.Elenca(userArrivo);
            result1.ToList().ForEach(dispaccio =>
            {
                result.Add(Traslate(dispaccio));
            });
            return result; 
        }

        private DispaccioViewModel Traslate(NewDispaccioInStored dispaccio)
        {
            var result = new DispaccioViewModel()
            {
                CodDispaccio = dispaccio.CodeRacc,
                DataApertura = dispaccio.DataApertura,
                DataArrivo = dispaccio.DataArrivo,
                DataChiusura = dispaccio.DataChiusura,
                Id = dispaccio.Id.ToString(),
                Mittente = dispaccio.Mittente
            };
            return result;
        }

        public async Task<DispaccioViewModel> Dettaglio(long idDispaccio)
        {

            var dispaccio = await _newDispaccioInRepository.GetByIdAsync(d => d.Id == idDispaccio);
            var result = Traslate(dispaccio);
            return result;
        }

        public async Task<ResultStoredViewModel<DispaccioViewModel>> Nuovo(NewDispaccioIn nuovoDispaccio)
        {
            var dispaccio = await _dispaccioRepository.Nuovo(nuovoDispaccio);
            var result = Traslate(dispaccio);
            return result;
        }

        #region metodi utilità
        private ResultStoredViewModel<DispaccioViewModel> Traslate(OutputStored<NewDispaccioIn> nuovoDispaccio)
        {
            var result = new ResultStoredViewModel<DispaccioViewModel>()
            {
                Entita = Traslate(nuovoDispaccio.Entita)
            };

            if (nuovoDispaccio.Errore)
                result.ImpostaErrore(nuovoDispaccio.Error_Number.Value, nuovoDispaccio.Error_msg.Value);

            return result;
        }
        private DispaccioViewModel Traslate(NewDispaccioIn dispaccio)
        {
            var result = new DispaccioViewModel()
            {
                CodDispaccio = dispaccio.CodeRacc,
                DataApertura = (dispaccio.DataApertura.HasValue) ? dispaccio.DataApertura.Value.ToShortDateString() : string.Empty,
                DataArrivo = dispaccio.DataArrivo.ToShortDateString(),
                DataChiusura = (dispaccio.DataChiusura.HasValue) ? dispaccio.DataChiusura.Value.ToShortDateString() : string.Empty,
                Id = dispaccio.Id.ToString(),
                Mittente = dispaccio.Mittente
            };
            return result;
        }
        private ResultStoredViewModel<DateTime> Traslate(OutputStored<DateTime> dataChiusura)
        {
            var result = new ResultStoredViewModel<DateTime>()
            {
                Entita = dataChiusura.Entita
            };
            if (dataChiusura.Errore)
                result.ImpostaErrore(dataChiusura.Error_Number.Value, dataChiusura.Error_msg.Value);
            return result;
        }

        #endregion metodi utilità
    }
}
