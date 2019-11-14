using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("New_ElencoFileInput")]
    public partial class NewElencoFileInput
    {
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string NomeFile { get; set; }
        [Required]
        [StringLength(50)]
        public string TipoFile { get; set; }
        public short NumeroFlussi { get; set; }
        public int NumeroPezziTotale { get; set; }
        [Required]
        [StringLength(50)]
        public string Utente { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataRicezione { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataInizioTrasferimento { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataFineTrasferimento { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataSpostamentoFile { get; set; }
        [StringLength(2)]
        public string EsitoSpostamentoFile { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInizioCaricamento { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataFineCaricamento { get; set; }
        [Column("IDFileRisposta")]
        public int? IdfileRisposta { get; set; }
        [Column("IDFileRiferimento")]
        public int? IdfileRiferimento { get; set; }
        [Column("FlussiOK")]
        [StringLength(4000)]
        public string FlussiOk { get; set; }
        [Column("FlussiKO")]
        [StringLength(4000)]
        public string FlussiKo { get; set; }
        [StringLength(50)]
        public string StatoFile { get; set; }
        [StringLength(512)]
        public string StatoFileDesc { get; set; }
    }
}
