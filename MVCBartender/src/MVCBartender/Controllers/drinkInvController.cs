using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCBartender.Data;
using MVCBartender.Models;

namespace MVCBartender.Controllers
{
    public class drinkInvController : Controller
    {
        private readonly ApplicationDbContext _context;

        public drinkInvController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: drinkInv
        public async Task<IActionResult> Index()
        {
            return View(await _context.drinkInv.ToListAsync());
        }

        // GET: drinkInv/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drinkInv = await _context.drinkInv.SingleOrDefaultAsync(m => m.ID == id);
            if (drinkInv == null)
            {
                return NotFound();
            }

            return View(drinkInv);
        }

        // GET: drinkInv/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: drinkInv/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DrinkDesc,DrinkName,DrinkPrice")] drinkInv drinkInv)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drinkInv);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(drinkInv);
        }

        // GET: drinkInv/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drinkInv = await _context.drinkInv.SingleOrDefaultAsync(m => m.ID == id);
            if (drinkInv == null)
            {
                return NotFound();
            }
            return View(drinkInv);
        }

        // POST: drinkInv/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DrinkDesc,DrinkName,DrinkPrice")] drinkInv drinkInv)
        {
            if (id != drinkInv.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drinkInv);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!drinkInvExists(drinkInv.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(drinkInv);
        }

        // GET: drinkInv/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drinkInv = await _context.drinkInv.SingleOrDefaultAsync(m => m.ID == id);
            if (drinkInv == null)
            {
                return NotFound();
            }

            return View(drinkInv);
        }

        // POST: drinkInv/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drinkInv = await _context.drinkInv.SingleOrDefaultAsync(m => m.ID == id);
            _context.drinkInv.Remove(drinkInv);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool drinkInvExists(int id)
        {
            return _context.drinkInv.Any(e => e.ID == id);
        }
    }
}
