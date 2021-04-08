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

namespace FagElGamous.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IdentityContext _identity;

        public HomeController(ILogger<HomeController> logger, IdentityContext identity)
        {
            _logger = logger;
            _identity = identity;
        }

        //return the view that allows for everyone to view the data
        public IActionResult DataDisplay()
        {
            return View();
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

        //controller for the photo upload
        [HttpPost]
        public async Task<IActionResult> UploadFiles(IFormFile file)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (file != null)
                    {
                        string path = Path.Combine("./Uploads", Path.GetFileName(file.FileName));
                        using (Stream fileStream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }

                        ViewBag.FileStatus = "File Uploaded Successfully";
                    }
                    if (file == null)
                    {
                        ViewBag.FileStatus = "Error: Please Select a File";
                    }
                }
                catch
                {
                    ViewBag.FileStatus = "Error While Uploading File";
                }
            }

            return View("AddDataset");
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
