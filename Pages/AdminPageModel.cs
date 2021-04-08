using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Pages
{
    //this is used to be inherited in order to allow only Admins to access certain sites
    [Authorize(Roles="Admins")]
    public class AdminPageModel : PageModel
    {
    }

    //this model class is to be used to limit acces to cites for only researchers
    [Authorize(Roles="Researchers")]
    public class ResearcherPageModel : PageModel
    {

    }
}
