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
    public class DetailsModel : PageModel
    {
        private readonly liveraryIdentity.Data.ApplicationDbContext _context;

        public DetailsModel(liveraryIdentity.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
