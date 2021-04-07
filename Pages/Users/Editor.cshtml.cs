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
    public class EditorModel : PageModel
    {
        public UserManager<IdentityUser> UserManager;
        public EditorModel(UserManager<IdentityUser> usrManager)
        {
            UserManager = usrManager;
        }
        [BindProperty]
        [Required]
        public string Id { get; set; }
        [BindProperty]
        [Required]
        public string UserName { get; set; }
        [BindProperty]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public async Task OnGetAsync(string id)
        {
            IdentityUser user = await UserManager.FindByIdAsync(id);
            Id = user.Id; UserName = user.UserName; Email = user.Email;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await UserManager.FindByIdAsync(Id);
                user.UserName = UserName;
                user.Email = Email;
                IdentityResult result = await UserManager.UpdateAsync(user);
                if (result.Succeeded && !String.IsNullOrEmpty(Password))
                {
                    await UserManager.RemovePasswordAsync(user);
                    result = await UserManager.AddPasswordAsync(user, Password);
                }
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