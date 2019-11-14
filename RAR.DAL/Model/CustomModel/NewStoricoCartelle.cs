using System;
using System.Collections.Generic;

namespace RAR.DAL.Model.CustomModel
{
    public partial class NewStoricoCartelle
    {
        public string CodiciRaccomandata { get; set; }
        public string DalGiorno { get; set; }
        public string AlGiorno { get; set; }
        public string Distinta { get; set; }
        public string CodeRacc { get; set; }
        public IEnumerable<Raccomandata> Raccomandate { get; set; }
        public IEnumerable<Elenco_Distinte> ElencoDistinte { get; set; }
        public IEnumerable<Elenco_Raccomandate_In_Distinta> RaccomandateInDistinta { get; set; }
        public Dettaglio_Distinta dettaglioDistinta {get;set;}
        

        public class Raccomandata
        {
            public string codeRacc { get; set; }
            public string numeroDistinta { get; set; }
        }

        public class Elenco_Distinte
        {
            public string NumeroDistinta { get; set; }
            public int TotLettere { get; set; }
            public string FileName { get; set; }
            public DateTime? DataSpedizione { get; set; }
        }

        public class Elenco_Raccomandate_In_Distinta
        {
            public string CodeRacc { get; set; }
            public string FileName { get; set; }
            public DateTime? DataSpedizione { get; set; }
        }

        public class Dettaglio_Distinta
        {
            public string numeroDistinta { get; set; }
            public int totLettere { get; set; }
            public string fileName { get; set; }
            public DateTime? DataSpedizione { get; set; }
        }
    }
}
