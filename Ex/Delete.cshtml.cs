using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KenJP2._0.Data;

namespace KenJP2._0.Pages.Ex
{
    public class DeleteModel : PageModel
    {
        private readonly KenJP2._0.Data.ApplicationDbContext _context;

        public DeleteModel(KenJP2._0.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Exhibits = await _context.Exhibits.FindAsync(id);

            if (Exhibits != null)
            {
                _context.Exhibits.Remove(Exhibits);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
