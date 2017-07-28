using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GreatestMovies.Models
{
    public class Actor
    {
        [Key]
        public int ActorID { get; set; }
        [Display(Name = "Actor's Name")]
        public string ActorName { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DOB { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public int Votes { get; set; }

       
        public virtual ICollection<Movie> Movies { get; set; }

    }
}