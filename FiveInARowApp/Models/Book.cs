using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 

namespace FiveInARowApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Illustrator { get; set; }
        public int Copyright { get; set; }
        public string Category { get; set; }
        public string Summary { get; set; }
        public string Topics { get; set; }



    }
}