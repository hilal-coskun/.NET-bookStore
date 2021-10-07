using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBookPublisherService
    {
        List<BookPublisher> GetAll();
        BookPublisher GetById(int bookPublisherId);
        List<BookPublisher> GetList();
        List<BookPublisher> GetListWithBookCategories();
        BookPublisher GetByIdCategories(int id);
        List<BookPublisher> GetListCategory(int bookPublisherId);
        List<BookPublisher> SearchFilter(string Empsearch);
        void Add(BookPublisher bookPublisher);
        void Delete(BookPublisher bookPublisher);
        void Update(BookPublisher bookPublisher);
    }
}
