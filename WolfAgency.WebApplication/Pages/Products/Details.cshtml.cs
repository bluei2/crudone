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
    public class DetailsModel : PageModel
    {
        private readonly WolfAgencyWebApplication.Data.ApplicationDbContext _context;

        public DetailsModel(WolfAgencyWebApplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
