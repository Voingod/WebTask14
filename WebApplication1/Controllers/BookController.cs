
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        [HttpGet]
        public ActionResult Index()
        {
            Books books = new Books();
            BookModel bookModel = new BookModel();
            bookModel.books = books.GetBook();

            BooksView booksView = new BooksView();
            booksView.BookModels.books = books.GetBook();

            return View(bookModel);
        }
        [HttpPost]
        public string Index(Books books, object Ischeck)
        {
            var b = books.GetBook();
            return "Good";
        }

    }
}