using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBookTypeService
    {
        List<BookType> GetAll();
        List<BookType> GetList();
        BookType GetById(int bookTypeId);
        List<BookType> GetListWithBookCategories();
        BookType GetByIdCategories(int bookcategoryId);
        List<BookType> GetListCategory(int bookTypeId);
        List<BookType> SearchFilter(string Empsearch, string EmpsearchName);
        void Add(BookType bookType);
        void Delete(BookType bookType);
        void Update(BookType bookType);
    }
}
