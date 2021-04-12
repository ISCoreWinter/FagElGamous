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
        private IGamousRepository _repository;
        public HomeController(ILogger<HomeController> logger, IdentityContext identity, fagelgamousContext context, IGamousRepository repository)
        {
            _logger = logger;
            _identity = identity;
            _context = context;
            _repository = repository;
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
        public async Task<IActionResult> DataDisplay(int BurialId)
        {
            ViewAllDataViewModel BurialDataAll = new ViewAllDataViewModel
            {
                BurialRecord = _context.BurialRecords.Where(x => x.BurialId == BurialId).FirstOrDefault(),
                BioSamples = _context.BiologicalSamples.Where(x => x.BurialId == BurialId),
                Photos = _context.Photos.Where(x => x.BurialId == BurialId),
                BodyMeasurements = _context.BodyMeasurements.Where(x => x.BurialId == BurialId).FirstOrDefault(),
                CarbonDating = _context.CarbonDating.Where(x => x.BurialId == BurialId).FirstOrDefault(),
                Cranial = _context.Cranial.Where(x => x.BurialId == BurialId).FirstOrDefault(),
                MainEntries = _context.MainEntries.Where(x => x.BurialId == BurialId).FirstOrDefault()
            };

            string bucket = "fagelgamousuploads";

            foreach(var x in BurialDataAll.Photos)
            {
                string key = x.Filestring;

                GetObjectResponse response = await s3upload.ReadObjectData(bucket, key);
                await response.WriteResponseStreamToFileAsync($"./wwwroot/{x.Filestring}", true, cancellationToken);
            }

            return View("ViewAllData", BurialDataAll);
        }

        public IActionResult ViewAllData()
        {

            return View();
        }

        //return the view with a form to add data
        [HttpGet]
        [Authorize(Roles = "Researchers")]
        public IActionResult AddDataset()
        {
            return View();
        }

        //controller for the photo upload
        [HttpPost]
        public async Task<IActionResult> AddDataset(PhotoUpload FileUpload)
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
        [HttpGet]
        public IActionResult InputForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult InputForm(InputViewModel input)
        {
            if (ModelState.IsValid)
            {
                _context.MainEntries.Add(input.mainEntry);
                _context.BurialRecords.Add(input.burialRecords);
            }
/*            _context.SaveChanges();
*/
            return View();
        }

        [HttpPost]
        public IActionResult DeleteRecord(long burialId)
        {
            _context.MainEntries.Remove(_context.MainEntries.First(m => m.BurialId == burialId));
            _context.BodyMeasurements.Remove(_context.BodyMeasurements.First(m => m.BurialId == burialId));
            _context.BurialRecords.Remove(_context.BurialRecords.First(m => m.BurialId == burialId));

            _context.SaveChanges();
            return View();
        }

        //edit a movie entry
        [HttpPost]
        public IActionResult EditView(long burialId)
        {
            MainEntries mainEntryEdit = _context.MainEntries.Where(m => m.BurialId == burialId).First();
            BurialRecords burialRecordEdit = _context.BurialRecords.Where(m => m.BurialId == burialId).First();
            BodyMeasurements bodyMeasurementEdit = _context.BodyMeasurements.Where(m => m.BurialId == burialId).First();
            /*          InputViewModel record = _context.MainEntries.Where(m => m.BurialId == burialId).First();
            */
            /*            return View("EditRecord", mainEntryEdit, burialRecordEdit, bodyMeasurementEdit);
            */
            return View();  
        }
        [HttpPost]
/*        public IActionResult EditRecord(MainEntries mainEntryEdit, BurialRecords burialRecordEdit, BodyMeasurements bodyMeasurementEdit)
        {
            _context.Update(record);
            if (ModelState.IsValid)
            {
                _context.SaveChanges();
                return View("Confirmation", _context.MainEntries);

            }
            return View("EditRecord", record);
        }*/
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
