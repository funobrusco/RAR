using System;
using System.ComponentModel.DataAnnotations;

namespace RAR.DAL.Model.CustomModel
{
    public partial class NewRaccomandateInDistinta
    {
        [Key]
        public string CodeRacc { get; set; }
        public string FileName { get; set; }
        public DateTime? DataSpedizione { get; set; }
    }
}
