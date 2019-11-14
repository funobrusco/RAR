using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RAR.WEB.MVC.Models;
using RAR.WEB.MVC.Models.UploadFile;
using RAR.WEB.MVC.Utility;

namespace RAR.WEB.MVC.Controllers
{
    public class UploadFileController : Controller
    {
        private readonly IFileProvider _fileProvider;
        private readonly ILogger _logger;
        private readonly string _uploadFolder;
        private readonly string _outputFolder;
        private readonly string _baseAddress;
        private readonly IConfiguration _configuration;
        //private List<string> filenamesList;


        public UploadFileController(IFileProvider fileProvider, IConfiguration configuration, ILogger<UploadFileController> logger)
        {
            _fileProvider = fileProvider;
            _configuration = configuration;
            _logger = logger;

            _uploadFolder = _configuration["UploadFolder"];
            _outputFolder = _configuration["OutputFolder"];
            _baseAddress = ApplicationSettings.WebApiUrl;
            // Create upload folder if not there is
            try
            {
                Directory.CreateDirectory(_uploadFolder);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception trying to create upload folder: " + ex.Message);
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            try
            {
                if (files != null && files.Count > 0)
                {
                    using (var client = new HttpClient())
                    {
                        try
                        {
                            var model = new FilesViewModel();
                            MultipartFormDataContent multiContent = new MultipartFormDataContent();

                            foreach (var formfile in files)
                            {
                                client.BaseAddress = new Uri(_baseAddress);
                                byte[] data;
                                using (var br = new BinaryReader(formfile.OpenReadStream()))
                                    data = br.ReadBytes((int)formfile.OpenReadStream().Length);
                                ByteArrayContent bytes = new ByteArrayContent(data);

                                multiContent.Add(bytes, "file", formfile.FileName);
                                model.Files.Add(new FileDetails { Name = formfile.FileName });
                            }
                            var result = await client.PostAsync("LoadMissing/UploadFiles", multiContent);

                            LoadReport dictionaryFiles = JsonConvert.DeserializeObject<LoadReport>(await result.Content.ReadAsStringAsync());
                            return dictionaryFiles.dictionaryOfFiles.Count > 0 ? View("Files", dictionaryFiles) : View("NoFilesUploaded");
                        }
                        catch (Exception ex)
                        {
                            _logger.LogInformation("Exception in upload files: " + ex.Message);
                            return StatusCode(500); // 500 generic server error
                        }
                    }
                }
                _logger.LogInformation("Error 400 : Bad request.");
                return View("NoFilesUploaded"); // 400  bad request
            }
            catch (Exception)
            {
                _logger.LogInformation("Error 500 : Generic server error.");
                return StatusCode(500); // 500  generic server error

            }
        }

        [HttpGet("AggiornaDatiAsync")]
        public async Task<IActionResult> AggiornaDatiAsync()
        {
            Outcome response = new Outcome();
            // call other method in API 
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                var result = await client.GetAsync("LoadMissing/AggiornaRacc");
                response.Response = (result.Content.ReadAsStringAsync().Result);

            }
            return View("Outcome", response);
        }
    }
}
