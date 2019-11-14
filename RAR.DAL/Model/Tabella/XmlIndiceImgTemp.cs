using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("XML_IndiceIMG_temp")]
    public partial class XmlIndiceImgTemp
    {
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("TestoXML")]
        public string TestoXml { get; set; }
        [Required]
        [StringLength(255)]
        public string PercorsoCompleto { get; set; }
    }
}
