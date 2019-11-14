using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("New_Staging_PostelFlussi")]
    public partial class NewStagingPostelFlussi
    {
        [Column("ID")]
        public long Id { get; set; }
        public long IdScambioPostel { get; set; }
        [Required]
        [StringLength(6)]
        public string TipoFlusso { get; set; }
        [Required]
        [StringLength(100)]
        public string NomeFlusso { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime DataLavorazione { get; set; }
        [Required]
        [Column("XML", TypeName = "xml")]
        public string Xml { get; set; }
        public int Lavorato { get; set; }
    }
}
