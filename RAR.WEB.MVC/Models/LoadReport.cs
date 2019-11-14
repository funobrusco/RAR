using System.Collections.Generic;

namespace RAR.WEB.MVC.Models
{

    public class LoadReport
    {
        public IDictionary<string, string> dictionaryOfFiles = new Dictionary<string, string>();
        public string LoadReportText { get; set; }
    }


}
