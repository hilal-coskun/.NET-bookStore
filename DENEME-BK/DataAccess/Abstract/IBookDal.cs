using Core.DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IBookDal : IEntityRepository<Book>
    {
        List<Book> GetListWithBookCategories();
        Book GetByIdWithBookCategories(int id);
        List<Book> SearchFilter(string stringCategory, string stringType, string stringPublisher, string language, string stringName);
    }
}
