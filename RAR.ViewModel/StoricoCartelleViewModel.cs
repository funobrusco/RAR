using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RAR.ViewModel
{
    public class StoricoCartelleViewModel
    {
        [Display(Name = "Codici Raccomandata")]
        public string codiciRaccomandata { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dal Giorno")]
        public string dalGiorno { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Al Giorno")]
        public string alGiorno { get; set; }

        [Display(Name = "Distinta")]
        public string Distinta { get; set; }

        [Display(Name = "Raccomandata")]
        public string CodeRacc { get; set; }

        [Display(Name = "Elenco raccomandate")]
        public IEnumerable<RaccomandataViewModel> Raccomandate { get; set; }

        public IEnumerable<ElencoDistinteViewModel> ElencoDistinte { get; set; }

        public IEnumerable<RaccomandateInDistintaViewModel> RaccomandateInDistinta { get; set; }

        public DettaglioDistintaViewModel dettaglioDistinta { get; set; }
    }
}