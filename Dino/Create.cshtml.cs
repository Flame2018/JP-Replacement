using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KenJP2._0.Data;

namespace KenJP2._0.Pages.Dino
{
    public class CreateModel : PageModel
    {
        private readonly KenJP2._0.Data.ApplicationDbContext _context;

        public CreateModel(KenJP2._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["EID"] = new SelectList(_context.Set<Exhibits>(), "EID", "EID");
            return Page();
        }

        [BindProperty]
        public Dinosaurs Dinosaurs { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Dinosaurs.Add(Dinosaurs);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}