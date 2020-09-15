using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Books
    {
        private List<string> GetBooks()
        {
            List<string> books = new List<string>()
            {
                "one","two","three"
            };
            return books;
        }

        public List<BooksView> GetCheckedBooks()
        {
            List<BooksView> Allbooks = new List<BooksView>();
            foreach (var item in GetBooks())
            {
                BooksView booksView = new BooksView
                {
                    Name = item
                };
                Allbooks.Add(booksView);
            }
            return Allbooks;
        }
    }
}