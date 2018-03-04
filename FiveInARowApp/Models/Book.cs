using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FiveInARowApp.Models
{
    public class Book
    {
        [Required(ErrorMessage = "A unique Id must be entered.")]
        public int Id { get; set; }
        public string ISBN { get; set; }
        [Required]
        [Display(Name = "Book Title")]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        public string Illustrator { get; set; }
        public int Copyright { get; set; }
        public string Category { get; set; }
        public string Summary { get; set; }
        public string Topics { get; set; }
     



    }
}