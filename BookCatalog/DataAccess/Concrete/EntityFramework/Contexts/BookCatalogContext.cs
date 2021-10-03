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

       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookType>()
                .HasOne(sa => sa.BookCategory)
                .WithMany(sa => sa.BookType)
                .HasForeignKey(sa => sa.BookCategoryID);
        }*/


        public DbSet<BookCategory> BookCategory { get; set; }
        public DbSet<BookType> BookType { get; set; }
        public DbSet<BookPublisher> BookPublisher { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Translator> Translator { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<PaperType> PaperType { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<PasswordCode> PasswordCode { get; set; }
        public DbSet<PaymentChannel> PaymentChannel { get; set; }
    }
}
