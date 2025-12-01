using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StoreApplication35.Pages.Products
{
    public class AuthPageModel : PageModel
    {
        protected string UserRole => HttpContext.Session.GetString("UserRole");

        protected IActionResult HasRole()
        {
            if (string.IsNullOrEmpty(UserRole))
            {
                return RedirectToPage("Login");
            }

            return null;
        }
    }
}
