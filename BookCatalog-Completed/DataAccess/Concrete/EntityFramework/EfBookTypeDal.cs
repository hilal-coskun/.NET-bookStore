using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBookTypeDal : EfEntityRepositoryBase<BookType, BookCatalogContext>, IBookTypeDal
    {
        public BookType GetByIdWithBookCategories(int id)
        {
            using (var c = new BookCatalogContext())
            {
                return c.BookType.Include(x => x.BookCategory).SingleOrDefault(x => x.ID == id);
            }
        }

        public List<BookType> GetListWithBookCategories()
        {
            using (var c = new BookCatalogContext())
            {
                return c.BookType.Include(x => x.BookCategory).ToList();
            }
        }

        public List<BookType> SearchFilter(string Empsearch, string EmpsearchName)
        {
            using (var context = new BookCatalogContext())
            {
                return context.BookType.Where(i => i.BookCategory.Name.Contains(Empsearch) || i.Name.Contains(EmpsearchName))
                    .ToList();
            }
        }
    }
}
