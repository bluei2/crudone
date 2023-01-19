using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WolfAgencyWebApplication.Data;
using WolfAgencyWebApplication.Models;

namespace WolfAgencyWebApplication.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly WolfAgencyWebApplication.Data.ApplicationDbContext _context;

        public IndexModel(WolfAgencyWebApplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Product != null)
            {
                Product = await _context.Product.ToListAsync();
            }
        }
    }
}
