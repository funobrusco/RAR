using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("New_Scarti_TT")]
    public partial class NewScartiTt
    {
        [Key]
        [Column("ID_SCARTI_TT")]
        public int IdScartiTt { get; set; }
        [Required]
        [Column("CODICE_RACCOMANDATA")]
        [StringLength(12)]
        public string CodiceRaccomandata { get; set; }
        [Column("DATATRACCIA", TypeName = "smalldatetime")]
        public DateTime Datatraccia { get; set; }
        [Required]
        [Column("ESITO")]
        [StringLength(4)]
        public string Esito { get; set; }
        [Required]
        [Column("FONTE_ESITO")]
        [StringLength(2)]
        public string FonteEsito { get; set; }
        [Column("DATANOTIFICA", TypeName = "smalldatetime")]
        public DateTime Datanotifica { get; set; }
        [Required]
        [StringLength(3)]
        public string Errore { get; set; }
        [Required]
        [Column("Nome_File")]
        [StringLength(50)]
        public string NomeFile { get; set; }
    }
}
