using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreApplication35.Contexts;
using StoreApplication35.Models;

namespace StoreApplication35.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly StoreApplication35.Contexts.Dbde3512Context _context;

        public CreateModel(StoreApplication35.Contexts.Dbde3512Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Name");
        ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //Удалить код ниже
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            Product.Id = _context.Products.Max(p => p.Id) + 1;  
            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
