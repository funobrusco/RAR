using System.ComponentModel.DataAnnotations;

namespace RAR.ViewModel
{
    public class RaccomandataViewModel
    {
        [Display(Name = "Cod. Raccomandata")]
        public string codeRacc { get; set; }

        [Display(Name = "Numero distinta")]
        public string numeroDistinta { get; set; }
    }
}
