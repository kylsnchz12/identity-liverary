using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using liveraryIdentity.Data;
using liveraryIdentity.Models;

namespace liveraryIdentity.Views.Trainings
{
    public class DeleteModel : PageModel
    {
        private readonly liveraryIdentity.Data.ApplicationDbContext _context;

        public DeleteModel(liveraryIdentity.Data.ApplicationDbContext context)
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

            var training = await _context.Trainings.FirstOrDefaultAsync(m => m.ID == id);

            if (training == null)
            {
                return NotFound();
            }
            else 
            {
                Training = training;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Trainings == null)
            {
                return NotFound();
            }
            var training = await _context.Trainings.FindAsync(id);

            if (training != null)
            {
                Training = training;
                _context.Trainings.Remove(Training);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
