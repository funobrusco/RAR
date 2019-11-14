using System;

namespace RAR.DAL.Model.CustomModel
{
    public partial class NewDistinta_Postel
    {
        public string NumeroDistinta { get; set; }
        public int TotLettere { get; set; }
        public string FileName { get; set; }
        public DateTime? DataSpedizione { get; set; }
    }
}
