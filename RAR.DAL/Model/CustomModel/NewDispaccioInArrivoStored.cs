using System;

namespace RAR.DAL.Model.CustomModel
{
    public partial class NewDispaccioInArrivoStored
    {
        public Int64 Identity { get; set; }
        public string CodeRacc { get; set; }
        public string DataArrivo { get; set; }
        public string Mittente { get; set; }
        public string UsrArrivo { get; set; }
        public string Error_Msg { get; set; }
        public int Error_Number { get; set; }
    }
}
