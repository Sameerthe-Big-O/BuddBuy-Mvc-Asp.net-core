using System.ComponentModel.DataAnnotations;

namespace First.Models
{
    public class Cenima
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Cenima Logo")]
        public string Logo { get; set; }
        [Display(Name = "Cenima Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }   
        //relationships here we're just telling that i'l have the one to many relationship


        public List<Movie> Movies { get; set; }
    }
}
