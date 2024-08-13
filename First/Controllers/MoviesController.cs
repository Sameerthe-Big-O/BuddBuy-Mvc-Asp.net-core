using First.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace First.Controllers
{
    public class MoviesController : Controller
    {

        private readonly AppDbContext _context;

        //*dependency injection
        public MoviesController(AppDbContext context)
        {
            _context = context;
        }
        //correspond to / or index route
        public async Task<IActionResult> Index()
        {
            //*find method, what we're doing here is that not only we're retreving the movie but also, which cenima this movie will released this also

            //*this is  very similar to include in prisma
            var allMovies = await _context.Movies.Include(n => n.Cenima).ToListAsync();
            return View(allMovies);
        }
    }
}
