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
    public class DangKyLopModelsController : Controller
    {
        private readonly AppDbContext _context;

        public DangKyLopModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: DangKyLopModels
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Enrollments.Include(d => d.Lop).Include(d => d.SinhVien);
            return View(await appDbContext.ToListAsync());
        }

        // GET: DangKyLopModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dangKyLopModel = await _context.Enrollments
                .Include(d => d.Lop)
                .Include(d => d.SinhVien)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dangKyLopModel == null)
            {
                return NotFound();
            }

            return View(dangKyLopModel);
        }

        // GET: DangKyLopModels/Create
        public IActionResult Create()
        {
            ViewData["LopId"] = new SelectList(_context.Classes, "Id", "Id");
            ViewData["SinhVienId"] = new SelectList(_context.Students, "Id", "Id");
            return View();
        }

        // POST: DangKyLopModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SinhVienId,LopId")] DangKyLopModel dangKyLopModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dangKyLopModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LopId"] = new SelectList(_context.Classes, "Id", "Id", dangKyLopModel.LopId);
            ViewData["SinhVienId"] = new SelectList(_context.Students, "Id", "Id", dangKyLopModel.SinhVienId);
            return View(dangKyLopModel);
        }

        // GET: DangKyLopModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dangKyLopModel = await _context.Enrollments.FindAsync(id);
            if (dangKyLopModel == null)
            {
                return NotFound();
            }
            ViewData["LopId"] = new SelectList(_context.Classes, "Id", "Id", dangKyLopModel.LopId);
            ViewData["SinhVienId"] = new SelectList(_context.Students, "Id", "Id", dangKyLopModel.SinhVienId);
            return View(dangKyLopModel);
        }

        // POST: DangKyLopModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SinhVienId,LopId")] DangKyLopModel dangKyLopModel)
        {
            if (id != dangKyLopModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dangKyLopModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DangKyLopModelExists(dangKyLopModel.Id))
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
            ViewData["LopId"] = new SelectList(_context.Classes, "Id", "Id", dangKyLopModel.LopId);
            ViewData["SinhVienId"] = new SelectList(_context.Students, "Id", "Id", dangKyLopModel.SinhVienId);
            return View(dangKyLopModel);
        }

        // GET: DangKyLopModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dangKyLopModel = await _context.Enrollments
                .Include(d => d.Lop)
                .Include(d => d.SinhVien)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dangKyLopModel == null)
            {
                return NotFound();
            }

            return View(dangKyLopModel);
        }

        // POST: DangKyLopModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dangKyLopModel = await _context.Enrollments.FindAsync(id);
            if (dangKyLopModel != null)
            {
                _context.Enrollments.Remove(dangKyLopModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DangKyLopModelExists(int id)
        {
            return _context.Enrollments.Any(e => e.Id == id);
        }
    }
}
