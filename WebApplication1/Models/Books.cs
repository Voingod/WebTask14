using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Books
    {
        private List<BookOne> GetBooks()
        {
            List<BookOne> books = new List<BookOne>()
            {
                new BookOne{Name="one"},
                new BookOne{Name="two"},
                new BookOne{Name="three"}
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
                    ViewName = item
                };
                Allbooks.Add(booksView);
            }
            return Allbooks;
        }

    }
    public class BooksView
    {
        public BookOne ViewName { get; set; }
        public bool IsCheck { get; set; }
    }
    public class BookM
    {
        public List<BooksView> BooksViews { get; set; }
    }

    public class BookOne
    {
        public string Name{ get;set;}
    }
}