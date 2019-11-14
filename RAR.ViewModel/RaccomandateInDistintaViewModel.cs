using System.ComponentModel.DataAnnotations;


namespace RAR.ViewModel
{
    
    public class RaccomandateInDistintaViewModel
    {
        [Display(Name = "Codice Raccomandata")]
        public string CodeRacc { get; set; }

        [Display(Name = "File RRDP30NO")]
        public string FileName { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data Postalizzazione")]
        public string DataSpedizione { get; set; }
    }
}
