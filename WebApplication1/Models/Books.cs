using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Books
    {
        public List<string> GetBook()
        {
            List<string> books = new List<string>()
            {
                "one","two","three"
            };
            return books;
        }
    }
}