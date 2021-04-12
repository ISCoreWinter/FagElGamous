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

        public IActionResult DataDisplay(int pageNum = 1)
        {
            IEnumerable<BurialRecords> records = _context.BurialRecords;

            //var filters = new Filters(id);
            //ViewBag.Filters = filters;
            //ViewBag.Categories = _context.Categories.ToList();
            //ViewBag.Statuses = _context.Statuses.ToList();
            //ViewBag.DueFilters = Filters.DueFilterValues;

            //IQueryable<BurialRecords> query = _context.BurialRecords
            //    .Include(t => t.Category).Include(t => t.Status);

            //if (filters.HasCategory)
            //{
            //    query = query.Where(t => t.CategoryId == filters.CategoryId);
            //}

            //if (filters.HasStatus)
            //{
            //    query = query.Where(t => t.StatusId == filters.StatusId);
            //}

            //if (filters.HasDue)
            //{
            //    var today = DateTime.Today;

            //    if (filters.IsPast)
            //        query = query.Where(t => t.DueDate < today);
            //    else if (filters.IsFuture)
            //        query = query.Where(t => t.DueDate > today);
            //    else if (filters.IsToday)
            //        query = query.Where(t => t.DueDate == today);
            //}

            //var tasks = query.OrderBy(t => t.DueDate).ToList();

            //return View(tasks);

            return View(new DataListViewModel
            {
                pagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = 20,
                    TotalNumItems = records.Count()
                },

                records = records.OrderBy(r => r.Area).Skip((pageNum - 1) * 20).Take(20) 
            });
        }

        //[HttpPost]
        //public IActionResult Filter(string[] filter)
        //{
        //    string id = string.Join('-', filter);
        //    return RedirectToAction("DataDisplay", new { ID = id });
        //}

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
