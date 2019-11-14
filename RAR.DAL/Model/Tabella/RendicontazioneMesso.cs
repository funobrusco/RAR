using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("RENDICONTAZIONE_MESSO")]
    public partial class RendicontazioneMesso
    {
        [Key]
        [Column("ID_RENDICONTAZIONE")]
        public int IdRendicontazione { get; set; }
        [Column("DATA_INIZIO_REND", TypeName = "smalldatetime")]
        public DateTime DataInizioRend { get; set; }
        [Column("DATA_FINE_REND", TypeName = "smalldatetime")]
        public DateTime DataFineRend { get; set; }
        [Required]
        [Column("CODE_OP_REND")]
        [StringLength(5)]
        public string CodeOpRend { get; set; }
        [Column("DATA_REND", TypeName = "smalldatetime")]
        public DateTime DataRend { get; set; }
        [Column("ID_INSIEME_BANCHE")]
        public int IdInsiemeBanche { get; set; }
        [Required]
        [Column("CODE_UTENTE")]
        [StringLength(8)]
        public string CodeUtente { get; set; }
        [Column("ID_CONCESSIONE")]
        public int IdConcessione { get; set; }
    }
}
