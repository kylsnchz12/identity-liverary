using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using liveraryIdentity.Data;
using liveraryIdentity.Models;
using Microsoft.AspNetCore.Authorization;

namespace liveraryIdentity.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class ResourcesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResourcesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Resources
        public async Task<IActionResult> Index(int topicId)
        {
            var resource = await _context.Resources
            .Where(resource => resource.TopicID == topicId)
            .ToListAsync();

            return View(resource);
        }

        // GET: Resources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Resources == null)
            {
                return NotFound();
            }

            var resource = await _context.Resources
                .FirstOrDefaultAsync(m => m.ID == id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // GET: Resources/Create
        public IActionResult Create(int? topicId, int? trainingId)
        {
            if (!topicId.HasValue)
            {
                return RedirectToAction("Index");
            }

            var topic = _context.Topics.FirstOrDefault(t => t.ID == topicId.Value);

            ViewBag.TopicTitle = topic.Title;
            ViewBag.TopicID = topicId;
            ViewBag.TrainingID = trainingId;
            return View();
        }

        // POST: Resources/Create
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("ID,TopicID,FilePath")] Resource resource)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(resource);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(resource);
        // }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddResourceViewModel addResourceRequest)
        {   
            var resource = new Resource()
            {
                FilePath = addResourceRequest.FilePath,
                TopicID = addResourceRequest.TopicID
            };

            _context.Add(resource);
            await _context.SaveChangesAsync();
            return RedirectToAction("Training", "Home", new { id = addResourceRequest.TrainingId });
        }


        // GET: Resources/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Resources == null)
            {
                return NotFound();
            }

            var resource = await _context.Resources.FindAsync(id);
            if (resource == null)
            {
                return NotFound();
            }
            return View(resource);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Resource resourceRequest)
        {
            var resource = await _context.Resources.FindAsync(resourceRequest.ID);

            if(resource != null)
            {
                resource.TopicID = resourceRequest.TopicID;
                resource.FilePath = resourceRequest.FilePath;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = resourceRequest.TopicID });
            }
            return RedirectToAction(nameof(Index), new { id = resourceRequest.TopicID }); 
        }

        // POST: Resources/Edit/5
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, [Bind("ID,TopicID,FilePath")] Resource resource)
        // {
        //     if (id != resource.ID)
        //     {
        //         return NotFound();
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(resource);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!ResourceExists(resource.ID))
        //             {
        //                 return NotFound();
        //             }
        //             else
        //             {
        //                 throw;
        //             }
        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(resource);
        // }

        // GET: Resources/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Resources == null)
            {
                return NotFound();
            }

            var resource = await _context.Resources
                .FirstOrDefaultAsync(m => m.ID == id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // POST: Resources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int _id)
        {
            if (_context.Resources == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Resources'  is null.");
            }
            var resource = await _context.Resources.FindAsync(_id);
            if (resource != null)
            {
                _context.Resources.Remove(resource);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = _id });
        }

        private bool ResourceExists(int id)
        {
          return (_context.Resources?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
