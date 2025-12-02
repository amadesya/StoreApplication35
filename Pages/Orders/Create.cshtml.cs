using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreApplication35.Contexts;
using StoreApplication35.Models;
using StoreApplication35.Pages.Products;

namespace StoreApplication35.Pages.Orders
{
    public class CreateModel : AuthPageModel
    {
        private readonly StoreApplication35.Contexts.Dbde3512Context _context;

        public CreateModel(StoreApplication35.Contexts.Dbde3512Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (CanEdit() is IActionResult result)
                return result;

            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
