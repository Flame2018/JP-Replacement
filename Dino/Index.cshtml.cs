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
    public class IndexModel : PageModel
    {
        private readonly KenJP2._0.Data.ApplicationDbContext _context;

        public IndexModel(KenJP2._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Dinosaurs> Dinosaurs { get;set; }

        public async Task OnGetAsync()
        {
            Dinosaurs = await _context.Dinosaurs
                .Include(d => d.ExhibitID).ToListAsync();
        }
    }
}
