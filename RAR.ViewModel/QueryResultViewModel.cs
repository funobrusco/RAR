using System.ComponentModel.DataAnnotations;

namespace RAR.ViewModel
{
    public class QueryResultViewModel
    {
        [Display(Name = "ID Query")]
        public string IdQuery { get; set; }

        [Display(Name = "Descrizione")]
        public string Descrizione { get; set; }

        [Display(Name = "Utente")]
        public string Utente { get; set; }

        [Display(Name = "SQL")]
        public string SQL { get; set; }
    }
}
