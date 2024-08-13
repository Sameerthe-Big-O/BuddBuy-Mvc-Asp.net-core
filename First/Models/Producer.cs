using System.ComponentModel.DataAnnotations;

namespace First.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }

        public string ProfileUrl { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        public string Bio { get; set; }

        //relationships this is we define the one to many relationships

        public List<Movie> Movies { get; set; }
    }
}
