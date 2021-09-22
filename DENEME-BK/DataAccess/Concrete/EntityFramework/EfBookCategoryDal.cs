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
       /* public List<BookType> GetBookCategory(BookCategory bookCategory)
        {
            using (var context = new BookCatalogContext())
            {
                var result = from bookCategories in context.BookCategory
                             join bookTypes in context.BookType
                             on bookCategories.ID equals bookTypes.BookCategoryID
                             select new BookType
                             {
                                 ID = bookTypes.ID,
                                 Name = bookTypes.Name
                             };
                return result.ToList();
            }
        }*/
    }
}
