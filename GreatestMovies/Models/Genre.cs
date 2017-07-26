using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GreatestMovies.Models
{
    public class Genre
    {
        [Key]
        public int GenreID { get; set; }
        public string GenreType { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}