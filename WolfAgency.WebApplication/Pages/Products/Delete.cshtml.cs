using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WolfAgencyWebApplication.Data;
using WolfAgencyWebApplication.Models;

namespace WolfAgencyWebApplication.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly WolfAgencyWebApplication.Data.ApplicationDbContext _context;

        public DeleteModel(WolfAgencyWebApplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            else 
            {
                Product = product;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }
            var product = await _context.Product.FindAsync(id);

            if (product != null)
            {
                Product = product;
                _context.Product.Remove(Product);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage(".././Index");
        }
    }
}
