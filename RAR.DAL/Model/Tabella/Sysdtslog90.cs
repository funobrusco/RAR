using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("sysdtslog90")]
    public partial class Sysdtslog90
    {
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("event")]
        [StringLength(128)]
        public string Event { get; set; }
        [Required]
        [Column("computer")]
        [StringLength(128)]
        public string Computer { get; set; }
        [Required]
        [Column("operator")]
        [StringLength(128)]
        public string Operator { get; set; }
        [Required]
        [Column("source")]
        [StringLength(1024)]
        public string Source { get; set; }
        [Column("sourceid")]
        public Guid Sourceid { get; set; }
        [Column("executionid")]
        public Guid Executionid { get; set; }
        [Column("starttime", TypeName = "datetime")]
        public DateTime Starttime { get; set; }
        [Column("endtime", TypeName = "datetime")]
        public DateTime Endtime { get; set; }
        [Column("datacode")]
        public int Datacode { get; set; }
        [Column("databytes", TypeName = "image")]
        public byte[] Databytes { get; set; }
        [Required]
        [Column("message")]
        [StringLength(2048)]
        public string Message { get; set; }
    }
}
