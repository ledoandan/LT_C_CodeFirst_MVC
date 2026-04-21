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
    public class LopModelsController : Controller
    {
        private readonly AppDbContext _context;

        public LopModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: LopModels
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Classes.Include(l => l.GiaoVien).Include(l => l.KhoaHoc);
            return View(await appDbContext.ToListAsync());
        }

        // GET: LopModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lopModel = await _context.Classes
                .Include(l => l.GiaoVien)
                .Include(l => l.KhoaHoc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lopModel == null)
            {
                return NotFound();
            }

            return View(lopModel);
        }

        // GET: LopModels/Create
        public IActionResult Create()
        {
            ViewData["GiaoVienId"] = new SelectList(_context.Teachers, "Id", "Id");
            ViewData["KhoaHocId"] = new SelectList(_context.Courses, "Id", "Id");
            return View();
        }

        // POST: LopModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,KhoaHocId,GiaoVienId")] LopModel lopModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lopModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GiaoVienId"] = new SelectList(_context.Teachers, "Id", "Id", lopModel.GiaoVienId);
            ViewData["KhoaHocId"] = new SelectList(_context.Courses, "Id", "Id", lopModel.KhoaHocId);
            return View(lopModel);
        }

        // GET: LopModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lopModel = await _context.Classes.FindAsync(id);
            if (lopModel == null)
            {
                return NotFound();
            }
            ViewData["GiaoVienId"] = new SelectList(_context.Teachers, "Id", "Id", lopModel.GiaoVienId);
            ViewData["KhoaHocId"] = new SelectList(_context.Courses, "Id", "Id", lopModel.KhoaHocId);
            return View(lopModel);
        }

        // POST: LopModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,KhoaHocId,GiaoVienId")] LopModel lopModel)
        {
            if (id != lopModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lopModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LopModelExists(lopModel.Id))
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
            ViewData["GiaoVienId"] = new SelectList(_context.Teachers, "Id", "Id", lopModel.GiaoVienId);
            ViewData["KhoaHocId"] = new SelectList(_context.Courses, "Id", "Id", lopModel.KhoaHocId);
            return View(lopModel);
        }

        // GET: LopModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lopModel = await _context.Classes
                .Include(l => l.GiaoVien)
                .Include(l => l.KhoaHoc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lopModel == null)
            {
                return NotFound();
            }

            return View(lopModel);
        }

        // POST: LopModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lopModel = await _context.Classes.FindAsync(id);
            if (lopModel != null)
            {
                _context.Classes.Remove(lopModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LopModelExists(int id)
        {
            return _context.Classes.Any(e => e.Id == id);
        }
    }
}
