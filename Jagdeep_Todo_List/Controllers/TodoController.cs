using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using To_Do_List_Jagdeep.Context_File;
using To_Do_List_Jagdeep.Models;

namespace To_Do_List_Jagdeep.Controllers
{
    public class TodoListController : Controller
    {
        private readonly TodoListContext _context;
        public TodoListController(TodoListContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var TodoLists = _context.TodoLists;
            return View(await TodoLists.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = await _context.TodoLists.FirstOrDefaultAsync(m => m.TodoItemId == id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("DueDate,Title,Description")] TodoItem todo)
        {
            todo.DoneDate = DateTime.Now;
            todo.Done = false;
            _context.Add(todo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        // GET: TodoLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = await _context.TodoLists.FirstOrDefaultAsync(m => m.TodoItemId == id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }
        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> Edit([Bind("DueDate,TodoItemId,Title,Description")] TodoItem todo)
        {
            if (todo.TodoItemId > 0)
            {
                return NotFound();
            }
            var todoToUpdate = await _context.TodoLists.FirstOrDefaultAsync(c => c.TodoItemId == todo.TodoItemId);
            try
            {
                todoToUpdate.UserEmail = User.Identity.Name;
                todoToUpdate.Title = todo.Title;
                todoToUpdate.Description = todo.Description;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Todo = await _context.TodoLists.FirstOrDefaultAsync(m => m.TodoItemId == id);
            if (Todo == null)
            {
                return NotFound();
            }
            return View(Todo);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.TodoLists.FindAsync(id);
            _context.TodoLists.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> DoneTodo(int TodoId, bool r = false)
        {
            var todo = await _context.TodoLists.FindAsync(TodoId);
            todo.DoneDate = DateTime.Now;
            todo.Done = true;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
