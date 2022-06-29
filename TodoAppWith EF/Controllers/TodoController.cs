using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAppWith_EF.Infrastructure;
using TodoAppWith_EF.Models;


namespace TodoAppWith_EF.Controllers
{
    public class TodoController : Controller
    {
        private readonly TodoContext _context;
        public TodoController(TodoContext context)
        {
            _context = context;    
        }

        // GET/
        public async Task<ActionResult> Index()
        {
            IQueryable<TodoList> items = from i in _context.TodoLists orderby i.Id select i;
            List<TodoList> todoList = await items.ToListAsync();
            return View(todoList);
        }

        //GET Todo/ Create
        public IActionResult Create() => View();

        // POST / Todo / create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TodoList item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                TempData["Success"] = "The item has been added!";
                return RedirectToAction("Index");
            }
            return View(item);
        }

        //GET /Todo/ edit/5
        public async Task<ActionResult> Edit(int id)
        {
            TodoList item = await _context.TodoLists.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }


        // POST / Todo / Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TodoList item)
        {
            if (ModelState.IsValid)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                TempData["Success"] = "The item has been updated!";
                return RedirectToAction("Index");
            }
            return View(item);
        }

        //GET /Todo/ delete/5
        public async Task<ActionResult> Delete(int id)
        {
            TodoList item = await _context.TodoLists.FindAsync(id);
            if (item == null)
            {
                TempData["Error"] = "The item does not exist!";
            }
            else
            {
                _context.TodoLists.Remove(item);
                await _context.SaveChangesAsync();

                TempData["Success"] = "The item has been deleted!";
            }
            return RedirectToAction("Index"); 
        }

    }
}

