using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderStatusManager : IOrderStatusService
    {
        private IOrderStatusDal _orderStatusDal;

        public OrderStatusManager(IOrderStatusDal orderStatusDal)
        {
            _orderStatusDal = orderStatusDal;
        }


        public OrderStatus GetById(int orderStatusId)
        {
            return _orderStatusDal.Get(p => p.ID == orderStatusId);
        }

        public OrderStatus GetByID(int? orderStatusId)
        {
            return _orderStatusDal.Get(p => p.ID == orderStatusId);
        }

        public List<OrderStatus> GetAll()
        {
            return _orderStatusDal.GetList().ToList();
        }

        public OrderStatus GetByID(int orderStatusId)
        {
            return _orderStatusDal.Get(p => p.ID == orderStatusId);
        }

        public List<OrderStatus> GetList()
        {
            return _orderStatusDal.GetList().ToList();
        }

        public List<OrderStatus> GetListCategory(int orderStatusId)
        {
            return _orderStatusDal.GetList(b => b.ID == orderStatusId).ToList();
        }

        public void Add(OrderStatus orderStatus)
        {
            //business code
            _orderStatusDal.Add(orderStatus);
        }

        public void Delete(OrderStatus orderStatus)
        {
            _orderStatusDal.Delete(orderStatus);
        }

        public void Update(OrderStatus orderStatus)
        {
            _orderStatusDal.Update(orderStatus);
        }
    }
}
