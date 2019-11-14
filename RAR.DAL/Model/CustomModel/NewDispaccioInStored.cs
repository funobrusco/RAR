namespace RAR.DAL.Model.CustomModel
{
    public partial class NewDispaccioInStored
    {

        public long Id { get; set; }
        public string CodeRacc { get; set; }
        public string DataArrivo { get; set; }
        public string DataApertura { get; set; }
        public string DataChiusura { get; set; }
        public string Mittente { get; set; }
        public string UsrArrivo { get; set; }
        public string UsrApertura { get; set; }
        public string UsrChiusura { get; set; }
    }
}
