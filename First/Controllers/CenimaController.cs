using First.Data;
using Microsoft.AspNetCore.Mvc;

namespace First.Controllers
{
    public class CenimaController : Controller
    {
        private readonly AppDbContext _context;

        public CenimaController(AppDbContext context)
        {
            _context = context;
        }
        //default reuslt
        public IActionResult Index()
        {
            //*like find method mongodb  or select all psql
            /*
            just like in node js we have controller here we have the same as well in controller we usually have the method or function to handle
            differenet actions and we have the same thing as well.
            here we have actions instead of that
            and instead of simply just returning the api data we usually do we in node or express api here the data we receive we got when we hit th3 certain action
            we then data object put into the view and then return the view basically a SSR
            */

            var data = _context.Cenimas.ToList();
            Console.WriteLine(data);
            return View(data);
        }
    }
}
