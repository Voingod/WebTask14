using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebApplication1.Models
{
    public class BooksView
    {
        public string Name{ get; set; }
        public bool IsCheck { get; set; }
    }
    public class BookM
    {
        public List<BooksView> BooksViews { get; set; }
    }
}