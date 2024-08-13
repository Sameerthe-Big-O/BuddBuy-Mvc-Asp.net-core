using First.Models;

namespace First.Data.Services
{

    //*just define the methods, basically a meta data
    public interface IActorService
    {
        //*task here telling that it shouldn't block the main  thread , 
        Task<IEnumerable<Actor>> GetALL();

        Task<Actor> GetByIdAsync(int id);

        Task<Actor> UpdateByIdAsync(int id, Actor actor);

        void DeleteById(int id);

        void AddAsync(Actor actor);
    }
}
