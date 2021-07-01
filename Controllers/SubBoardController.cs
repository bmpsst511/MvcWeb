using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcWeb.Models;

namespace MvcWeb.Controllers
{
    public class SubBoardController : Controller
    {
        private readonly MvcWebContext _context;

        public SubBoardController(MvcWebContext context)
        {
            _context = context;
        }

        // GET: SubBoard
        public async Task<IActionResult> Index()
        {
            ViewBag.subBoards = _context.SubBoard.OrderBy(x => x.Sub_Index).ToList(); //子板照著設定的Index做排列塞入List
            //return View(await _context.SubBoard.ToListAsync());
            return View(ViewBag.subBoards);
        }

        // GET: SubBoard/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subBoard = await _context.SubBoard
                .FirstOrDefaultAsync(m => m.Sub_Id == id);
            if (subBoard == null)
            {
                return NotFound();
            }

            return View(subBoard);
        }

        // GET: SubBoard/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SubBoard/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sub_Id,Sub_Name,Sub_Link,Sub_Index")] SubBoard subBoard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subBoard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subBoard);
        }

        // GET: SubBoard/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subBoard = await _context.SubBoard.FindAsync(id);
            if (subBoard == null)
            {
                return NotFound();
            }
            return View(subBoard);
        }

        // POST: SubBoard/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Sub_Id,Sub_Name,Sub_Link,Sub_Index")] SubBoard subBoard)
        {
            if (id != subBoard.Sub_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subBoard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubBoardExists(subBoard.Sub_Id))
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
            return View(subBoard);
        }

        // GET: SubBoard/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subBoard = await _context.SubBoard
                .FirstOrDefaultAsync(m => m.Sub_Id == id);
            if (subBoard == null)
            {
                return NotFound();
            }

            return View(subBoard);
        }

        // POST: SubBoard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subBoard = await _context.SubBoard.FindAsync(id);
            _context.SubBoard.Remove(subBoard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubBoardExists(int id)
        {
            return _context.SubBoard.Any(e => e.Sub_Id == id);
        }
    }
}
