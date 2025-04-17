using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Application.Repositories.Context;
using Application.Repositories.Entities;

namespace Application.Pages.Main
{
    public class CreateModel : PageModel
    {
        private readonly Application.Repositories.Context.AppDbContext _context;

        public CreateModel(Application.Repositories.Context.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CreatedByUserID"] = new SelectList(_context.System_UserAccounts, "UserAccountID", "Email");
            return Page();
        }

        [BindProperty]
        public VaccinePackage VaccinePackage { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.VaccinePackages.Add(VaccinePackage);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
