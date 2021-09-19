using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderStatusService
    {
        OrderStatus GetById(int orderStatusId);
        OrderStatus GetByID(int? orderStatusId);
        List<OrderStatus> GetList();
        List<OrderStatus> GetAll();
        List<OrderStatus> GetListCategory(int orderStatusId);
        void Add(OrderStatus orderStatus);
        void Delete(OrderStatus orderStatus);
        void Update(OrderStatus orderStatus);
    }
}
