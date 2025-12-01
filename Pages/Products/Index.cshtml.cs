using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApplication35.Models;

namespace StoreApplication35.Pages.Products
{
    public class IndexModel : AuthPageModel
    {
        private readonly StoreApplication35.Contexts.Dbde3512Context _context;

        public IndexModel(StoreApplication35.Contexts.Dbde3512Context context)
        {
            _context = context;
        }

        public IList<Product> Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            if (HasRole() != null)
            {
                Product = await _context.Products
                    .Include(p => p.Manufacturer)
                    .Include(p => p.Supplier).ToListAsync();

                return Page();
            }
            return Page();
        }
    }
}
