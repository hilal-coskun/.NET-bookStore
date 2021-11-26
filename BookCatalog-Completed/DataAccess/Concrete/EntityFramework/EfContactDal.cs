using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfContactDal : EfEntityRepositoryBase<Contact, BookCatalogContext>, IContactDal
    {
        public List<Contact> SearchFilter(string searchName, string searchPhone, string searchEmail)
        {
            using (var context = new BookCatalogContext())
            {
                var filter = context.Contact.Where(i => i.Name.Contains(searchName) || i.Mobile.Contains(searchPhone) || i.Email.Contains(searchEmail)).ToList();
                return filter;
            }
        }
    }
}
