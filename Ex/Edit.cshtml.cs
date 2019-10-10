using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KenJP2._0.Data;

namespace KenJP2._0.Pages.Ex
{
    public class EditModel : PageModel
    {
        private readonly KenJP2._0.Data.ApplicationDbContext _context;

        public EditModel(KenJP2._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Exhibits Exhibits { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Exhibits = await _context.Exhibits.FirstOrDefaultAsync(m => m.EID == id);

            if (Exhibits == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Exhibits).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExhibitsExists(Exhibits.EID))
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

        private bool ExhibitsExists(int id)
        {
            return _context.Exhibits.Any(e => e.EID == id);
        }
    }
}
