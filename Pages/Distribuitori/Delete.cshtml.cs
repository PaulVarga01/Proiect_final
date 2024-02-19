using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_final.Data;
using Proiect_final.Models;

namespace Proiect_final.Pages.Distribuitori
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_final.Data.Proiect_finalContext _context;

        public DeleteModel(Proiect_final.Data.Proiect_finalContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Distribuitor Distribuitor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Distribuitor == null)
            {
                return NotFound();
            }

            var distribuitor = await _context.Distribuitor.FirstOrDefaultAsync(m => m.ID == id);

            if (distribuitor == null)
            {
                return NotFound();
            }
            else 
            {
                Distribuitor = distribuitor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Distribuitor == null)
            {
                return NotFound();
            }
            var distribuitor = await _context.Distribuitor.FindAsync(id);

            if (distribuitor != null)
            {
                Distribuitor = distribuitor;
                _context.Distribuitor.Remove(Distribuitor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
