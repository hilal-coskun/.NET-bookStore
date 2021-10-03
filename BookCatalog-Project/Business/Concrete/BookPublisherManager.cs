using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class BookPublisherManager : IBookPublisherService
    {
        private IBookPublisherDal _bookPublisherDal;

        public BookPublisherManager(IBookPublisherDal bookPublisherDal)
        {
            _bookPublisherDal = bookPublisherDal;
        }

        public List<BookPublisher> GetAll()
        {
            return _bookPublisherDal.GetList().ToList();
        }
        

        public BookPublisher GetById(int bookPublisherId)
        {
            return _bookPublisherDal.Get(p => p.ID == bookPublisherId);
        }


        public List<BookPublisher> GetList()
        {
            return _bookPublisherDal.GetList().ToList();
        }

        public List<BookPublisher> GetListCategory(int bookPublisherId)
        {
            return _bookPublisherDal.GetList(b => b.ID == bookPublisherId).ToList();
        }

        public void Add(BookPublisher bookPublisher)
        {
            //business code
            _bookPublisherDal.Add(bookPublisher);
        }

        public void Delete(BookPublisher bookPublisher)
        {
            _bookPublisherDal.Delete(bookPublisher);
        }

        public void Update(BookPublisher bookPublisher)
        {
            _bookPublisherDal.Update(bookPublisher);
        }

        public List<BookPublisher> SearchFilter(string Empsearch)
        {
            return _bookPublisherDal.SearchFilter(Empsearch);
        }

        public List<BookPublisher> GetListWithBookCategories()
        {
            return _bookPublisherDal.GetListWithBookCategories();
        }

        public BookPublisher GetByIdCategories(int id)
        {
            return _bookPublisherDal.GetByIdWithBookCategories(id);
        }
    }
}
