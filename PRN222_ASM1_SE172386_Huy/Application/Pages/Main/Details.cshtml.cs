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
    public class DetailsModel : PageModel
    {
        private readonly Application.Repositories.Context.AppDbContext _context;

        public DetailsModel(Application.Repositories.Context.AppDbContext context)
        {
            _context = context;
        }

        public VaccinePackage VaccinePackage { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccinepackage = await _context.VaccinePackages.FirstOrDefaultAsync(m => m.PackageID == id);

            if (vaccinepackage is not null)
            {
                VaccinePackage = vaccinepackage;

                return Page();
            }

            return NotFound();
        }
    }
}
