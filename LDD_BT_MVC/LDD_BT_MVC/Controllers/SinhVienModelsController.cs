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
    public class SinhVienModelsController : Controller
    {
        private readonly AppDbContext _context;

        public SinhVienModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SinhVienModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }

        // GET: SinhVienModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVienModel = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sinhVienModel == null)
            {
                return NotFound();
            }

            return View(sinhVienModel);
        }

        // GET: SinhVienModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SinhVienModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] SinhVienModel sinhVienModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sinhVienModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sinhVienModel);
        }

        // GET: SinhVienModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVienModel = await _context.Students.FindAsync(id);
            if (sinhVienModel == null)
            {
                return NotFound();
            }
            return View(sinhVienModel);
        }

        // POST: SinhVienModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] SinhVienModel sinhVienModel)
        {
            if (id != sinhVienModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sinhVienModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SinhVienModelExists(sinhVienModel.Id))
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
            return View(sinhVienModel);
        }

        // GET: SinhVienModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVienModel = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sinhVienModel == null)
            {
                return NotFound();
            }

            return View(sinhVienModel);
        }

        // POST: SinhVienModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sinhVienModel = await _context.Students.FindAsync(id);
            if (sinhVienModel != null)
            {
                _context.Students.Remove(sinhVienModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SinhVienModelExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
