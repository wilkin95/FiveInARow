using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiveInARowApp.Models;

namespace FiveInARowApp.DAL
{
    //data service interface to read and write an entire file based on the Book class
    public interface IBookDataService
    {
        List<Book> Read();
        void Write(List<Book> Books);
    }
}
