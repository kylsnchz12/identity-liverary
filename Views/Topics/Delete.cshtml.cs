using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using liveraryIdentity.Data;
using liveraryIdentity.Models;

namespace liveraryIdentity.Views.Topics
{
    public class DeleteModel : PageModel
    {
        private readonly liveraryIdentity.Data.ApplicationDbContext _context;

        public DeleteModel(liveraryIdentity.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Topic Topic { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Topics == null)
            {
                return NotFound();
            }

            var topic = await _context.Topics.FirstOrDefaultAsync(m => m.ID == id);

            if (topic == null)
            {
                return NotFound();
            }
            else 
            {
                Topic = topic;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Topics == null)
            {
                return NotFound();
            }
            var topic = await _context.Topics.FindAsync(id);

            if (topic != null)
            {
                Topic = topic;
                _context.Topics.Remove(Topic);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
