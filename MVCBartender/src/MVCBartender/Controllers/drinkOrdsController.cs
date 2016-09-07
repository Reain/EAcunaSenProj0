using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCBartender.Data;
using MVCBartender.Models;
using System.Text.Encodings.Web;

namespace MVCBartender.Controllers
{
    public class drinkOrdsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public drinkOrdsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: drinkOrds
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.drinkOrd.Include(d => d.drinkInvs);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: drinkOrds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drinkOrd = await _context.drinkOrd.SingleOrDefaultAsync(m => m.drinkOrdID == id);
            if (drinkOrd == null)
            {
                return NotFound();
            }

            return View(drinkOrd);
        }

        // GET: drinkOrds/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.drinkInv, "ID", "ID");
            
            return View();



        }

        // POST: drinkOrds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("drinkOrdID,Id,drinkQuant,orderComplete,totalPrice")] drinkOrd drinkOrd)
        {



            drinkOrd.orderComplete = false;
            if (ModelState.IsValid)
            {
                _context.Add(drinkOrd);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Id"] = new SelectList(_context.drinkInv, "ID", "ID", drinkOrd.Id);
            return View(drinkOrd);
        }

        // GET: drinkOrds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drinkOrd = await _context.drinkOrd.SingleOrDefaultAsync(m => m.drinkOrdID == id);
            if (drinkOrd == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.drinkInv, "ID", "ID", drinkOrd.Id);
            return View(drinkOrd);
        }

        // POST: drinkOrds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("drinkOrdID,Id,drinkQuant,orderComplete,totalPrice")] drinkOrd drinkOrd)
        {
            if (id != drinkOrd.drinkOrdID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drinkOrd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!drinkOrdExists(drinkOrd.drinkOrdID))
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
            ViewData["Id"] = new SelectList(_context.drinkInv, "ID", "ID", drinkOrd.Id);
            return View(drinkOrd);
        }

        // GET: drinkOrds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drinkOrd = await _context.drinkOrd.SingleOrDefaultAsync(m => m.drinkOrdID == id);
            if (drinkOrd == null)
            {
                return NotFound();
            }

            return View(drinkOrd);
        }

        // POST: drinkOrds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drinkOrd = await _context.drinkOrd.SingleOrDefaultAsync(m => m.drinkOrdID == id);
            _context.drinkOrd.Remove(drinkOrd);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool drinkOrdExists(int id)
        {
            return _context.drinkOrd.Any(e => e.drinkOrdID == id);
        }
    }
}
