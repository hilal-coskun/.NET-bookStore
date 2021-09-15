using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class BookCatalogContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-7T3A46FU\MSSQLSERVER_2;initial catalog=BCatalog;User id=admin; password=1397");
        }

        public DbSet<BookCategory> BookCategory { get; set; }
        public DbSet<BookType> BookType { get; set; }
        public DbSet<BookPublisher> BookPublisher { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Translator> Translator { get; set; }

    }
}
