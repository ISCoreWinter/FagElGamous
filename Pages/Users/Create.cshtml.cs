using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FagElGamous.Pages.Users
{
    public class CreateModel : PageModel
    {
        public UserManager<IdentityUser> UserManager;
        public CreateModel(UserManager<IdentityUser> usrManager)
        {
            UserManager = usrManager;
        }
        [BindProperty]
        [Required]
        public string UserName { get; set; }
        [BindProperty]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [BindProperty]
        [Required]
        public string Password { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser { UserName = UserName, Email = Email };
                IdentityResult result = await UserManager.CreateAsync(user, Password);
                if (result.Succeeded)
                {
                    return RedirectToPage("List");
                }
                foreach (IdentityError err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }
            return Page();
        }
    }
}
