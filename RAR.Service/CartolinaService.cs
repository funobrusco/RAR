using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RAR.DAL.Model.CustomModel;
using RAR.DAL.Model.Tabella;
using RAR.DAL.Repository;
using RAR.ViewModel;

namespace RAR.Service
{
    public class CartolinaService : ICartolinaService
    {
        private readonly ICartolinaRepository _cartolinaRepository;

        public CartolinaService(ICartolinaRepository cartolinaRepository)
        {
            _cartolinaRepository = cartolinaRepository;
        }

        public async Task<ResultStoredViewModel<CartolinaViewModel>> Cancella(long codeRracc)
        {
            var cartolina = await _cartolinaRepository.Cancella(codeRracc);
            var result = Traslate(cartolina);
            return result;
        }

        public async Task<IEnumerable<CartolinaViewModel>> Elenca(long idDispaccio)
        {
            var result = new List<CartolinaViewModel>();
            var cartoline = await _cartolinaRepository.Elenca(idDispaccio);

            cartoline.ToList().ForEach(cartolina => result.Add(Traslate(cartolina)));
            result.ToList().ForEach(cartolina => cartolina.IdDispaccioIn = idDispaccio);
            return result;
        }

        public async Task<ResultStoredViewModel<CartolinaViewModel>> Nuova(NewCartolineDispaccioIn nuovaCartolina)
        {
            var cartolina = await _cartolinaRepository.Nuova(nuovaCartolina);
            var result = Traslate(cartolina);
            return result;
        }

        private ResultStoredViewModel<CartolinaViewModel> Traslate(OutputStored<NewCartolineDispaccioIn> nuovaCartolina)
        {
            var result = new ResultStoredViewModel<CartolinaViewModel>()
            {
                Entita = Traslate(nuovaCartolina.Entita)
            };

            if (nuovaCartolina.Errore)
                result.ImpostaErrore(nuovaCartolina.Error_Number.Value, nuovaCartolina.Error_msg.Value);

            return result;
        }

        private CartolinaViewModel Traslate(NewCartolineDispaccioInFromIdDispaccioStored cartolina)
        {
            var result = new CartolinaViewModel()
            {
                CodeRacc = cartolina.CodeRacc,
                Consegna = cartolina.TipoConsegna,
                DataNotifica = (!string.IsNullOrEmpty(cartolina.DataNotifica)) ? Convert.ToDateTime(cartolina.DataNotifica) : DateTime.MinValue,
                DataTracciatura = Convert.ToDateTime(cartolina.DataTracciatura),
                Id = cartolina.Id
            };

            return result;
        }

        private CartolinaViewModel Traslate(NewCartolineDispaccioIn nuovaCartolina)
        {
            var result = new CartolinaViewModel()
            {
                CodeRacc = nuovaCartolina.CodeRacc,
                Consegna = nuovaCartolina.CodiceTipoConsegna,
                DataNotifica = nuovaCartolina.DataNotifica,
                DataTracciatura = nuovaCartolina.DataTracciatura,
                Id = nuovaCartolina.Id,
                IdDispaccioIn = nuovaCartolina.IdDispaccioIn
            };

            return result;
        }
    }
}
