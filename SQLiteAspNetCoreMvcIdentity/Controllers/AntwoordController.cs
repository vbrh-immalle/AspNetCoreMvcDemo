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
    public class AntwoordController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AntwoordController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Antwoord
        public async Task<IActionResult> Index()
        {
            return View(await _context.Antwoord.ToListAsync());
        }

        // GET: Antwoord/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antwoord = await _context.Antwoord
                .SingleOrDefaultAsync(m => m.Id == id);
            if (antwoord == null)
            {
                return NotFound();
            }

            return View(antwoord);
        }

        // GET: Antwoord/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Antwoord/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tekst,Afbeelding,LaatsteWijziging,Afgesloten")] Antwoord antwoord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(antwoord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(antwoord);
        }

        // GET: Antwoord/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antwoord = await _context.Antwoord.SingleOrDefaultAsync(m => m.Id == id);
            if (antwoord == null)
            {
                return NotFound();
            }
            return View(antwoord);
        }

        // POST: Antwoord/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tekst,Afbeelding,LaatsteWijziging,Afgesloten")] Antwoord antwoord)
        {
            if (id != antwoord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(antwoord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AntwoordExists(antwoord.Id))
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
            return View(antwoord);
        }

        // GET: Antwoord/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antwoord = await _context.Antwoord
                .SingleOrDefaultAsync(m => m.Id == id);
            if (antwoord == null)
            {
                return NotFound();
            }

            return View(antwoord);
        }

        // POST: Antwoord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var antwoord = await _context.Antwoord.SingleOrDefaultAsync(m => m.Id == id);
            _context.Antwoord.Remove(antwoord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AntwoordExists(int id)
        {
            return _context.Antwoord.Any(e => e.Id == id);
        }
    }
}
