using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBookService
    {
        List<Book> GetAll();
        Book GetById(int bookId);
        List<Book> GetList();
        List<Book> GetListWithBookCategories();
        Book GetByIdCategories(int bookcategoryId);
        List<Book> SearchFilter(string stringCategory, string stringType, string stringPublisher, string language, string stringName);
        List<Book> GetListCategory(int bookId);
        List<Book> GetBookListByAuthor(int id);
        void Add(Book book);
        void Delete(Book book);
        void Update(Book book);
    }
}
