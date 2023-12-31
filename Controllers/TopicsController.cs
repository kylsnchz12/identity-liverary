﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using liveraryIdentity.Data;
using liveraryIdentity.Models;
using liveraryIdentity.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace liveraryIdentity.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class TopicsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TopicsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Topics
        public async Task<IActionResult> Index(int trainingId)
        {
            var topics = await _context.Topics
            .Where(topic => topic.TrainingID == trainingId)
            .ToListAsync();

            return View(topics);
        }

        // GET: Topics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Topics == null)
            {
                return NotFound();
            }

            var topic = await _context.Topics
                .FirstOrDefaultAsync(m => m.ID == id);
            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        // GET: Topics/Create
        public IActionResult Create(int? trainingId)
        {
            if (!trainingId.HasValue)
            {
                return RedirectToAction("Index");
            }

            var training = _context.Trainings.FirstOrDefault(t => t.ID == trainingId.Value);
            
            ViewBag.TrainingID = trainingId.Value;
            ViewBag.TrainingTitle = training.Title;

            return View();
        }

        // POST: Topics/Create
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("ID,TrainingID,Title,Description")] Topic topic)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(topic);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(topic);
        // }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddTopicViewModel addTopicRequest)
        {   
            var topic = new Topic()
            {
                Title = addTopicRequest.Title,
                Description = addTopicRequest.Description,
                TrainingID = addTopicRequest.TrainingID
            };

            _context.Add(topic);
            await _context.SaveChangesAsync();
            return RedirectToAction("Training", "Home", new { id = addTopicRequest.TrainingID });
        }

        // GET: Topics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Topics == null)
            {
                return NotFound();
            }

            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
            {
                return NotFound();
            }
            return View(topic);
        }

        // POST: Topics/Edit/5
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, [Bind("ID,TrainingID,Title,Description")] Topic topic)
        // {
        //     if (id != topic.ID)
        //     {
        //         return NotFound();
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(topic);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!TopicExists(topic.ID))
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
        //     return View(topic);
        // }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Topic topicRequest)
        {
            var topic = await _context.Topics.FindAsync(topicRequest.ID);

            if(topic != null)
            {
                topic.Title = topicRequest.Title;
                topic.Description = topicRequest.Description;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { trainingId = topic.TrainingID });
            }
            return RedirectToAction(nameof(Index), new { trainingId = topic.TrainingID }); 
        }

        // GET: Topics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Topics == null)
            {
                return NotFound();
            }

            var topic = await _context.Topics
                .FirstOrDefaultAsync(m => m.ID == id);
            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        // POST: Topics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Topics == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Topics'  is null.");
            }
            var topic = await _context.Topics.FindAsync(id);
            if (topic != null)
            {
                _context.Topics.Remove(topic);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { trainingId = topic.TrainingID });
        }

        private bool TopicExists(int id)
        {
          return (_context.Topics?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
