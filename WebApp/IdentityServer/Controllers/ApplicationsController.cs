﻿using System;
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
    public class ApplicationsController : Controller
    {
        private readonly IdentityDBContext _context;

        public ApplicationsController(IdentityDBContext context)
        {
            _context = context;
        }

        // GET: Applications
        public async Task<IActionResult> Index()
        {
            return View(await _context.Applications.ToListAsync());
        }

        // GET: Applications/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications
                .FirstOrDefaultAsync(m => m.ApplicationId == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        // GET: Applications/Create
        public IActionResult Create()
        {
            //return View();
            return PartialView();
        }

        // POST: Applications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicationId,Name")] Application application)
        {
            if (ModelState.IsValid)
            {
                application.ApplicationId = Guid.NewGuid();
                _context.Add(application);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(application);
        }

        // GET: Applications/Edit/5
        //[HttpGet("{id}")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }
            return View(application);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ApplicationId,Name")] Application application)
        {
            if (id != application.ApplicationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(application);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationExists(application.ApplicationId))
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
            return View(application);
        }

        // GET: Applications/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications
                .FirstOrDefaultAsync(m => m.ApplicationId == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var application = await _context.Applications.FindAsync(id);
            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationExists(Guid id)
        {
            return _context.Applications.Any(e => e.ApplicationId == id);
        }
    }
}
