using Business.Abstract;
using Castle.Core.Internal;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class BookCategoryManager : IBookCategoryService
    {
        private IBookCategoryDal _bookCategoryDal;

        public BookCategoryManager(IBookCategoryDal bookCategoryDal)
        {
            _bookCategoryDal = bookCategoryDal;
        }

        
        public BookCategory GetById(int bookCategoryId)
        {
            return _bookCategoryDal.Get(p => p.ID == bookCategoryId);
        }

        public BookCategory GetByID(int? bookCategoryId)
        {
            return _bookCategoryDal.Get(p => p.ID == bookCategoryId);
        }

        public List<BookCategory> GetAll()
        {
            return _bookCategoryDal.GetList().ToList();
        }
        
        public BookCategory GetByID(int bookCategoryId)
        {
            return _bookCategoryDal.Get(p => p.ID == bookCategoryId);
        }

        public List<BookCategory> GetList()
        {
            return _bookCategoryDal.GetList().ToList();
        }

        public List<BookCategory>  GetListCategory(int categoryId)
        {
            return _bookCategoryDal.GetList( b => b.ID == categoryId).ToList();
        }

        public void Add(BookCategory bookCategory)
        {
            //business code
            _bookCategoryDal.Add(bookCategory);
        }

        public void Delete(BookCategory bookCategory)
        {
            _bookCategoryDal.Delete(bookCategory);
        }

        public void Update(BookCategory bookCategory)
        {
            _bookCategoryDal.Update(bookCategory);
        }

        public List<BookCategory> SearchFilter(string p)
        {
            return _bookCategoryDal.SearchFilter(p);
        }

        public BookCategory DeleteForeignn(int bookCategoryId)
        {
            var x = _bookCategoryDal.DeleteForeign(bookCategoryId);
            x.Status = false;
            return x;
        }
    }
}
