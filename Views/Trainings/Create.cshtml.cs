using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using liveraryIdentity.Data;
using liveraryIdentity.Models;

namespace liveraryIdentity.Views.Trainings
{
    public class CreateModel : PageModel
    {
        private readonly liveraryIdentity.Data.ApplicationDbContext _context;

        public CreateModel(liveraryIdentity.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Training Training { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Trainings == null || Training == null)
            {
                return Page();
            }

            _context.Trainings.Add(Training);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
