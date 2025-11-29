using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreApplication35.Contexts;
using StoreApplication35.Models;

namespace StoreApplication35.Pages
{
    public class LoginModel : PageModel
    {
        private readonly StoreApplication35.Contexts.Dbde3512Context _context;

        public LoginModel(StoreApplication35.Contexts.Dbde3512Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; } = default!;

        //// For more information, see https://aka.ms/RazorPagesCRUD.
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.Users.Add(User);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./Index");
        //}

        // логин
        public async Task<IActionResult> OnPostLoginAsync()
        {
            var user = _context.Users.FirstOrDefault(u => u.Login == User.Login);
            if (user != null && user.Password == User.Password)
            {
                HttpContext.Session.SetString("UserRole", user.Role);
                HttpContext.Session.SetString("UserName", user.FullName);
                return RedirectToPage("Products/Index");
            }
            return Page();
        }
        // вход гостя:
        public IActionResult OnPostGuest()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.SetString("UserRole", "Гость");
            return RedirectToPage("Products/Index");
        }
        // выход
        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("Products/Index"); // return Page();
        }
    }
}
