using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrariProject.Models
{
    public class Author
    {
        public int AuthorId {get;set;}
        public string FIO { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public Author()
        {
            Books = new List<Book>();
        }
    }

}