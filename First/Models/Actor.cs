using System.ComponentModel.DataAnnotations;

namespace First.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        public string ProfileUrl { get; set; }
        public string FullName { get; set; }

        public string Bio { get; set; }

        //relationships

        public List<Movie_Actors> Movie_Actors {  get; set; }
    }
}
