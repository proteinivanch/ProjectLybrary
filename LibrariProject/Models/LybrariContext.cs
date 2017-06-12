using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibrariProject.Models
{
    public class LybrariContext :DbContext
    {
        public LybrariContext()
            : base("DbConnection")
        { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Autors { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }
      //  public DbSet<BooksListViewModel> BooksListViewModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasMany(c => c.Books)
            .WithMany(s => s.Authors)
            .Map(t => t.MapLeftKey("AuthorId")
            .MapRightKey("BookId")
            .ToTable("BookAuthor"));
        }

    }
    public class CourseDbInitializer : CreateDatabaseIfNotExists<LybrariContext>
    {
        protected override void Seed(LybrariContext context)
        {
            
            Book book1 = new Book {
                Name = "Ночной дозор",  
                ColorFoto = "черная",
                Genre = "роман",
                Stock = 10,
                ISBN = "12345678",
                PublishingOffice="Новая Волна",
                Edition="Первое",
                ShortDescription="Первая часть саги",
                TopAuthor = "Лукъяненко",
                Top2Author ="",
                Top3Author="",
                DatePublished = new DateTime(2013,12,30),
             

            };
            Book book2 = new Book { 
                Name = "Сумеречный дозор",
                ColorFoto = "черная",
                Genre = "роман",
                Stock = 15,
                ISBN = "12345679",
                PublishingOffice = "Третья Волна",
                Edition = "Первое",
                TopAuthor = "Лукъяненко",
                Top2Author = "",
                Top3Author = "",
                ShortDescription = "Первая часть саги",
                DatePublished = new DateTime(2016, 12, 30),
              
            };
            Book book3 = new Book { 
                Name = "Дневной дозор",
                ColorFoto = "красная",
                Genre = "роман",
                Stock = 120,
                ISBN = "12345671",
                PublishingOffice = "Новая Волна",
                Edition = "Первое",
                TopAuthor = "Лукъяненко",
                Top2Author = "Васильев",
                Top3Author = "",
                ShortDescription = "Вторая часть саги",
                DatePublished = new DateTime(2015, 12, 30),
             
            };
            Book book4 = new Book
            {
                Name = "Библия",
                ColorFoto = "черная",
                Genre = "Религия",
                Stock = 50,
                ISBN = "123234678",
                PublishingOffice = "Регилия Мира",
                Edition = "Первое",
                ShortDescription = "Появился он из",
                TopAuthor = "",
                Top2Author = "",
                Top3Author = "",
                DatePublished = new DateTime(1999, 12, 30)
                
            };
            Book book5 = new Book
            {
                Name = "Дневник Алисы",
                ColorFoto = "черная",
                Genre = "роман",
                Stock = 10,
                ISBN = "3453453453",
                PublishingOffice = " ",
                Edition = "Первое",
                ShortDescription = "Алиса могла быть кем угодно",
                TopAuthor = "",
                Top2Author = "",
                Top3Author = "",
                DatePublished = new DateTime(2015, 5, 15)

            };
            Book book6 = new Book
            {
                Name = "Мастер и Маргарита",
                ColorFoto = "черная",
                Genre = "роман",
                Stock = 30,
                ISBN = "354345345",
                PublishingOffice = "Книги России",
                Edition = "Первое",
                ShortDescription = "История про любовь и не только",
                TopAuthor = "Булгаков",
                Top2Author = "",
                Top3Author = "",
                DatePublished = new DateTime(2013, 4, 15)

            };
            Book book7 = new Book
            {
                Name = "Унесенные ветром",
                ColorFoto = "цветная",
                Genre = "роман",
                Stock = 17,
                ISBN = "3453453453",
                PublishingOffice = " ",
                Edition = "Первое",
                ShortDescription = "Я подумаю об этом завтра",
                TopAuthor = "Маргарет Митчелл",
                Top2Author = "",
                Top3Author = "",
                DatePublished = new DateTime(1999, 11, 20)

            };
            Book book8 = new Book
            {
                Name = "Пикник на обочине",
                ColorFoto = "черная",
                Genre = "роман",
                Stock = 10,
                ISBN = "4353534533",
                PublishingOffice = " ",
                Edition = "Первое",
                ShortDescription = "Появился он из",
                TopAuthor = "Аркадий Стругацкий",
                Top2Author = "Борис Стругацкий ",
                Top3Author = "",
                DatePublished = new DateTime(2016, 8, 12)

            };
            Book book9 = new Book
            {
                Name = "Трудно быть богом",
                ColorFoto = "черная",
                Genre = "роман",
                Stock = 17,
                ISBN = "435354324234",
                PublishingOffice = " ",
                Edition = "Первое",
                ShortDescription = "Появился он из",
                TopAuthor = "Аркадий Стругацкий",
                Top2Author = "Борис Стругацкий ",
                Top3Author = "",
                DatePublished = new DateTime(2014, 6, 12)

            };
            Book book10 = new Book
            {
                Name = "Отель У Погибшего Альпиниста",
                ColorFoto = "черная",
                Genre = "фантастика",
                Stock = 40,
                ISBN = "125523243478",
                PublishingOffice = " ",
                Edition = "Первое",
                ShortDescription = "Появился он из",
                TopAuthor = "Аркадий Стругацкий",
                Top2Author = "Борис Стругацкий ",
                Top3Author = "",
                DatePublished = new DateTime(2013, 2, 1)

            };
            Book book11 = new Book
            {
                Name = "Обитаемый остров",
                ColorFoto = "черная",
                Genre = "фантастика",
                Stock = 10,
                ISBN = "1254353678",
                PublishingOffice = " ",
                Edition = "Первое",
                ShortDescription = "Появился он из",
                TopAuthor = "Аркадий Стругацкий",
                Top2Author = "Борис Стругацкий ",
                Top3Author = "",
                DatePublished = new DateTime(1998, 12, 10)

            };
            context.Books.Add(book1);
            context.Books.Add(book2);
            context.Books.Add(book3);
            context.Books.Add(book5);
            context.Books.Add(book6);
            context.Books.Add(book7);
            context.Books.Add(book8);
            context.Books.Add(book9); 
            context.Books.Add(book10);
            context.Books.Add(book11);
            context.Books.Add(book4);

           
            Author c1 = new Author
            {
                
               FIO = "Лукъяненко",
               Books = new List<Book>() { book1,book2,book3 }
            };
            Author c2 = new Author
            {

                FIO = "Васильев",
                Books = new List<Book>() {  book2 }
            };
           

            context.Autors.Add(c1);
            context.Autors.Add(c2);


            Member member1 = new Member
            {
               FIO="Петров"
            };
             Member member2 = new Member
            {
               FIO="Иванов"
            };
             Member member3 = new Member
             {
                 FIO = "Сидоров"
             };
             Member member4 = new Member
             {
                 FIO = "Жданов"
             };
             context.Members.Add(member1);
             context.Members.Add(member2);
             context.Members.Add(member3);
             context.Members.Add(member4);

             Borrowing borrowing1 = new Borrowing
             {
                 BorrowDate = new DateTime(2017, 01, 30),
                 RetuneDate = new DateTime(2017,02,25),
                 Books = new List<Book> { book1},
                 Members = new List<Member>{member1}
                
             };
             Borrowing borrowing2 = new Borrowing
             {
                 BorrowDate = new DateTime(2017, 01, 30),
                 RetuneDate = new DateTime(2017, 02, 25),
                 Books = new List<Book> { book2},
                 Members = new List<Member> { member2 }

             };
             Borrowing borrowing3 = new Borrowing
             {
                 BorrowDate = new DateTime(2017, 01, 30),
                 RetuneDate = new DateTime(2017, 02, 25),
                 Books = new List<Book> { book3 },
                 Members = new List<Member> { member3 }

             };
             Borrowing borrowing4 = new Borrowing
             {
                 BorrowDate = new DateTime(2017, 01, 30),
                 RetuneDate = new DateTime(2017, 02, 25),
                 Books = new List<Book> { book4 },
                 Members = new List<Member> { member4 }

             };
             context.Borrowings.Add(borrowing1);
             context.Borrowings.Add(borrowing2);
             context.Borrowings.Add(borrowing3);
             context.Borrowings.Add(borrowing4);
            base.Seed(context);
        }
    }
}