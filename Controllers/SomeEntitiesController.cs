using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OpenShiftTestApp.Data;
using OpenShiftTestApp.Models;

namespace OpenShiftTestApp.Controllers
{
    public class SomeEntitiesController : Controller
    {
        private readonly MvcOSTAContext _context;

        public SomeEntitiesController(MvcOSTAContext context)
        {
            _context = context;
        }

        // GET: SomeEntities
        public async Task<IActionResult> Index()
        {
            return View(await _context.SomeEntity.ToListAsync());
        }

        // GET: SomeEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var someEntity = await _context.SomeEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (someEntity == null)
            {
                return NotFound();
            }

            return View(someEntity);
        }

        // GET: SomeEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SomeEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] SomeEntity someEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(someEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(someEntity);
        }

        // GET: SomeEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var someEntity = await _context.SomeEntity.FindAsync(id);
            if (someEntity == null)
            {
                return NotFound();
            }
            return View(someEntity);
        }

        // POST: SomeEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] SomeEntity someEntity)
        {
            if (id != someEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(someEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SomeEntityExists(someEntity.Id))
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
            return View(someEntity);
        }

        // GET: SomeEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var someEntity = await _context.SomeEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (someEntity == null)
            {
                return NotFound();
            }

            return View(someEntity);
        }

        // POST: SomeEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var someEntity = await _context.SomeEntity.FindAsync(id);
            _context.SomeEntity.Remove(someEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SomeEntityExists(int id)
        {
            return _context.SomeEntity.Any(e => e.Id == id);
        }
    }
}
