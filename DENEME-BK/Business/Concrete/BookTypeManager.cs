using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class BookTypeManager : IBookTypeService
    {
        private IBookTypeDal _bookTypeDal;

        public BookTypeManager(IBookTypeDal bookTypeDal)
        {
            _bookTypeDal = bookTypeDal;
        }

        public List<BookType> GetAll()
        {
            return _bookTypeDal.GetList().ToList();
        }
        

        public BookType GetById(int bookTypeId)
        {
            return _bookTypeDal.Get(p => p.ID == bookTypeId);
        }

        
        public List<BookType> GetList()
        {
            return _bookTypeDal.GetList().ToList();
        }

        public List<BookType> GetListCategory(int bookTypeId)
        {
            return _bookTypeDal.GetList(b => b.ID == bookTypeId).ToList();
        }

        public void Add(BookType bookType)
        {
            //business code
            _bookTypeDal.Add(bookType);
        }

        public void Delete(BookType bookType)
        {
            _bookTypeDal.Delete(bookType);
        }

        public void Update(BookType bookType)
        {
            _bookTypeDal.Update(bookType);
        }

    }
}
