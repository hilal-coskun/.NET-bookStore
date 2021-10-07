using Core.DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IBookTypeDal : IEntityRepository<BookType>
    {
        List<BookType> GetListWithBookCategories();
        BookType GetByIdWithBookCategories(int id);
        List<BookType> SearchFilter(string Empsearch,string EmpsearchName);
    }
}
