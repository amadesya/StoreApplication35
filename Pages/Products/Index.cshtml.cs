using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StoreApplication35.Contexts;
using StoreApplication35.Models;

namespace StoreApplication35.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly StoreApplication35.Contexts.Dbde3512Context _context;

        public IndexModel(StoreApplication35.Contexts.Dbde3512Context context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public string UserRole { get; set; }    

        public async Task<IActionResult> OnGetAsync()
        {
            UserRole = HttpContext.Session.GetString("UserRole");
            if (string.IsNullOrEmpty(UserRole))
            {
                return RedirectToPage("../Login");
            }

            Product = await _context.Products
                .Include(p => p.Manufacturer)
                .Include(p => p.Supplier).ToListAsync();
            return Page();
        }
    }
}
