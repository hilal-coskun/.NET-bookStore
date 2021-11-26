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
    public class EfBookPublisherDal : EfEntityRepositoryBase<BookPublisher, BookCatalogContext>, IBookPublisherDal
    {
        public List<BookPublisher> SearchFilter(string EmpsearchName)
        {
            using (var context = new BookCatalogContext())
            {
                return context.BookPublisher.Where(i => i.Contact.Name.Contains(EmpsearchName)).ToList();
            }
        }

        public BookPublisher GetByIdWithBookCategories(int id)
        {
            using (var c = new BookCatalogContext())
            {
                return c.BookPublisher.Include(x => x.Contact).SingleOrDefault(x => x.ID == id);
            }
        }

        public List<BookPublisher> GetListWithBookCategories()
        {
            using (var c = new BookCatalogContext())
            {
                return c.BookPublisher.Include(x => x.Contact).ToList();
            }
        }
    }
}
