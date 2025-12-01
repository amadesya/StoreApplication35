using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StoreApplication35.Pages.Products
{
    public class AuthPageModel : PageModel
    {
        protected string UserRole => HttpContext.Session.GetString("UserRole");
        public void OnGet()
        {

        }
    }
}
