
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
            BookM bookM = new BookM();

            bookM.BooksViews = books.GetCheckedBooks();

            return View(bookM);
        }
        [HttpPost]
        public string Index(BookM model, HttpPostedFileBase myFileName)
        {
            var flen = myFileName.ContentLength;
            byte[] arr = new byte[flen];
            myFileName.InputStream.Read(arr, 0, flen);
            var ss = Convert.ToBase64String(arr);

            //var b = books.GetBook();
            return "Good";
        }

    }
}