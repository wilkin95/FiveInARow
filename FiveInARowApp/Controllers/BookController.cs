﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FiveInARowApp.DAL;
using FiveInARowApp.Models;
using System.Web.Mvc;

namespace FiveInARowApp.Controllers
{
    public class BookController : Controller
    {
        [HttpGet]
        public ActionResult Index(string sortOrder)
        {
            //instantiate a repository
            BookRepository bookRepository = new BookRepository();

            //return the data context as an enumerable
            IEnumerable<Book> books;
            using (bookRepository)
            {
                books = bookRepository.SelectAll() as IList<Book>;
            }
                return View(books);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
