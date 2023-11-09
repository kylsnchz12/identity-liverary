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
    public class IndexModel : PageModel
    {
        private readonly liveraryIdentity.Data.ApplicationDbContext _context;

        public IndexModel(liveraryIdentity.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Topic> Topic { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Topics != null)
            {
                Topic = await _context.Topics.ToListAsync();
            }
        }
    }
}
