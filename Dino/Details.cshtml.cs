using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KenJP2._0.Data;

namespace KenJP2._0.Pages.Dino
{
    public class DetailsModel : PageModel
    {
        private readonly KenJP2._0.Data.ApplicationDbContext _context;

        public DetailsModel(KenJP2._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Dinosaurs Dinosaurs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dinosaurs = await _context.Dinosaurs
                .Include(d => d.ExhibitID).FirstOrDefaultAsync(m => m.DID == id);

            if (Dinosaurs == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
