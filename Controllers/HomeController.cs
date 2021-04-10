using FagElGamous.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Web;
using Amazon.S3.Model;
using System.Threading;

namespace FagElGamous.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IdentityContext _identity;
        private CancellationToken cancellationToken;

        public HomeController(ILogger<HomeController> logger, IdentityContext identity)
        {
            _logger = logger;
            _identity = identity;
        }

        //return the view with a form to add data
        [HttpGet]
        [Authorize(Roles="Researchers")]
        public IActionResult AddDataset()
        {
            return View();
        }

        //return the home page
        public IActionResult Index()
        {
            return View();
        }

        //return the view that allows for everyone to view the data
        public async Task<IActionResult> DataDisplay()
        {
            string bucket = "fagelgamousuploads";
            string key = "Photos/65-top.JPG";

            GetObjectResponse response = await s3upload.ReadObjectData(bucket, key);

            await response.WriteResponseStreamToFileAsync("./wwwroot/pics/display.jpg", true, cancellationToken);

            return View();
        }

        //controller for the photo upload
        [HttpPost]
        public async Task<IActionResult> AddDataset(FileUpload FileUpload)
        {
            using (var memoryStream = new MemoryStream())
            {
                await FileUpload.FormFile.CopyToAsync(memoryStream);

                if (memoryStream != null)
                {
                    await s3upload.UploadFileAsync(memoryStream, "fagelgamousuploads", "Photos/" + FileUpload.FormFile.FileName);
                }
                else
                {
                    ModelState.AddModelError("File", "Please Select a File");
                }
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
