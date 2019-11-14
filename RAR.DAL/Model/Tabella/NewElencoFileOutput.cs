using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("New_ElencoFileOutput")]
    public partial class NewElencoFileOutput
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("IDFileInput")]
        public int? IdfileInput { get; set; }
        [Required]
        [StringLength(50)]
        public string NomeFile { get; set; }
        [Required]
        [StringLength(50)]
        public string TipoFile { get; set; }
        [Required]
        [StringLength(50)]
        public string Utente { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataProduzione { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCreazione { get; set; }
    }
}
