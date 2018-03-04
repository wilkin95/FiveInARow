using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FiveInARowApp.DAL;
using FiveInARowApp.Models;
using System.Web.Mvc;
using PagedList;

namespace FiveInARowApp.Controllers
{
    public class BookController : Controller
    {
        [HttpGet]
        public ActionResult Index(string sortOrder, int? page)
        {
            //instantiate a repository
            BookRepository bookRepository = new BookRepository();

            // create a distinct list of cities for the city filter
            ViewBag.Authors = ListOfAuthors();

            //return the data context as an enumerable
            IEnumerable<Book> books;
            using (bookRepository)
            {
                books = bookRepository.SelectAll() as IList<Book>;
            }

            //sort by title unless posted as a new sort
            switch (sortOrder)
            {
                case "Title":
                    books = books.OrderBy(book => book.Title);
                    break;
                case "Author":
                    books = books.OrderBy(book => book.Author);
                    break;
                default:
                    break;
            }

            //set parameters and paginate the books list
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            books = books.ToPagedList(pageNumber, pageSize);

            return View(books);
        }

        [HttpPost]
        public ActionResult Index(string searchCriteria, string authorFilter, int? page)
        {
            //instantiate a repository
            BookRepository bookRepository = new BookRepository();

            //create a distinct list of authors for the author filter
            ViewBag.Authors = ListOfAuthors();

            // return the data context as an enumerable
            IEnumerable<Book> books;
            using (bookRepository)
            {
                books = bookRepository.SelectAll() as IList<Book>;
            }

            //if posted with a search on book name
            if (searchCriteria != null)
            {
                books = books.Where(book => book.Title.ToUpper().Contains(searchCriteria.ToUpper()));
            }

            //if posted with a filter by author
            if (authorFilter != "" || authorFilter == null)
            {
                books = books.Where(book => book.Author == authorFilter);
            }

            //set parameters and paginate the books list
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            books = books.ToPagedList(pageNumber, pageSize);

            return View(books);
        }

        [NonAction]
        private IEnumerable<string> ListOfAuthors()
        {
            //instantiate a repository
            BookRepository bookRepository = new BookRepository();

            //return the data context as an enumerable
            IEnumerable<Book> books;
            using (bookRepository)
            {
                books = bookRepository.SelectAll() as IList<Book>;
            }

            // get a distinct list of authors
            var authors = books.Select(book => book.Author).Distinct().OrderBy(x => x);

            return authors;
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            //instantiate a repository
            BookRepository bookRepository = new BookRepository();
            Book book = new Book();

            //get a book that has the matching Id
            using (bookRepository)
            {
                book = bookRepository.SelectOne(id);
            }
                return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                BookRepository bookRepository = new BookRepository();

                using (bookRepository)
                {
                    bookRepository.Insert(book);
                }
                    return RedirectToAction("Index");
            }
            catch
            {
                //TODO Add view for error message
                return View();
            }
        }

        // GET: Book/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            BookRepository bookRepository = new BookRepository();
            Book book = new Book();

            using (bookRepository)
            {
                book = bookRepository.SelectOne(id);
            }

                return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            try
            {
                BookRepository bookRepository = new BookRepository();

                using (bookRepository)
                {
                    bookRepository.Update(book);
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                //TODO Add view for error message
                return View();
            }
        }

        // GET: Book/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            BookRepository bookRepository = new BookRepository();
            Book book = new Book();

            using (bookRepository)
            {
                book = bookRepository.SelectOne(id);
            }
                return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Book book)
        {
            try
            {
               BookRepository bookRepository = new BookRepository();

                using (bookRepository)
                {
                    bookRepository.Delete(id);
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                //TODO Add view for error message
                return View();
            }
        }
    }
}
