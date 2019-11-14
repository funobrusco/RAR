using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RAR.ViewModel
{
    public class DettaglioDistinteViewModel
    {
        public string Distinta { get; set; }
        public List<Detail> Details;
    }

    public class Detail
    {
        [Display(Name = "Codice Raccomandata")]
        public string CodeRacc { get; set; }
        [Display(Name = "File RRDP30NO")]
        public string FileName { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data Spedizione")]
        public DateTime DataSpedizione { get; set; }

    }
   
}
