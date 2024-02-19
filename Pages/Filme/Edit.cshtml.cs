using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_final.Data;
using Proiect_final.Models;

namespace Proiect_final.Pages.Filme 
{
    public class EditModel : FilmCategoriesPageModel
    {
        private readonly Proiect_final.Data.Proiect_finalContext _context;

        public EditModel(Proiect_final.Data.Proiect_finalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Film Film { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Film == null)
            {
                return NotFound();
            }

            Film = await _context.Film
                 .Include(b => b.Distribuitor)
                 .Include(b => b.FilmCategories).ThenInclude(b => b.Category)
                 .AsNoTracking()
                 .FirstOrDefaultAsync(m => m.ID == id);

            if (Film == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Film);

            ViewData["DistribuitorID"] = new SelectList(_context.Distribuitor, "ID",
       "NumeDistribuitor.");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Film).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmExists(Film.ID))
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

        private bool FilmExists(int id)
        {
          return (_context.Film?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
