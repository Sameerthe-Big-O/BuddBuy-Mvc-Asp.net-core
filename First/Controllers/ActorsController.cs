using First.Data;
using First.Data.Services;
using First.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace First.Controllers
{

    public class ActorsController : Controller
    {
        //*instead of db we just interact with this service
        private readonly IActorService _service;
        
        public ActorsController(IActorService service)
        {
            _service = service;
        }
        //default reuslt
        //*remember that task creates the aync task which  means that the task can happen in the background and doesn't block the main thread
        public async Task<IActionResult> Index()
        {
            //*like find method mongodb  or select all psql
            /*
            just like in node js we have controller here we have the same as well in controller we usually have the method or function to handle
            differenet actions and we have the same thing as well.
            here we have actions instead of that
            and instead of simply just returning the api data we usually do we in node or express api here the data we receive we got when we hit th3 certain action
            we then data object put into the view and then return the view basically a SSR
            */
            var data =await _service.GetALL();
            return View(data);
        }

        //*get Actors/create
        public  IActionResult Create()
        {
            //*like find method mongodb  or select all psql
            /*
            just like in node js we have controller here we have the same as well in controller we usually have the method or function to handle
            differenet actions and we have the same thing as well.
            here we have actions instead of that
            and instead of simply just returning the api data we usually do we in node or express api here the data we receive we got when we hit th3 certain action
            we then data object put into the view and then return the view basically a SSR
            */
            //  var data = await _service.Add();
            Console.WriteLine("here we are");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FullName,ProfileUrl,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            try
            {
                 _service.AddAsync(actor);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
                return View(actor);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var result= await _service.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound("No Actor Exist here");
            }
            return View(result);
        }

        //*first fetch that shit

        //*iuf we have two method and not mention which one is which then it might collapse
        
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _service.GetByIdAsync(id);
            Console.WriteLine(result);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // POST: Actors/Edit/5
        [HttpPost]
        //*method overloading here ploymoi-hism
        public async Task<IActionResult> Update(int id, [Bind("Id,FullName,ProfileUrl,Bio")] Actor actor)
        {

            if (id != actor.Id)
            {
                return BadRequest("Id is  Required"); // Return a 400 Bad Request response if the ID mismatch occurs
            }

            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            try
            {
                _service.UpdateByIdAsync(id, actor);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
                return View(actor);
            }
        }

        [HttpDelete]
        public async void Delete(int id)
        {
            try
            {
                 _service.DeleteById(id);
            }
            catch (Exception ex)
            {


            }
        }
    }
}
