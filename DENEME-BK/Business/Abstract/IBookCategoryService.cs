
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBookCategoryService
    {
        BookCategory GetById(int bookCategoryId);
        List<BookCategory> GetList();
        List<BookCategory> GetAll();
        List<BookCategory> GetListCategory(int categoryId);
        void Add(BookCategory bookCategory);
        void Delete(BookCategory bookCategory);
        void Update(BookCategory bookCategory);
    }
}
