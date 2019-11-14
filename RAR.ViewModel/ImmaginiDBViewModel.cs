using System;
using System.ComponentModel.DataAnnotations;

namespace RAR.ViewModel
{
    public class ImmaginiDbViewModel
    {
        [Display(Name = "Codice raccomandata")]
        public string CodeRacc { get; set; }

        //public int Id { get; set; }
        [Display(Name = "Immagine Frontale")]
        public byte[] ImgFront { get; set; }

        [Display(Name = "Immagine Posteriore")]
        public byte[] ImgRetro { get; set; }
        [Display(Name = "Nome File Zip")]
        public string NomeFileZIP { get; set; }
        [Display(Name = "Data Arrivo File Zip")]
        public DateTime? DataArrivoFileZIP { get; set; }

        [Display(Name = "Data Generazione File")]
        public DateTime? DataGenerazioneFile { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Nome File Web")]
        public string NomeFile { get; set; }
        [Display(Name = "Nome File Web")]
        public DateTime? Dataesito { get; set; }
        [Display(Name = "Id immagine")]
        public int Id { get; set; }

        //    public string codeRacc;
        //    public List<ImmagineDb> Details;
        //}
        //public class ImmagineDb
        //{
        //    public string FrontImage;
        //    public string RearImage;
        //    public string FileNameZip;

        //    public DateTime DateFileNameZip { get; set; }
        //    public DateTime DateGenFileNameZip { get; set; }
        //    public DateTime DateXml { get; set; }
        //    public string FileNameWeb { get; set; }

    }
}
