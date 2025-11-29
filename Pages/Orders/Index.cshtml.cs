using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StoreApplication35.Contexts;
using StoreApplication35.Models;

namespace StoreApplication35.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly StoreApplication35.Contexts.Dbde3512Context _context;

        public IndexModel(StoreApplication35.Contexts.Dbde3512Context context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Order = await _context.Orders
                .Include(o => o.User).ToListAsync();
        }
    }
}
