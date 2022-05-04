using Microsoft.EntityFrameworkCore;
using System;

namespace lab_8
{
    class Program
    {
        static void Main(string[] args)
        {
            AppContext context = new AppContext();
            context.Database.EnsureCreated();
            Console.WriteLine(context.Books.Find(1));
            //context.Books.Add(new Book() { }); <- insert data to db
            //context.Books.Remove(); <- remove data from db
            //context.SaveChanges();
        }
    }

    public record Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int EditionYear { get; set; }

        public int AuthorId { get; set; }
    }

    public record Author
        //all properties need get and set
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class AppContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DATASOURCE=d:\\database\\data.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Book>()
                .ToTable("books")
                .HasData(
                new Book() { Id = 1, AuthorId = 1, EditionYear = 2020, Title = "The Lord of the rings" },
                new Book() { Id = 2, AuthorId = 1, EditionYear = 2020, Title = "Hobbit" },
                new Book() { Id = 3, AuthorId = 2, EditionYear = 2020, Title = "Clean code" }
                );
            modelBuilder
                .Entity<Author>()
                .ToTable("Authors")
                .HasData(
                    new Author() { Id = 1, Name = "J.R.R. Tolkien"},
                    new Author() { Id = 2, Name = "Martin Robert C." }
                );
        }
    }
}
