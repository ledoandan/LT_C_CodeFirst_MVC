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
    public class GiaoVienModelsController : Controller
    {
        private readonly AppDbContext _context;

        public GiaoVienModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: GiaoVienModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Teachers.ToListAsync());
        }

        // GET: GiaoVienModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giaoVienModel = await _context.Teachers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (giaoVienModel == null)
            {
                return NotFound();
            }

            return View(giaoVienModel);
        }

        // GET: GiaoVienModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GiaoVienModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] GiaoVienModel giaoVienModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giaoVienModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(giaoVienModel);
        }

        // GET: GiaoVienModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giaoVienModel = await _context.Teachers.FindAsync(id);
            if (giaoVienModel == null)
            {
                return NotFound();
            }
            return View(giaoVienModel);
        }

        // POST: GiaoVienModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] GiaoVienModel giaoVienModel)
        {
            if (id != giaoVienModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giaoVienModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiaoVienModelExists(giaoVienModel.Id))
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
            return View(giaoVienModel);
        }

        // GET: GiaoVienModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giaoVienModel = await _context.Teachers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (giaoVienModel == null)
            {
                return NotFound();
            }

            return View(giaoVienModel);
        }

        // POST: GiaoVienModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var giaoVienModel = await _context.Teachers.FindAsync(id);
            if (giaoVienModel != null)
            {
                _context.Teachers.Remove(giaoVienModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiaoVienModelExists(int id)
        {
            return _context.Teachers.Any(e => e.Id == id);
        }
    }
}
