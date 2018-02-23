using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FiveInARowApp.Models;

namespace FiveInARowApp.DAL
{
    public class BookRepository : IBookRepository, IDisposable
    {
        private List<Book> _books;

        public BookRepository()
        {
            BookXmlDataService bookXmlDataService = new BookXmlDataService();

            using (bookXmlDataService)
            {
                _books = bookXmlDataService.Read() as List<Book>;
            }
        }

        public IEnumerable<Book> SelectAll()
        {
            return _books;
        }

        public Book SelectOne(int id)
        {
            //Book selectedBook =
            //from book in _books
            //where book.Id == id
            //select book).FirstOrDefault();

            Book selectedBook = _books.Where(b => b.Id == id).FirstOrDefault();

            return selectedBook;
        }

        public void Insert(Book book)
        {
            book.Id = NextIdValue();
            _books.Add(book);

            Save();
        }

        private int NextIdValue()
        {
            int currentMaxId = _books.OrderByDescending(b => b.Id).FirstOrDefault().Id;
            return currentMaxId +1;
        }

        public void Update(Book UpdateBook)
        {
            var oldBook = _books.Where(b => b.Id == UpdateBook.Id).FirstOrDefault();

            if (oldBook != null)
            {
                _books.Remove(oldBook);
                _books.Add(UpdateBook);
            }

            Save();
        }

        public void Delete(int id)
        {
            var book = _books.Where(b => b.Id == id).FirstOrDefault();

            if (book != null)
            {
                _books.Remove(book);
            }

            Save();
        }

        public void Save()
        {
            BookXmlDataService bookXmlDataService = new BookXmlDataService();

            using (bookXmlDataService)
            {
                bookXmlDataService.Write(_books);
            }
        }

        public void Dispose()
        {
            _books = null;
        }


    }
}