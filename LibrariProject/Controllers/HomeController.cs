using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibrariProject.Models;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;




namespace LibrariProject.Controllers
{
    public static class DateTimeExtensions
    {
        public static bool IsInRange(this DateTime dateToCheck, DateTime startDate, DateTime endDate)
        {
            return dateToCheck >= startDate && dateToCheck < endDate;
        }
    }
    public class HomeController : Controller
    {
        LybrariContext db = new LybrariContext();
       

        public ActionResult Index()
        {

            ViewBag.Authors = db.Autors.ToList();
            return View(db.Books.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            //Author author = db.Autors.Find(id);
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        public ActionResult Edit(int id = 0)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.Authors = db.Autors.ToList();
            return View(book);
        }
        [HttpPost]
        public ActionResult Edit(Book book, int[] selectedAuthors)
        {
            Book newBook = db.Books.Find(book.BookId);
            newBook.Name = book.Name;
            newBook.ColorFoto = book.ColorFoto;

            newBook.Authors.Clear();
            if (selectedAuthors != null)
            {
                //получаем выбранных авторов
                foreach (var c in db.Autors.Where(co => selectedAuthors.Contains(co.AuthorId)))
                {
                    newBook.Authors.Add(c);
                }
            }

            db.Entry(newBook).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            ViewBag.Authors = db.Autors.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book book, int[] selectedAuthors)
        {
            if (selectedAuthors != null)
            {
                //получаем выбранных авторов
                foreach (var c in db.Autors.Where(co => selectedAuthors.Contains(co.AuthorId)))
                {
                    book.Authors.Add(c);
                }
            }

            db.Books.Add(book);

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "YourAbout.";

            return View();
        }


        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DatePublished
        {
            get { return DatePublished; }
            set { DatePublished = value; }
        }


       
        
        public ActionResult SearchForAuthor(string authorName)
        {

            var author = from s in db.Books
                         select s;
            if (!System.String.IsNullOrEmpty(authorName))
            {
                author = author.Where(c => c.TopAuthor.ToString().Contains(authorName) || c.Top2Author.ToString().Contains(authorName) || c.Top3Author.ToString().Contains(authorName));
            }
            return View(author);
        }

        public ActionResult SearchForNonAuthor(string authorName)
        {
            var author = from s in db.Books
                         select s;
            if (!System.String.IsNullOrEmpty(authorName))
            {
                author = author.Where(c => c.TopAuthor.ToString() == "");
            }
            return View(author);
        }


       


        [HttpGet]
        public ActionResult NewGetAuthor()
        {
            var allbooks = db.Books;

            return View(allbooks);
        }

    //[HttpPost]
    public ActionResult NewGetAuthor(List<string> names)
    {
        string local1 = names[0];
        string local2 = names[1];
        string local3 = names[2];
        // var allbooks = db.Books.ToList<Book>();
        var author = from s in db.Books

                     select s;

        //for (int i = 0; i < names.Count; i++)
        //{
        if ((!System.String.IsNullOrEmpty(names[0])) || (!System.String.IsNullOrEmpty(names[1])) || (!System.String.IsNullOrEmpty(names[2])))
        {
            // author = author.Where(k => k.TopAuthor[0].ToString().Contains(names[0]));    //.ToList<Book>();
            author = author.Where(l => l.TopAuthor.ToString().Contains(local1));
            author = author.Where(l => l.Top2Author.ToString().Contains(local2));
            author = author.Where(l => l.Top3Author.ToString().Contains(local3));
        }
        //}
        return View(author);
    }
    

    


    public ActionResult SearchForStyle(string styleName)
    {
        
        ViewBag.Authors = db.Autors.ToList();
        var styles = from s in db.Books
                     select s;
        if (!System.String.IsNullOrEmpty(styleName))
        {
            styles = styles.Where(c => c.Name.Contains(styleName));
        }
        
        return View(styles);
    }

    [HttpGet]
    public ActionResult SearchGroup()
    {
        var allbooks = db.Books;

        return View(allbooks);
    }
    //[HttpPost]
    public ActionResult SearchGroup(List<string> names)
    {
       
        string name = names[0];
        string local1 = names[1];
        string local2 = names[2];
        string local3 = names[3];
        string shortd = names[4];
        // var allbooks = db.Books.ToList<Book>();
        var author = from s in db.Books

                     select s;

        //for (int i = 0; i < names.Count; i++)
        //{
        if ((!System.String.IsNullOrEmpty(names[0])) || (!System.String.IsNullOrEmpty(names[1])) || (!System.String.IsNullOrEmpty(names[2])) || (!System.String.IsNullOrEmpty(names[3])) || (!System.String.IsNullOrEmpty(names[4])))
        {
            // author = author.Where(k => k.TopAuthor[0].ToString().Contains(names[0]));    //.ToList<Book>();
            author = author.Where(l => l.Name.ToString().Contains(name));
            author = author.Where(l => l.TopAuthor.ToString().Contains(local1));
            author = author.Where(l => l.Top2Author.ToString().Contains(local2));
            author = author.Where(l => l.Top3Author.ToString().Contains(local3));
            author = author.Where(l => l.ShortDescription.ToString().Contains(shortd));
        }
        //}
        return View(author);
    }
    [HttpGet]
    public ActionResult SearchTopBoos()
    {
        var allbooks = db.Borrowings;

        return View(allbooks);
    }
 
    //[HttpPost]
    public ActionResult SearchTopBoos(List<DateTime> names)
    {
     
        DateTime local1 = names[0];
        DateTime local2 = names[1];
      
        // var allbooks = db.Books.ToList<Book>();
        var author = from s in db.Borrowings

                     select s;
        author = author.Where(l => l.BorrowDate.IsInRange(local1,local2));
        
        return View(author);
    }
    }


}