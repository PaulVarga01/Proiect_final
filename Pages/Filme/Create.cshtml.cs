using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_final.Data;
using Proiect_final.Models;

namespace Proiect_final.Pages.Filme
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_final.Data.Proiect_finalContext _context;

        public CreateModel(Proiect_final.Data.Proiect_finalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DistribuitorID"] = new SelectList(_context.Set<Distribuitor>(), "DistribuitorID");
            return Page();
        }

        [BindProperty]
        public Film Film { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Film == null || Film == null)
            {
                return Page();
            }

            _context.Film.Add(Film);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
