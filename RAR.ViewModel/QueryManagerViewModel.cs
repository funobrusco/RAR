using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RAR.ViewModel
{
    public class QueryManagerViewModel
    {
        [Display(Name = "Elenco query")]
        public IEnumerable<QueryViewModel> Querys { get; set; }

        [Display(Name = "Parametri query")]
        public Dictionary<string, string> QueryParameters { get; set; }

        [Display(Name = "Query selezionata")]
        public QueryViewModel SelectedQuery { get; set; }

        [Display(Name = "Resultset")]
        public string[][] Resultset { get; set; }

        public IEnumerable<string> prova;
    }
}
