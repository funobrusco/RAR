using System.ComponentModel.DataAnnotations;

namespace RAR.ViewModel
{
    public class DispaccioViewModel
    {
        [Required]
        [Display(Name = "ID")]
        public string Id { get; set; }

        [Display(Name = "Cod.Dispaccio")]
        public string CodDispaccio { get; set; }

        [Display(Name = "Mittente")]
        public string Mittente { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data Arrivo")]
        public string DataArrivo { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data Apertura")]
        public string DataApertura { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data Chiusura")]
        public string DataChiusura { get; set; }
    }
}
