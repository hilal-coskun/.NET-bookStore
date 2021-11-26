using Core.DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IContactDal : IEntityRepository<Contact>
    {
        List<Contact> SearchFilter(string searchName, string searchPhone,string searchEmail);
    }
}
