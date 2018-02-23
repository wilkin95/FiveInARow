using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace FiveInARowApp.Models
{
    [XmlRoot("Books")]
    public class Books
    {
        [XmlElement("Book")]
        public List<Book> books;
        
    }
}