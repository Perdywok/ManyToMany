﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using ManyToMany.Models;

namespace ManyToMany.Controllers
{
    public class GridController : Controller
    {
        private Library db = new Library();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Books_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Book> books = db.Books;
            DataSourceResult result = books.ToDataSourceResult(request, book => new {
                BookId = book.BookId,
                BookName = book.BookName,
                Pages = book.Pages,
                Publisher = book.Publisher,
                Genre = book.Genre
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Books_Create([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<Book> books)
        {
            var entities = new List<Book>();
            if (books != null && ModelState.IsValid)
            {
                foreach(var book in books)
                {
                    var entity = new Book
                    {
                            BookName = book.BookName,
                            Pages = book.Pages,
                            Publisher = book.Publisher,
                            Genre = book.Genre
                    };

                    db.Books.Add(entity);
                    entities.Add(entity);
                }
                db.SaveChanges();
            }

            return Json(entities.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Books_Update([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<Book> books)
        {
            var entities = new List<Book>();
            if (books != null && ModelState.IsValid)
            {
                foreach(var book in books)
                {
                    var entity = new Book
                    {
                        BookId = book.BookId,
                        BookName = book.BookName,
                        Pages = book.Pages,
                        Publisher = book.Publisher,
                        Genre = book.Genre
                    };

                    entities.Add(entity);
                    db.Books.Attach(entity);
                    db.Entry(entity).State = EntityState.Modified;                        
                }
                db.SaveChanges();
            }

            return Json(entities.ToDataSourceResult(request, ModelState));
        } 

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Books_Destroy([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<Book> books)
        {
            var entities = new List<Book>();
            if (ModelState.IsValid)
            {
                foreach(var book in books)
                {
                    var entity = new Book
                    {
                        BookId = book.BookId,
                        BookName = book.BookName,
                        Pages = book.Pages,
                        Publisher = book.Publisher,
                        Genre = book.Genre
                    };

                    entities.Add(entity);
                    db.Books.Attach(entity);
                    db.Books.Remove(entity);
                }
                db.SaveChanges();
            }

            return Json(entities.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
