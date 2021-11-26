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
        public BookCategory DeleteForeign(int bookCategoryId)
        {
            using (var context = new BookCatalogContext())
            {
                return context.Set<BookCategory>().Find(bookCategoryId);
            }
        }

        public List<BookCategory> SearchFilter(string Empsearch)
        {
            using (var context = new BookCatalogContext())
            {
                return context.BookCategory.Where(i => i.Name.Contains(Empsearch)).ToList(); 
            }
        }
    }
}
