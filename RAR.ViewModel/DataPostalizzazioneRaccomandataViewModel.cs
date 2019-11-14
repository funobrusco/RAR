using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RAR.ViewModel
{
    public class DataPostalizzazioneRaccs
    {
        public SearchInterval SearchDate;
        public List<ListPostalizzazione> DataPostalizzazioneRacc;

    }
    public class SearchInterval
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

    }

    public class ListPostalizzazione
    {
        [Display(Name = "Distinta")]
        public string Distinta { get; set; }
        [Display(Name = "Totale lettere")]
        public int Totale { get; set; }
        [Display(Name = "File RRDP30NO")]
        public string FileRrdp30No { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data Postalizzazione")]
        public DateTime DataPostalizzazione { get; set; }
    }
}
