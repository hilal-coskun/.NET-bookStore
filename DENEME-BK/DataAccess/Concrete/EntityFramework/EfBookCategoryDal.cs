using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBookCategoryDal : EfEntityRepositoryBase<BookCategory, BookCatalogContext>, IBookCategoryDal
    {
        /* readonly BookCatalogContext _bookCatalogContext = new BookCatalogContext();

         public EfBookCategoryDal(BookCatalogContext bookCatalogContext)
         {
             _bookCatalogContext = bookCatalogContext;
         }

         public void Create(BookCategory bookCategory)
         {
             _bookCatalogContext.BookCategory.Add(bookCategory);
             _bookCatalogContext.SaveChanges();
         }
        
        
        public void Delete(BookCategory bookCategory)
         {
             BookCategory bookCategoryDelete = _bookCatalogContext.BookCategory.Find(bookCategory.ID);
             _bookCatalogContext.BookCategory.Remove(bookCategoryDelete);
             _bookCatalogContext.SaveChanges();
        }

        public void Update(BookCategory bookCategory)
         {
             BookCategory bookCategoryUpdate = _bookCatalogContext.BookCategory.Find(bookCategory.ID);
             bookCategoryUpdate.Name = bookCategory.Name;
             _bookCatalogContext.SaveChanges();
         }


        public BookCategory GetById(int bookCategoryId)
        {
            return _bookCatalogContext.BookCategory.FirstOrDefault(i => i.ID == bookCategoryId);
        }

        */
        
    }
}
