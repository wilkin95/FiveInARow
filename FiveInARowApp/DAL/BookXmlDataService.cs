using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using FiveInARowApp.Models;
using System.Xml.Serialization;

namespace FiveInARowApp.DAL
{
    public class BookXmlDataService : IBookDataService, IDisposable
    {
        public List<Book> Read()
        {
            //a Book model is defined to pass a type to the XmlSerializer object
            Books booksObject;

            //initialize a FileStream object for reading
            string xmlFilePath = HttpContext.Current.Application["dataFilePath"].ToString();
            StreamReader sReader = new StreamReader(xmlFilePath);

            //initialize an XML serializer object
            XmlSerializer deserializer = new XmlSerializer(typeof(Books));

            using (sReader)
            {
                //deserialize the XML data set into a generic object
                object xmlObject = deserializer.Deserialize(sReader);

                //cast the generic object to the list class
                booksObject = (Books)xmlObject;
            }

            return booksObject.books;
        }

        public void Write(List<Book> books)
        {
            //initialize a FileStream object for reading
            string xmlFilePath = HttpContext.Current.Application["dataFilePath"].ToString();
            StreamWriter sWriter = new StreamWriter(xmlFilePath, false);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>), new XmlRootAttribute("Books"));

            using (sWriter)
            {
                serializer.Serialize(sWriter, books);
            }
        }
        public void Dispose()
        {
            // set resources to be cleaned up
        }
    }
} 