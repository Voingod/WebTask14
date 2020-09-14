using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class BookModel
    {
        public List<BookModel> Allbooks { get; set; }
        public List<string> books { get; set; }
        public int Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public bool IsSelected
        {
            get;
            set;
        }
    }
}