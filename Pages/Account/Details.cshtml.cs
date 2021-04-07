using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FagElGamous.Pages.Account
{
    public class DetailsModel : PageModel
    {
        private UserManager<IdentityUser> userManager;
        public string Cookie { get; set; }
        public DetailsModel(UserManager<IdentityUser> manager)
        {
            userManager = manager;
        }
        public IdentityUser IdentityUser { get; set; }
        public async Task OnGetAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                IdentityUser = await userManager.FindByNameAsync(User.Identity.Name);
                Cookie = Request.Cookies[".AspNetCore.Identity.Application"];
            }
        }
    }
}
