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

        [BindProperty(SupportsGet = true)]
        public string Search {  get; set; }

        [BindProperty(SupportsGet = true)]
        public string Sort {  get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (HasRole() is IActionResult result)
                return result;
            
            Product = await _context.Products
                .Include(p => p.Manufacturer)
                .Include(p => p.Supplier).ToListAsync();

            if (Search != null)
                Product = Product.Where(p => p.Article.Contains(Search) ||
                p.Title.Contains(Search))
                    .ToList();

            if (Sort != null && Sort == "price")
                Product = Product
                    .OrderBy(p => p.Price)
                    .ToList();
            if (Sort != null && Sort == "price_desc")
                Product = Product
                    .OrderByDescending(p => p.Price)
                    .ToList();
            
            return Page();
        }
    }
}
