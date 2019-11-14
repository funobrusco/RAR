using System;
using System.ComponentModel.DataAnnotations;

namespace RAR.ViewModel
{
    public class CartolinaViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Id dispaccio")]
        public long IdDispaccioIn { get; set; }

        [Display(Name = "Codice raccomandata")]
        [StringLength(20)]
        public string CodeRacc { get; set; }

        [Display(Name = "Data tracciatura")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataTracciatura { get; set; }

        [Display(Name = "Data notifica")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataNotifica { get; set; }

        [Display(Name = "Utente tracciatura")]
        public string UsrTracciatura { get; set; }

        [Display(Name = "Tipo consegna")]
        public string Consegna { get; set; }
    }
}
