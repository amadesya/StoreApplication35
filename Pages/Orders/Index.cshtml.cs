using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StoreApplication35.Contexts;
using StoreApplication35.Models;
using StoreApplication35.Pages.Products;

namespace StoreApplication35.Pages.Orders
{
    public class IndexModel : AuthPageModel
    {
        private readonly StoreApplication35.Contexts.Dbde3512Context _context;

        public IndexModel(StoreApplication35.Contexts.Dbde3512Context context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            if (HasRole() is IActionResult result)
                return result;

            Order = await _context.Orders
                .Include(o => o.User).ToListAsync();
            return Page();
        }
    }
}
