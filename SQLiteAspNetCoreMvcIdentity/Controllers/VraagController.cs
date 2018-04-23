using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SQLiteAspNetCoreMvcIdentity.Data;
using SQLiteAspNetCoreMvcIdentity.Models;

namespace SQLiteAspNetCoreMvcIdentity.Controllers
{
    public class VraagController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VraagController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vraag
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vraag.ToListAsync());
        }

        // GET: Vraag/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vraag = await _context.Vraag
                .SingleOrDefaultAsync(m => m.Id == id);
            if (vraag == null)
            {
                return NotFound();
            }

            return View(vraag);
        }

        // GET: Vraag/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vraag/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tekst,Afbeelding,LaatsteWijziging,MaxPunten,Opmerkingen")] Vraag vraag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vraag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vraag);
        }

        // GET: Vraag/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vraag = await _context.Vraag.SingleOrDefaultAsync(m => m.Id == id);
            if (vraag == null)
            {
                return NotFound();
            }
            return View(vraag);
        }

        // POST: Vraag/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tekst,Afbeelding,LaatsteWijziging,MaxPunten,Opmerkingen")] Vraag vraag)
        {
            if (id != vraag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vraag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VraagExists(vraag.Id))
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
            return View(vraag);
        }

        // GET: Vraag/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vraag = await _context.Vraag
                .SingleOrDefaultAsync(m => m.Id == id);
            if (vraag == null)
            {
                return NotFound();
            }

            return View(vraag);
        }

        // POST: Vraag/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vraag = await _context.Vraag.SingleOrDefaultAsync(m => m.Id == id);
            _context.Vraag.Remove(vraag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VraagExists(int id)
        {
            return _context.Vraag.Any(e => e.Id == id);
        }
    }
}
