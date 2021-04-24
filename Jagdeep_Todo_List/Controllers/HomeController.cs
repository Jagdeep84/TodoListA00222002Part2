using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using To_Do_List_Jagdeep.Context_File;
using To_Do_List_Jagdeep.Models;

namespace To_Do_List_Jagdeep.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TodoListContext _context;
        public HomeController(ILogger<HomeController> logger, TodoListContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var TodoLists = _context.TodoLists;
            return View(await TodoLists.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }       
        //
        // GET: /Users/Details/5

        
        //
        // GET: /Users/Create

        public ActionResult Create()
        {
            return View();
        }
        //
        // POST: /Users/Create

      

        //
        // POST: /Users/Edit/5

       
        //
        // GET: /Users/Delete/5

        
        //
        // POST: /Users/Delete/5

       
    }
}
