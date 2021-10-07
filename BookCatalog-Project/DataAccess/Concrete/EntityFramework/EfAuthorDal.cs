using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAuthorDal : EfEntityRepositoryBase<Author, BookCatalogContext>, IAuthorDal
    {
        public List<Author> SearchFilter(string Empsearch)
        {
            using (var context = new BookCatalogContext())
            {
                return context.Author.Where(i => i.Name.Contains(Empsearch)).ToList();
            }
        }
    }
}
