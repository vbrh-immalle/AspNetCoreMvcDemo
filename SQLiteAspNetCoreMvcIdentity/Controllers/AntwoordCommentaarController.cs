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
    public class AntwoordCommentaarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AntwoordCommentaarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AntwoordCommentaar
        public async Task<IActionResult> Index()
        {
            return View(await _context.AntwoordCommentaar.ToListAsync());
        }

        // GET: AntwoordCommentaar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antwoordCommentaar = await _context.AntwoordCommentaar
                .SingleOrDefaultAsync(m => m.Id == id);
            if (antwoordCommentaar == null)
            {
                return NotFound();
            }

            return View(antwoordCommentaar);
        }

        // GET: AntwoordCommentaar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AntwoordCommentaar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Commentaar,LaatsteWijziging")] AntwoordCommentaar antwoordCommentaar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(antwoordCommentaar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(antwoordCommentaar);
        }

        // GET: AntwoordCommentaar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antwoordCommentaar = await _context.AntwoordCommentaar.SingleOrDefaultAsync(m => m.Id == id);
            if (antwoordCommentaar == null)
            {
                return NotFound();
            }
            return View(antwoordCommentaar);
        }

        // POST: AntwoordCommentaar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Commentaar,LaatsteWijziging")] AntwoordCommentaar antwoordCommentaar)
        {
            if (id != antwoordCommentaar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(antwoordCommentaar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AntwoordCommentaarExists(antwoordCommentaar.Id))
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
            return View(antwoordCommentaar);
        }

        // GET: AntwoordCommentaar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antwoordCommentaar = await _context.AntwoordCommentaar
                .SingleOrDefaultAsync(m => m.Id == id);
            if (antwoordCommentaar == null)
            {
                return NotFound();
            }

            return View(antwoordCommentaar);
        }

        // POST: AntwoordCommentaar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var antwoordCommentaar = await _context.AntwoordCommentaar.SingleOrDefaultAsync(m => m.Id == id);
            _context.AntwoordCommentaar.Remove(antwoordCommentaar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AntwoordCommentaarExists(int id)
        {
            return _context.AntwoordCommentaar.Any(e => e.Id == id);
        }
    }
}
