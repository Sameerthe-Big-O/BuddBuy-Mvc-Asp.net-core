using First.Models;

namespace First.Data.Services
{

    //*just define the methods, basically a method data
    public interface IActorService
    {
        IEnumerable<Actor> GetALL();

        Actor GetById(int id);

        Actor UpdateById(int id);

        void DeleteById(int id);

        void Add(Actor actor);
    }
}
