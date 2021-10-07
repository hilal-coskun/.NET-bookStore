using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        
        public List<Order> GetAll()
        {
            return _orderDal.GetList().ToList();
        }

        public Order GetById(int orderId)
        {
            return _orderDal.Get(p => p.ID == orderId);
        }


        public List<Order> GetList()
        {
            return _orderDal.GetList().ToList();
        }

        public List<Order> GetListCategory(int orderId)
        {
            return _orderDal.GetList(b => b.ID == orderId).ToList();
        }

        public void Add(Order order)
        {
            //business code
            _orderDal.Add(order);
        }

        public void Delete(Order order)
        {
            _orderDal.Delete(order);
        }

        public void Update(Order order)
        {
            _orderDal.Update(order);
        }

        public List<Order> GetListWithItems()
        {
            return _orderDal.GetListWithItems();
        }

        public Order GetByIdCategories(int id)
        {
            return _orderDal.GetByIdWithBookCategories(id);
        }
    }
}
