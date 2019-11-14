using System.ComponentModel.DataAnnotations;


namespace RAR.ViewModel
{
    
    public class ElencoDistinteViewModel
    {
        [Display(Name = "Distinta")]
        public string numeroDistinta { get; set; }

        [Display(Name = "Totale Lettere")]
        public int totLettere { get; set; }

        [Display(Name = "File RRDP30NO")]
        public string fileName { get; set; }

        [Display(Name = "Data Postalizzazione")]
        public string DataSpedizione { get; set; }
    }
}
