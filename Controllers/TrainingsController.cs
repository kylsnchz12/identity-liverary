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
    public class TrainingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Trainings
        public async Task<IActionResult> Index()
        {
            return _context.Trainings != null ? 
                        View(await _context.Trainings.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Trainings'  is null.");
        }

        // GET: Trainings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Trainings == null)
            {
                return NotFound();
            }

            var training = await _context.Trainings
                .FirstOrDefaultAsync(m => m.ID == id);
            if (training == null)
            {
                return NotFound();
            }

            return View(training);
        }

        // GET: Trainings/Create
        public IActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(_context.Categories, "ID", "Title");
            return View();
        }

        // POST: Trainings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddTrainingViewModel addTrainingRequest)
        {
        
            var training = new Training()
            {
                Title = addTrainingRequest.Title,
                Author = addTrainingRequest.Author,
                Description = addTrainingRequest.Description,
                Thumbnail = addTrainingRequest.Thumbnail,
                CategoryID = addTrainingRequest.CategoryID,
                DateCreated = addTrainingRequest.DateCreated

            };

            _context.Add(training);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Trainings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.CategoryID = new SelectList(_context.Categories, "ID", "Title");
            if (id == null || _context.Trainings == null)
            {
                return NotFound();
            }

            var training = await _context.Trainings.FindAsync(id);
            if (training == null)
            {
                return NotFound();
            }
            return View(training);
        }

        // POST: Trainings/Edit/5
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, [Bind("ID,CategoryID,Title,Author,Description,DateCreated,Thumbnail")] Training training)
        // {
        //     if (id != training.ID)
        //     {
        //         return NotFound();
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(training);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!TrainingExists(training.ID))
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
        //     return View(training);
        // }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Training trainingRequest)
        {
            var training = await _context.Trainings.FindAsync(trainingRequest.ID);

            if(training != null)
            {
                training.Title = trainingRequest.Title;
                training.Description = trainingRequest.Description;
                training.Author = trainingRequest.Author;
                if(trainingRequest.Thumbnail != null){
                    training.Thumbnail = trainingRequest.Thumbnail;
                }
                training.CategoryID = trainingRequest.CategoryID;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index)); 
        }

        // GET: Trainings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Trainings == null)
            {
                return NotFound();
            }

            var training = await _context.Trainings
                .FirstOrDefaultAsync(m => m.ID == id);
            if (training == null)
            {
                return NotFound();
            }

            return View(training);
        }

        // POST: Trainings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Trainings == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Trainings'  is null.");
            }
            var training = await _context.Trainings.FindAsync(id);
            if (training != null)
            {
                _context.Trainings.Remove(training);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingExists(int id)
        {
            return (_context.Trainings?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
