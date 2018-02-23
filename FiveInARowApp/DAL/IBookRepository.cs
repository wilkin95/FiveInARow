using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiveInARowApp.Models;

namespace FiveInARowApp.DAL
{
    public interface IBookRepository
    {
        IEnumerable<Book> SelectAll();
        Book SelectOne(int id);
        void Insert(Book book);
        void Update(Book book);
        void Delete(int id);
    }
}
