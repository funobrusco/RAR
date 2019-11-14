using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("New_Denominazione_Sociale")]
    public partial class NewDenominazioneSociale
    {
        [Key]
        [Column("id_denominazione_sociale")]
        public int IdDenominazioneSociale { get; set; }
        [Column("descrizione")]
        [StringLength(50)]
        public string Descrizione { get; set; }
        [Column("isattivo")]
        public bool Isattivo { get; set; }
        [Column("data_attivazione", TypeName = "smalldatetime")]
        public DateTime? DataAttivazione { get; set; }
        [Column("data_disattivazione", TypeName = "smalldatetime")]
        public DateTime? DataDisattivazione { get; set; }
        [Required]
        [Column("codice_zeta")]
        [StringLength(8)]
        public string CodiceZeta { get; set; }
        [Column("id_lotto_territoriale")]
        public int? IdLottoTerritoriale { get; set; }
    }
}
