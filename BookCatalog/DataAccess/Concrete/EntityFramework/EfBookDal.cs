using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBookDal : EfEntityRepositoryBase<Book, BookCatalogContext>, IBookDal
    {
        public Book GetByIdWithBookCategories(int id)
        {
            using (var c = new BookCatalogContext())
            {
                return c.Book
                    .Include(x => x.Language)
                    .Include(x => x.PaperType)
                    .Include(x => x.Author)
                    .Include(x => x.BookPublisher)
                    .Include(x => x.BookType)
                    .Include(x => x.BookCategory)
                    .Include(x => x.Translator)
                    .Include(x =>x.BookPublisher)
                    .SingleOrDefault(x => x.ID == id);
            }
        }

        public List<Book> GetListWithBookCategories()
        {
            using (var c = new BookCatalogContext())
            {
                return c.Book
                    .Include(x => x.Language)
                    .Include(x => x.PaperType)
                    .Include(x => x.Author)
                    .Include(x => x.BookPublisher)
                    .Include(x => x.BookType)
                    .Include(x => x.BookCategory)
                    .Include(x => x.Translator)
                    .ToList();
            }
        }

        public List<Book> SearchFilter(string stringCategory, string stringType, string stringPublisher, string language, string stringName)
        {
            using (var context = new BookCatalogContext())
            {
                return context.Book.Where(i => i.BookCategory.Name.Contains(stringCategory) || 
                    i.BookType.Name.Contains(stringType) || 
                    i.BookPublisher.Contact.Name.Contains(stringPublisher) || 
                    i.Language.Name.Contains(language) || 
                    i.Name.Contains(stringName))
                    .ToList();
            }
        }
    }
}
