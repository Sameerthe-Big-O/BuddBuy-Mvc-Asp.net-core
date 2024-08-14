using First.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace First.Data.Services
{
    public class ActorService : IActorService
    {
        private readonly AppDbContext _context;

        public ActorService(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async void AddAsync(Actor actor)
        {
            try
            {
                if (actor == null)
                {
                    throw new ArgumentNullException(nameof(actor), "Actor cannot be null.");
                }

                await _context.Actors.AddAsync(actor);
                await _context.SaveChangesAsync();
            }
            
            catch (Exception ex)
            {
                // Log and handle other exceptions
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow or handle the exception
            }
        }

        public void DeleteById(int id)
        {
            try
            {
                var actor = _context.Actors.Find(id);
                if (actor == null)
                {
                    throw new InvalidOperationException("Actor not found.");
                }

                _context.Actors.Remove(actor);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Log and handle other exceptions
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow or handle the exception
            }
        }

        public async Task<IEnumerable<Actor>> GetALL()
        {
            try
            {
                return await _context.Actors.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log and handle exceptions
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow or handle the exception
            }
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            try
            {
                var actor = await _context.Actors.FindAsync(id);
                if (actor == null)
                {
                    throw new KeyNotFoundException("Actor not found.");
                }

                return actor;
            }
            catch (Exception ex)
            {
                // Log and handle exceptions
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow or handle the exception
            }
        }

        public async Task<Actor> UpdateByIdAsync(int id, Actor actor)
        {
            Console.WriteLine(actor);
            try
            {
                var result = await _context.Actors.FindAsync(id);

                Console.WriteLine(result);
                if (result == null)
                {

                    throw new Exception($"Todo item with id {id} not found.");
                }

                if (actor.FullName != null) {
                    result.FullName = actor.FullName;
                }
                if (actor.Bio != null)
                {
                    result.Bio = actor.Bio;
                }
                if (actor.ProfileUrl != null)
                {
                    result.ProfileUrl = actor.ProfileUrl;
                }

                await _context.SaveChangesAsync();
                return result;
            }

            catch (Exception ex)
            {
                // Log and handle other exceptions
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow or handle the exception
            }
        }
    }
}
