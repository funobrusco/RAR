using System.ComponentModel.DataAnnotations;

namespace RAR.DAL.Model.CustomModel
{
    public partial class NewDammiQuery
    {
        [Key]
        public int IdQuery { get; set; }
        public string Testo { get; set; }
    }
}
