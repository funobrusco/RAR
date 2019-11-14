using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("SERVICE_RESTITUZIONE_FILE")]
    public partial class ServiceRestituzioneFile
    {
        public ServiceRestituzioneFile()
        {
            ServiceRestituzioneCd = new HashSet<ServiceRestituzioneCd>();
        }

        [Key]
        [Column("ID_FILE")]
        public int IdFile { get; set; }
        [Required]
        [Column("FILE_NAME")]
        [StringLength(28)]
        public string FileName { get; set; }
        [Required]
        [Column("CODE_CONCESSIONE")]
        [StringLength(3)]
        public string CodeConcessione { get; set; }
        [Required]
        [Column("NOME_VETTORE")]
        [StringLength(50)]
        public string NomeVettore { get; set; }
        [Required]
        [Column("LETTERA_VETTURA")]
        [StringLength(20)]
        public string LetteraVettura { get; set; }
        [Column("TOT_CD")]
        public int TotCd { get; set; }
        [Column("TOT_SCATOLE")]
        public int TotScatole { get; set; }
        [Column("DATA_SPEDIZIONE", TypeName = "smalldatetime")]
        public DateTime DataSpedizione { get; set; }
        [Column("DATA_ACQUISIZIONE", TypeName = "smalldatetime")]
        public DateTime DataAcquisizione { get; set; }
        [Column("DATA_RICEZIONE", TypeName = "smalldatetime")]
        public DateTime? DataRicezione { get; set; }

        [InverseProperty("IdFileNavigation")]
        public virtual ICollection<ServiceRestituzioneCd> ServiceRestituzioneCd { get; set; }
    }
}
