using System.ComponentModel.DataAnnotations;

namespace RAR.DAL.Model.CustomModel
{
    public partial class NewCaricaQuery
    {
        [Key]
        public int IdQuery { get; set; }
        public string DescQuery { get; set; }
        public string CodeOp { get; set; }
    }
}
