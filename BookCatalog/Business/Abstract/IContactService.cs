using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IContactService
    {
        List<Contact> GetAll();
        List<Contact> GetList();
        Contact GetById(int contactId);
        List<Contact> GetListCategory(int contactId);
        List<Contact> SearchFilter(string searchName, string searchPhone, string searchEmail);
        void Add(Contact contact);
        void Delete(Contact contact);
        void Update(Contact contact);
    }
}
