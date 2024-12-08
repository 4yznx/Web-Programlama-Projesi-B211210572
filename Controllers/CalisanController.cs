﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BarberShop.Data;
using BarberShop.Models;
using Microsoft.AspNetCore.Authorization;

namespace BarberShop.Controllers
{
    public class CalisanController : Controller
    {
        private readonly BarberDbContext _context;

        public CalisanController(BarberDbContext context)
        {
            _context = context;
        }

        // GET: Calisan
        public async Task<IActionResult> Index()
        {
            return View(await _context.Calisanlar.ToListAsync());
        }

        // GET: Calisan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calisan = await _context.Calisanlar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calisan == null)
            {
                return NotFound();
            }

            return View(calisan);
        }

        // GET: Calisan/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Adi,Soyadi,Uzmanliklar,Uygunluk")] Calisan calisan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calisan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calisan);
        }

        // GET: Calisan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calisan = await _context.Calisanlar.FindAsync(id);
            if (calisan == null)
            {
                return NotFound();
            }
            return View(calisan);
        }

        // POST: Calisan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Adi,Soyadi,Uzmanliklar,Uygunluk")] Calisan calisan)
        {
            if (id != calisan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calisan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalisanExists(calisan.Id))
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
            return View(calisan);
        }

        // GET: Calisan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calisan = await _context.Calisanlar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calisan == null)
            {
                return NotFound();
            }

            return View(calisan);
        }

        // POST: Calisan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calisan = await _context.Calisanlar.FindAsync(id);
            if (calisan != null)
            {
                _context.Calisanlar.Remove(calisan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalisanExists(int id)
        {
            return _context.Calisanlar.Any(e => e.Id == id);
        }
    }
}
