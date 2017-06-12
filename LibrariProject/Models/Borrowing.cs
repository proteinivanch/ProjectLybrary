using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrariProject.Models
{
    public class Borrowing
    {
        public int BorrowingId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime RetuneDate { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<Member> Members { get; set; }

    }
}