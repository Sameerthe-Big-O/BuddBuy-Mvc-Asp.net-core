﻿using System.ComponentModel.DataAnnotations;

namespace First.Models
{
    public class Cenima
    {
        [Key]
        public int Id { get; set; }

        public string Logo { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
         
        //relationships here we're just telling that i'l have the one to many relationship

        public List<Movie> Movies { get; set; }
    }
}