using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderService
    {
        List<Order> GetAll(); 
        Order GetById(int orderId);
        List<Order> GetList();
        List<Order> GetListCategory(int orderId);
        Order GetByIdCategories(int bookcategoryId);
        List<Order> GetListWithItems();
        void Add(Order order);
        void Delete(Order order);
        void Update(Order order);
    }
}
