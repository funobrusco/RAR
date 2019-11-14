using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("New_Staging_PostelImmagini")]
    public partial class NewStagingPostelImmagini
    {
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("nomefile")]
        [StringLength(100)]
        public string Nomefile { get; set; }
        public long IdScambioPostel { get; set; }
        public long IdScambioAnagrafica { get; set; }
        [Column("numpages")]
        public int Numpages { get; set; }
        [Required]
        [Column("code_racc")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
        [Required]
        [Column("numcart")]
        [StringLength(20)]
        public string Numcart { get; set; }
        [Column("codconc")]
        [StringLength(3)]
        public string Codconc { get; set; }
        [Column("prodotto")]
        [StringLength(4)]
        public string Prodotto { get; set; }
        [Column("anomalia")]
        [StringLength(2)]
        public string Anomalia { get; set; }
        [Required]
        [Column("numscatola")]
        [StringLength(20)]
        public string Numscatola { get; set; }
        [Column("progressivo")]
        public int Progressivo { get; set; }
        [Column("img_fronte")]
        public byte[] ImgFronte { get; set; }
        [Column("img_retro")]
        public byte[] ImgRetro { get; set; }
        [Column("errore")]
        [StringLength(4)]
        public string Errore { get; set; }
        [Column("flag_archiviazione_ade")]
        public int? FlagArchiviazioneAde { get; set; }
        [Column("data_lavorazione", TypeName = "smalldatetime")]
        public DateTime DataLavorazione { get; set; }
        [Column("lavorato")]
        public int Lavorato { get; set; }
    }
}
