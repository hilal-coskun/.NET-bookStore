using BookCatalog.Models;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace BookStore.Controllers
{
    public class ContactController : Controller
    {
        private IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult List(string searchName, string searchPhone, string searchEmail, int page = 1)
        {
            if(!string.IsNullOrEmpty(searchName) || !string.IsNullOrEmpty(searchPhone) || !string.IsNullOrEmpty(searchEmail))
            {
                var seFi = _contactService.SearchFilter(searchName, searchPhone, searchEmail);
                return View(seFi.ToPagedList(page, 10));
            }
            var model = _contactService.GetAll().ToList();

            return View(model.ToPagedList(page, 5));
        }
        
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Contact contact)
        {
            _contactService.Add(contact);
            return RedirectToAction("List");
        }



        [HttpGet]
        public IActionResult Detail(int id)
        {
            var obj = _contactService.GetById(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Detail(Contact contact)
        {
            _contactService.Update(contact);
            return RedirectToAction("List");
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var contactItem = _contactService.GetById(id);
            if (contactItem == null)
            {
                return RedirectToAction("List");
            }
            return View(contactItem);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            var model = _contactService.GetById(contact.ID);
            model.ID = contact.ID;
            model.Name = contact.Name;
            model.Title = contact.Title;
            model.Mobile = contact.Mobile;
            model.Email = contact.Email;
            _contactService.Update(model);
            return RedirectToAction("List");

        }


        public IActionResult Delete(int id, Contact contact)
        {
            _contactService.Delete(contact);
            return RedirectToAction("List");
        }
    }
}
