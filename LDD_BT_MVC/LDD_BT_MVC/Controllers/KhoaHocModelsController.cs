using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LDD_BT_MVC.Data;
using LDD_BT_MVC.Models;

namespace LDD_BT_MVC.Controllers
{
    public class KhoaHocModelsController : Controller
    {
        private readonly AppDbContext _context;

        public KhoaHocModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: KhoaHocModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Courses.ToListAsync());
        }

        // GET: KhoaHocModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khoaHocModel = await _context.Courses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (khoaHocModel == null)
            {
                return NotFound();
            }

            return View(khoaHocModel);
        }

        // GET: KhoaHocModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KhoaHocModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] KhoaHocModel khoaHocModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khoaHocModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khoaHocModel);
        }

        // GET: KhoaHocModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khoaHocModel = await _context.Courses.FindAsync(id);
            if (khoaHocModel == null)
            {
                return NotFound();
            }
            return View(khoaHocModel);
        }

        // POST: KhoaHocModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] KhoaHocModel khoaHocModel)
        {
            if (id != khoaHocModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khoaHocModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhoaHocModelExists(khoaHocModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(khoaHocModel);
        }

        // GET: KhoaHocModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khoaHocModel = await _context.Courses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (khoaHocModel == null)
            {
                return NotFound();
            }

            return View(khoaHocModel);
        }

        // POST: KhoaHocModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var khoaHocModel = await _context.Courses.FindAsync(id);
            if (khoaHocModel != null)
            {
                _context.Courses.Remove(khoaHocModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhoaHocModelExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
    }
}
