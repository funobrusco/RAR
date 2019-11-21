using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RAR.WEB.MVC.Models;
using RAR.WEB.MVC.Models.UploadFile;
using RAR.WEB.MVC.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RAR.WEB.MVC.Controllers
{
    public class UploadFileController : CommonController
    {
        private readonly IFileProvider _fileProvider;
        private readonly ILogger _loggerUpload;
        private readonly string _uploadFolder;
        private readonly string _outputFolder;
        private readonly string _baseAddress;
        //private readonly IConfiguration _configuration;
        //private List<string> filenamesList;


        public UploadFileController(IOptions<RARSettings> app, IConfiguration configuration, IHttpContextAccessor httpContextAccessor,
            IHostingEnvironment hostingEnvironment, IFileProvider fileProvider, ILogger<UploadFileController> logger)
            : base(app, configuration, logger, hostingEnvironment, httpContextAccessor)
        {
            _fileProvider = fileProvider;
            //_configuration = configuration;
            _loggerUpload = logger;

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
                _loggerUpload.LogError("Exception trying to create upload folder: " + ex.Message);
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
                if (files != null && files.Any())
                {
                    using (var handler = new HttpClientHandler())
                    {
                        handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                        using (var client = new HttpClient(handler))
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
                                _loggerUpload.LogError("UploadFiles Exception in upload files: " + ex.ToString());
                                return StatusCode(500); // 500 generic server error
                            }
                        }
                    }
                }
                _loggerUpload.LogError("Error 400 : Bad request.");
                return View("NoFilesUploaded"); // 400  bad request
            }
            catch (Exception ex)
            {
                _loggerUpload.LogError("Error 500 : Generic server error: " + ex.ToString());
                return StatusCode(500); // 500  generic server error
            }
        }

        [HttpGet("AggiornaDatiAsync")]
        public async Task<IActionResult> AggiornaDatiAsync()
        {
            try
            {
                Outcome response = new Outcome();
                // call other method in API 
                using (var handler = new HttpClientHandler())
                {
                    handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                    using (var client = new HttpClient(handler))
                    {
                        {
                            client.BaseAddress = new Uri(_baseAddress);
                            var result = await client.GetAsync("LoadMissing/AggiornaRacc");
                            response.Response = (result.Content.ReadAsStringAsync().Result);
                        }
                    }
                }
                return View("Outcome", response);
            }
            catch (Exception e)
            {
                return Error(e.ToString());
            }
        }
    }
}
