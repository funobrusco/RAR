namespace RAR.DAL.Model.CustomModel
{
    public partial class DettaglioRaccomandata
    {
        public string CodiceRaccomandata { get; set; }
        public int NumeroRaccomandate { get; set; }
        public int NumeroRaccomandatePMR { get; set; }
        public NewTempStoricoCartelle Tempstoricocartelle { get; set; }
        public string NumeroDistintaDistpostel { get; set; }
    }
}
