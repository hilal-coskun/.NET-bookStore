using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, BookCatalogContext>,IOrderDal
    {
        public Order GetByIdWithBookCategories(int id)
        {
            using (var c = new BookCatalogContext())
            {
                return c.Order
                    .Include(x => x.Contact)
                    .Include(x => x.Book)
                    .Include(x => x.PaymentChannel)
                    .Include(x => x.OrderStatus)
                    .SingleOrDefault(x => x.ID == id);
            }

        }

        public List<Order> GetListWithItems()
        {
            using (var c = new BookCatalogContext())
            {
                return c.Order
                    .Include(x => x.Contact)
                    .Include(x => x.Book)
                    .Include(x => x.PaymentChannel)
                    .Include(x => x.OrderStatus)
                    .ToList();
            }
        }

         /*public List<BookCategory> SearchFilter(string EmpsearchName string searchStatus, string Date)
        {
           using (var context = new BookCatalogContext())
            {
                return context.Order.Where(i => i.Customer.Contact);
            }
        }*/
    }
}
