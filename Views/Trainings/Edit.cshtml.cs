using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using liveraryIdentity.Data;
using liveraryIdentity.Models;

namespace liveraryIdentity.Views.Trainings
{
    public class EditModel : PageModel
    {
        private readonly liveraryIdentity.Data.ApplicationDbContext _context;

        public EditModel(liveraryIdentity.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Training Training { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Trainings == null)
            {
                return NotFound();
            }

            var training =  await _context.Trainings.FirstOrDefaultAsync(m => m.ID == id);
            if (training == null)
            {
                return NotFound();
            }
            Training = training;
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

            _context.Attach(Training).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingExists(Training.ID))
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

        private bool TrainingExists(int id)
        {
          return (_context.Trainings?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
