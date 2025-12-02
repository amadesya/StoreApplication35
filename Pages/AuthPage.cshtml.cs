using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StoreApplication35.Pages.Products
{
    public class AuthPageModel : PageModel
    {
        public string UserRole => HttpContext.Session.GetString("UserRole");

        public bool IsAdmin => UserRole == "Администратор";

        protected IActionResult HasRole()
        {
            if (string.IsNullOrEmpty(UserRole))
                return RedirectToPage("/Login");

            return null;
        }

        protected IActionResult CanEdit()
        {
            if (!IsAdmin)
                return RedirectToPage("/Login");

            return null;
        }
    }
}
