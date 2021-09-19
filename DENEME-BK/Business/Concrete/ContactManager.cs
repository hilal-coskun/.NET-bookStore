using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ContactManager : IContactService
    {
        private IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public List<Contact> GetAll()
        {
            return _contactDal.GetList().ToList();
        }

        public Contact GetById(int contactId)
        {
            return _contactDal.Get(p => p.ID == contactId);
        }

      
        public List<Contact> GetList()
        {
            return _contactDal.GetList().ToList();
        }

        public List<Contact> GetListCategory(int contactId)
        {
            return _contactDal.GetList(b => b.ID == contactId).ToList();
        }

        public void Add(Contact contact)
        {
            //business code
            _contactDal.Add(contact);
        }

        public void Delete(Contact contact)
        {
            _contactDal.Delete(contact);
        }

        public void Update(Contact contact)
        {
            _contactDal.Update(contact);
        }


    }
}
