using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using First.Data;

namespace First.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
            
        public string PictureUrl { get; set; }

        public  DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        
        public MovieCategory MovieCategory { get; set; }
       

        //relationships

        public List<Movie_Actors> Movie_Actors { get; set; }

        public int CenimaId { get; set; }
        [ForeignKey("CenimaId")]

        //*here we're actually storing the id because we usually store the on the many side 
        public Cenima Cinema { get; set; }

        //what this is saying is that it can have single Producer id for each tuple
        public int ProducerId  { get; set; }

        public Producer Producer { get; set; }

    } 

}
