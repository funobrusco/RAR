
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RAR.API.Controllers;
using RAR.WEB.MVC.Models.UploadFile;
using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Text;


namespace RAR.API.Utility
{
  
    public static class UniqueFilename
    {
        public static string GenerateUniqueFilename(IFormFile file)
        {

            var idfilename = new StringBuilder(Path.GetFileNameWithoutExtension(file.GetFilename()));
            var extension  = Path.GetExtension(file.GetFilename());
            //idfilename.Append(Guid.NewGuid()).Append($"{DateTime.Now:yyyyMMddhhmmss}").Append(extension);  // before format date was yyyyMMddhhmmssfff
            idfilename.Append("_").Append(Guid.NewGuid().ToString("N")).Append(extension);
            return idfilename.ToString();

            // generate unique file name to avoid overwriting existent file
            //var uniqueFileName = Path.GetFileNameWithoutExtension(file.GetFilename());
            //var extension = Path.GetExtension(file.GetFilename());
            // append guid to filename
            //uniqueFileName += Guid.NewGuid();
            // append timestamp
            //uniqueFileName += $"{DateTime.Now:yyyyMMddhhmmssfff}";
            // append extension
            //uniqueFileName += extension
            //return uniqueFileName;
        }
    }
}
