using Microsoft.AspNetCore.Http;

namespace RAR.WEB.MVC.Models.UploadFile
{
    public class FileInputModel
    {
        public IFormFile FileToUpload { get; set; }
    }
}
