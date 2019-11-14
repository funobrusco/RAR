using System.Collections.Generic;

namespace RAR.WEB.MVC.Models.UploadFile
{ 
    public class FileDetails
    {
        public string Name { get; set; }
        public string Path { get; set; }

    }

    public class FilesViewModel
    {
        public List<FileDetails> Files { get; set; } 
            = new List<FileDetails>();
        public string ResultText { get; set; }
        public string ResultSummaryFile { get; set;  }
    }
}
