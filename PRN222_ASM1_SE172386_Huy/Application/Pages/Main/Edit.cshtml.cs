using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Application.Repositories.Context;
using Application.Repositories.Entities;

namespace Application.Pages.Main
{
    public class EditModel : PageModel
    {
        private readonly Application.Repositories.Context.AppDbContext _context;

        public EditModel(Application.Repositories.Context.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public VaccinePackage VaccinePackage { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccinepackage =  await _context.VaccinePackages.FirstOrDefaultAsync(m => m.PackageID == id);
            if (vaccinepackage == null)
            {
                return NotFound();
            }
            VaccinePackage = vaccinepackage;
           ViewData["CreatedByUserID"] = new SelectList(_context.System_UserAccounts, "UserAccountID", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(VaccinePackage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VaccinePackageExists(VaccinePackage.PackageID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VaccinePackageExists(int id)
        {
            return _context.VaccinePackages.Any(e => e.PackageID == id);
        }
    }
}
