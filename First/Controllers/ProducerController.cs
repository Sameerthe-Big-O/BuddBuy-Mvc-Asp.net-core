using First.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace First.Controllers
{
    public class ProducerController : Controller
    {

        private readonly AppDbContext _context;

        //*dependency injection
        public ProducerController(AppDbContext context)
        {
            _context = context;
        }
        //correspond to / or index route
        public async Task<IActionResult> Index()
        {
            //*find method
            var allProducers = await _context.Producers.ToListAsync();
            return View(allProducers);
        }
    }
}
