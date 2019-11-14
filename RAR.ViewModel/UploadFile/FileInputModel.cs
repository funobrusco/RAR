using Microsoft.AspNetCore.Http;
namespace RAR.ViewModel.UploadFile
{
    public class FileInputModel
    {
        public IFormFile FileToUpload { get; set; }
    }
}
