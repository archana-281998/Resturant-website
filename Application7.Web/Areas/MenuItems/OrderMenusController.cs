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
    public class OrderMenusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderMenusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MenuItems/OrderMenus
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OrderMenus.Include(o => o.Guest).Include(o => o.MenuItem);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MenuItems/OrderMenus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderMenu = await _context.OrderMenus
                .Include(o => o.Guest)
                .Include(o => o.MenuItem)
                .FirstOrDefaultAsync(m => m.OrderMenuId == id);
            if (orderMenu == null)
            {
                return NotFound();
            }

            return View(orderMenu);
        }

        // GET: MenuItems/OrderMenus/Create
        public IActionResult Create()
        {
            ViewData["GuestId"] = new SelectList(_context.Guests, "GuestId", "GuestName");
            ViewData["MenuItemId"] = new SelectList(_context.MenuItems, "MenuItemId", "MenuItemName");
            return View();
        }

        // POST: MenuItems/OrderMenus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderMenuId,OrderMenuName,GuestId,MenuItemId")] OrderMenu orderMenu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderMenu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GuestId"] = new SelectList(_context.Guests, "GuestId", "GuestName", orderMenu.GuestId);
            ViewData["MenuItemId"] = new SelectList(_context.MenuItems, "MenuItemId", "MenuItemName", orderMenu.MenuItemId);
            return View(orderMenu);
        }

        // GET: MenuItems/OrderMenus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderMenu = await _context.OrderMenus.FindAsync(id);
            if (orderMenu == null)
            {
                return NotFound();
            }
            ViewData["GuestId"] = new SelectList(_context.Guests, "GuestId", "GuestName", orderMenu.GuestId);
            ViewData["MenuItemId"] = new SelectList(_context.MenuItems, "MenuItemId", "MenuItemName", orderMenu.MenuItemId);
            return View(orderMenu);
        }

        // POST: MenuItems/OrderMenus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderMenuId,OrderMenuName,GuestId,MenuItemId")] OrderMenu orderMenu)
        {
            if (id != orderMenu.OrderMenuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderMenu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderMenuExists(orderMenu.OrderMenuId))
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
            ViewData["GuestId"] = new SelectList(_context.Guests, "GuestId", "GuestName", orderMenu.GuestId);
            ViewData["MenuItemId"] = new SelectList(_context.MenuItems, "MenuItemId", "MenuItemName", orderMenu.MenuItemId);
            return View(orderMenu);
        }

        // GET: MenuItems/OrderMenus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderMenu = await _context.OrderMenus
                .Include(o => o.Guest)
                .Include(o => o.MenuItem)
                .FirstOrDefaultAsync(m => m.OrderMenuId == id);
            if (orderMenu == null)
            {
                return NotFound();
            }

            return View(orderMenu);
        }

        // POST: MenuItems/OrderMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderMenu = await _context.OrderMenus.FindAsync(id);
            _context.OrderMenus.Remove(orderMenu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderMenuExists(int id)
        {
            return _context.OrderMenus.Any(e => e.OrderMenuId == id);
        }
    }
}
