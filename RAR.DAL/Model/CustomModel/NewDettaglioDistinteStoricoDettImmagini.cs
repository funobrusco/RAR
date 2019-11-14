using System;

namespace RAR.DAL.Model.CustomModel
{
    public partial class NewDettaglioDistinteStoricoDettImmagini
    {
        public string CodeRacc { get; set; }
        public int Id { get; set; }
        public byte[] ImgFront {get;set;}
        public byte[] ImgRetro {get;set;}
        public string NomeFileZIP {get;set;}
        public DateTime? DataArrivoFileZIP {get;set;}
        public DateTime? DataGenerazioneFile {get;set;}
        public string NomeFile {get;set;}
        public DateTime? DATAESITO {get;set;}
    }
}
