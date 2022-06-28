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

        public async Task<ActionResult> Index()
        {
            IQueryable<TodoList> items = from i in _context.TodoLists orderby i.Id select i;
            List<TodoList> todoList = await items.ToListAsync();
            return View(todoList);
        }
    }
}

