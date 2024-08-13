using System.ComponentModel.DataAnnotations;

namespace First.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "ProfileUrl")]
        [Required(ErrorMessage ="Imgae is requied")]
        public string ProfileUrl { get; set; }

        [Display(Name = "FullName")]
        [Required(ErrorMessage ="Name is requied")]
        [StringLength(50,MinimumLength =3, ErrorMessage ="Name length must be between 3 and 5 character")]
        public string FullName { get; set; }

        [Required(ErrorMessage ="Bio is required")]
        [Display(Name = "Biography")]
        public string Bio { get; set; }

        //relationships

        public List<Movie_Actors>? Movie_Actors {  get; set; }
    }
}
