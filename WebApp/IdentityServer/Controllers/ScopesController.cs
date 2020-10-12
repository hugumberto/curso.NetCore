using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IdentityServer.Models;
using IdentityServer.Service;

namespace IdentityServer.Controllers
{
    public class ScopesController : Controller
    {
        private readonly IdentityDBContext _context;

        public ScopesController(IdentityDBContext context)
        {
            _context = context;
        }

        // GET: Scopes
        public async Task<IActionResult> Index()
        {
            var indentityDBContext = _context.Scopes.Include(s => s.Application).Include(s => s.Client);
            return View(await indentityDBContext.ToListAsync());
        }

        // GET: Scopes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scope = await _context.Scopes
                .Include(s => s.Application)
                .Include(s => s.Client)
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (scope == null)
            {
                return NotFound();
            }

            return View(scope);
        }

        // GET: Scopes/Create
        public IActionResult Create()
        {
            ViewData["ApplicationId"] = new SelectList(_context.Applications, "ApplicationId", "Name");
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Username");
            return View();
        }

        // POST: Scopes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientId,ApplicationId")] Scope scope)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scope);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationId"] = new SelectList(_context.Applications, "ApplicationId", "ApplicationId", scope.ApplicationId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId", scope.ClientId);
            return View(scope);
        }

        // GET: Scopes/Edit/5
        public async Task<IActionResult> Edit(Guid clientid ,Guid applicationid)
        {
            if (clientid == null)
            {
                return NotFound();
            }

            var scope = await _context.Scopes.Where(s => s.ClientId.Equals(clientid) && s.ApplicationId.Equals(applicationid)).FirstOrDefaultAsync();
               
            if (scope == null)
            {
                return NotFound();
            }
            ViewData["ApplicationId"] = new SelectList(_context.Applications, "ApplicationId", "ApplicationId", scope.ApplicationId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId", scope.ClientId);
            return View(scope);
        }

        // POST: Scopes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ClientId,ApplicationId")] Scope scope)
        {
            if (id != scope.ClientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scope);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScopeExists(scope.ClientId))
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
            ViewData["ApplicationId"] = new SelectList(_context.Applications, "ApplicationId", "ApplicationId", scope.ApplicationId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId", scope.ClientId);
            return View(scope);
        }

        // GET: Scopes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scope = await _context.Scopes
                .Include(s => s.Application)
                .Include(s => s.Client)
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (scope == null)
            {
                return NotFound();
            }

            return View(scope);
        }

        // POST: Scopes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var scope = await _context.Scopes.FindAsync(id);
            _context.Scopes.Remove(scope);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScopeExists(Guid id)
        {
            return _context.Scopes.Any(e => e.ClientId == id);
        }
    }
}
