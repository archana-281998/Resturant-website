using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Application7.Web.Data;
using Application7.Web.Models;

namespace Application7.Web.Areas.MenuItems
{
    [Area("MenuItems")]
    public class OrderInformationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderInformationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MenuItems/OrderInformations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OrderInformation.Include(o => o.OrderMenu);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MenuItems/OrderInformations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderInformation = await _context.OrderInformation
                .Include(o => o.OrderMenu)
                .FirstOrDefaultAsync(m => m.OrderInformationId == id);
            if (orderInformation == null)
            {
                return NotFound();
            }

            return View(orderInformation);
        }

        // GET: MenuItems/OrderInformations/Create
        public IActionResult Create()
        {
            ViewData["OrderMenuId"] = new SelectList(_context.OrderMenus, "OrderMenuId", "OrderMenuId");
            return View();
        }

        // POST: MenuItems/OrderInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderInformationId,OrderMenuId")] OrderInformation orderInformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderMenuId"] = new SelectList(_context.OrderMenus, "OrderMenuId", "OrderMenuId", orderInformation.OrderMenuId);
            return View(orderInformation);
        }

        // GET: MenuItems/OrderInformations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderInformation = await _context.OrderInformation.FindAsync(id);
            if (orderInformation == null)
            {
                return NotFound();
            }
            ViewData["OrderMenuId"] = new SelectList(_context.OrderMenus, "OrderMenuId", "OrderMenuId", orderInformation.OrderMenuId);
            return View(orderInformation);
        }

        // POST: MenuItems/OrderInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderInformationId,OrderMenuId")] OrderInformation orderInformation)
        {
            if (id != orderInformation.OrderInformationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderInformationExists(orderInformation.OrderInformationId))
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
            ViewData["OrderMenuId"] = new SelectList(_context.OrderMenus, "OrderMenuId", "OrderMenuId", orderInformation.OrderMenuId);
            return View(orderInformation);
        }

        // GET: MenuItems/OrderInformations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderInformation = await _context.OrderInformation
                .Include(o => o.OrderMenu)
                .FirstOrDefaultAsync(m => m.OrderInformationId == id);
            if (orderInformation == null)
            {
                return NotFound();
            }

            return View(orderInformation);
        }

        // POST: MenuItems/OrderInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderInformation = await _context.OrderInformation.FindAsync(id);
            _context.OrderInformation.Remove(orderInformation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderInformationExists(int id)
        {
            return _context.OrderInformation.Any(e => e.OrderInformationId == id);
        }
    }
}
