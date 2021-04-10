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
using FagElGamous.Models.ViewModels;

namespace FagElGamous.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IdentityContext _identity;
        private CancellationToken cancellationToken;
        private fagelgamousContext _context;

        public HomeController(ILogger<HomeController> logger, IdentityContext identity, fagelgamousContext context)
        {
            _logger = logger;
            _identity = identity;
            _context = context;
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
        //public async Task<IActionResult> DataDisplay()
        //{
        //    string bucket = "fagelgamousuploads";
        //    string key = "Photos/65-top.JPG";

        //    GetObjectResponse response = await s3upload.ReadObjectData(bucket, key);

        //    await response.WriteResponseStreamToFileAsync("./wwwroot/pics/display.jpg", true, cancellationToken);


        //    return View();
        //}

        [HttpGet]
        public IActionResult DataDisplay(int pageNum = 1, string? category = null)
        {
            IEnumerable<BurialRecords> records = _context.BurialRecords;

            int pageSize = 18;

            return View(new DataListViewModel
            {
                pagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalNumItems = records.Count()
                },

                records = records.OrderBy(r => r.Area).Skip((pageNum - 1) * pageSize).Take(pageSize)
            });
        }

        //to view more data on that item
        [HttpPost]
        public IActionResult DataDisplay(int BurialId)
        {
                ViewAllDataViewModel BurialDataAll = new ViewAllDataViewModel
                {
                    BurialRecord = _context.BurialRecords.Where(x => x.BurialId == BurialId).FirstOrDefault(),
                    BioSamples = _context.BiologicalSamples.Where(x => x.BurialId == BurialId),
                    Photos = _context.Photos.Where(x => x.BurialId == BurialId),
                    BodyMeasurements = _context.BodyMeasurements.Where(x => x.BurialId == BurialId).FirstOrDefault(),
                    CarbonDating = _context.CarbonDating.Where(x => x.BurialId == BurialId).FirstOrDefault(),
                    Cranial = _context.Cranial.Where(x => x.BurialId == BurialId).FirstOrDefault()
                };

                return View("ViewAllData", BurialDataAll);
        }

        public IActionResult ViewAllData(int burialId)
        {
            ViewAllDataViewModel BurialDataAll = new ViewAllDataViewModel
            {
                BurialRecord = _context.BurialRecords.Where(x => x.BurialId == burialId).FirstOrDefault(),
                BioSamples = _context.BiologicalSamples.Where(x => x.BurialId == burialId),
                Photos = _context.Photos.Where(x => x.BurialId == burialId),
                BodyMeasurements = _context.BodyMeasurements.Where(x => x.BurialId == burialId).FirstOrDefault(),
                CarbonDating = _context.CarbonDating.Where(x => x.BurialId == burialId).FirstOrDefault(),
                Cranial = _context.Cranial.Where(x => x.BurialId == burialId).FirstOrDefault()
            };

            return View(BurialDataAll);
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
