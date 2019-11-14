using System.Collections.Generic;

namespace RAR.ViewModel.UploadFile
{
    public class FilesViewModel
    {
        public List<FileDetails> Files { get; set; } = new List<FileDetails>();
        public string ResultText { get; set; }
        public string ResultSummaryFile { get; set;  }
    }
}
