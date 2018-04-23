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
    public class VragenlijstController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VragenlijstController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vragenlijst
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vragenlijst.ToListAsync());
        }

        // GET: Vragenlijst/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vragenlijst = await _context.Vragenlijst
                .SingleOrDefaultAsync(m => m.Id == id);
            if (vragenlijst == null)
            {
                return NotFound();
            }

            return View(vragenlijst);
        }

        // GET: Vragenlijst/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vragenlijst/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titel,Omschrijving,Opmerkingen,LaatsteWijziging,Gequoteerd")] Vragenlijst vragenlijst)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vragenlijst);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vragenlijst);
        }

        // GET: Vragenlijst/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vragenlijst = await _context.Vragenlijst.SingleOrDefaultAsync(m => m.Id == id);
            if (vragenlijst == null)
            {
                return NotFound();
            }
            return View(vragenlijst);
        }

        // POST: Vragenlijst/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titel,Omschrijving,Opmerkingen,LaatsteWijziging,Gequoteerd")] Vragenlijst vragenlijst)
        {
            if (id != vragenlijst.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vragenlijst);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VragenlijstExists(vragenlijst.Id))
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
            return View(vragenlijst);
        }

        // GET: Vragenlijst/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vragenlijst = await _context.Vragenlijst
                .SingleOrDefaultAsync(m => m.Id == id);
            if (vragenlijst == null)
            {
                return NotFound();
            }

            return View(vragenlijst);
        }

        // POST: Vragenlijst/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vragenlijst = await _context.Vragenlijst.SingleOrDefaultAsync(m => m.Id == id);
            _context.Vragenlijst.Remove(vragenlijst);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VragenlijstExists(int id)
        {
            return _context.Vragenlijst.Any(e => e.Id == id);
        }
    }
}
