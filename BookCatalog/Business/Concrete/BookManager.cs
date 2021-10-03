using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class BookManager : IBookService
    {
        private IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }


        public Book GetById(int bookId)
        {
            return _bookDal.Get(p => p.ID == bookId);
        }

        public List<Book> GetAll()
        {
            return _bookDal.GetList().ToList();
        }

        public List<Book> GetList()
        {
            return _bookDal.GetList().ToList();
        }

        public List<Book> GetListCategory(int bookId)
        {
            return _bookDal.GetList(b => b.ID == bookId).ToList();
        }

        public void Add(Book book)
        {
            //business code
            _bookDal.Add(book);
        }

        public void Delete(Book book)
        {
            _bookDal.Delete(book);
        }

        public void Update(Book book)
        {
            _bookDal.Update(book);
        }

        public List<Book> GetListWithBookCategories()
        {
            return _bookDal.GetListWithBookCategories();
        }

        public List<Book> SearchFilter(string stringCategory, string stringType, string stringPublisher, string language, string stringName)
        {
            return _bookDal.SearchFilter(stringCategory, stringType, stringPublisher, language, stringName);
        }

        public List<Book> GetBookListByAuthor(int id)
        {
            return _bookDal.GetList(x => x.AuthorID == id);
        }

        public Book GetByIdCategories(int bookcategoryId)
        {
            return _bookDal.GetByIdWithBookCategories(bookcategoryId);
        }
    }
}
