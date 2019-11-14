using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("gs_SOSTITUTIVI_AR")]
    public partial class GsSostitutiviAr
    {
        [Key]
        [Column("ID_SOSTITUTIVO")]
        public int IdSostitutivo { get; set; }
        [Column("ID_DATI")]
        public int? IdDati { get; set; }
        [Column("CODE_RACC")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
        [Column("PROGRESSIVO_UTENTE")]
        [StringLength(20)]
        public string ProgressivoUtente { get; set; }
        [Required]
        [Column("FLAG_TIPO_SOSTITUTIVO")]
        [StringLength(1)]
        public string FlagTipoSostitutivo { get; set; }
        [Column("DATA_NOTIFICA_AR", TypeName = "smalldatetime")]
        public DateTime? DataNotificaAr { get; set; }
        [Column("DATA_CREAZIONE", TypeName = "smalldatetime")]
        public DateTime DataCreazione { get; set; }
        [Column("DATA_INVIO", TypeName = "smalldatetime")]
        public DateTime? DataInvio { get; set; }
        [Column("DATA_RIENTRO", TypeName = "smalldatetime")]
        public DateTime? DataRientro { get; set; }
        [Column("DATA_RENDICONTAZIONE", TypeName = "smalldatetime")]
        public DateTime? DataRendicontazione { get; set; }
        [Column("FILE_NAME_RENDICONTAZIONE")]
        [StringLength(30)]
        public string FileNameRendicontazione { get; set; }
        [Column("DATA_ARCHIVIAZIONE", TypeName = "smalldatetime")]
        public DateTime? DataArchiviazione { get; set; }
        [Column("NOME_CD_ARCHIVIO")]
        [StringLength(30)]
        public string NomeCdArchivio { get; set; }
        [Required]
        [Column("CODE_OPERATORE")]
        [StringLength(5)]
        public string CodeOperatore { get; set; }
        [Column("UFF_RECAPITO")]
        [StringLength(50)]
        public string UffRecapito { get; set; }
    }
}
