using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("Denominazione_Sociale")]
    public partial class DenominazioneSociale
    {
        public DenominazioneSociale()
        {
            AmbitoProvinciale = new HashSet<AmbitoProvinciale>();
        }

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

        [InverseProperty("IdDenominazioneSocialeNavigation")]
        public virtual ICollection<AmbitoProvinciale> AmbitoProvinciale { get; set; }
    }
}
