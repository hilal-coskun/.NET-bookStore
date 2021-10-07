using Core.DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IOrderDal : IEntityRepository<Order>
    {
        List<Order> GetListWithItems();
        Order GetByIdWithBookCategories(int id);
        //List<BookCategory> SearchFilter(string EmpsearchName, string searchStatus, string Date);
    }
}
