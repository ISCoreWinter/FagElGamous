using System;
using System.Linq;
using FagElGamous.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FagElGamous.Components
{
    public class BurialAreaViewComponent : ViewComponent
    {
        private fagelgamousContext context;

        public BurialAreaViewComponent(fagelgamousContext ctx)
        {
            context = ctx;
        }

        public IViewComponentResult Invoke()
        {
            ViewData["SelectedType"] = RouteData?.Values["burialArea"];

            return View(context.BurialRecords
                //.Select(m => m.BurialSubplot)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}