using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrariProject.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Name { get; set; }
       // public string TitleAuthor { get; set; }
        public string ColorFoto { get; set; }
        public string Genre { get; set; }
        public int Stock { get; set; }
        public string ISBN { get; set; }
        public string PublishingOffice { get; set; }
        public string Edition { get; set; }
        public string ShortDescription { get; set; }
        public DateTime DatePublished { get; set; }

        public string TopAuthor { get; set; }
        public string Top2Author { get; set; }
        public string Top3Author { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public Book()
        {
            Authors = new List<Author>();
        }
    }

   
}