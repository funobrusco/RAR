using System.Collections.Generic;

namespace RAR.ViewModel
{
    public class LoadReport
    {
        public IDictionary<string, string> DictionaryOfFiles = new Dictionary<string, string>();
        public string LoadReportText { get; set; }
    }
}
