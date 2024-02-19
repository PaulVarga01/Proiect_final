using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_final.Data;
using Proiect_final.Models;

namespace Proiect_final.Pages.Filme
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_final.Data.Proiect_finalContext _context;

        public DetailsModel(Proiect_final.Data.Proiect_finalContext context)
        {
            _context = context;
        }

      public Film Film { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Film == null)
            {
                return NotFound();
            }

            var film = await _context.Film.FirstOrDefaultAsync(m => m.ID == id);
            if (film == null)
            {
                return NotFound();
            }
            else 
            {
                Film = film;
            }
            return Page();
        }
    }
}
