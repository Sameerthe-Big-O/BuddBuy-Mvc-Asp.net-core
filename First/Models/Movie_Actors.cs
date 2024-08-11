using System.ComponentModel.DataAnnotations;

namespace First.Models
{
    public class Movie_Actors
    {

        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        public int ActorId { get; set; }

        public Actor Actor { get; set; }

    }
}
