using liveraryIdentity.Data;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging;
using System.Linq;

namespace liveraryIdentity.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index(string searchTerm)
        {
            var results = _context.Trainings.Where(t => t.Title.Contains(searchTerm));

            return View(results);
        }
    }
}
