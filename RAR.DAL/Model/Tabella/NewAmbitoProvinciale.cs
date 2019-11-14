using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("New_Ambito_Provinciale")]
    public partial class NewAmbitoProvinciale
    {
        [Key]
        [Column("id_ambito_provinciale")]
        public int IdAmbitoProvinciale { get; set; }
        [Required]
        [Column("descrizione")]
        [StringLength(50)]
        public string Descrizione { get; set; }
        [Column("isattivo")]
        public bool Isattivo { get; set; }
        [Column("data_attivazione", TypeName = "smalldatetime")]
        public DateTime? DataAttivazione { get; set; }
        [Column("data_disattivazione", TypeName = "smalldatetime")]
        public DateTime? DataDisattivazione { get; set; }
        [Column("id_denominazione_sociale")]
        public int IdDenominazioneSociale { get; set; }
        [Column("sotto_codice_utente")]
        [StringLength(4)]
        public string SottoCodiceUtente { get; set; }
        [Column("sigla")]
        [StringLength(2)]
        public string Sigla { get; set; }
    }
}
