using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Application.Repositories.Context;
using Application.Repositories.Entities;

namespace Application.Pages.Main
{
    public class IndexModel : PageModel
    {
        private readonly Application.Repositories.Context.AppDbContext _context;

        public IndexModel(Application.Repositories.Context.AppDbContext context)
        {
            _context = context;
        }

        public IList<VaccinePackage> VaccinePackage { get;set; } = default!;

        public async Task OnGetAsync()
        {
            VaccinePackage = await _context.VaccinePackages
                .Include(v => v.CreatedByUser).ToListAsync();
        }
    }
}
