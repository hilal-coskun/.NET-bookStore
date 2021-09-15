using BookCatalog.Models;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class ContactController : Controller
    {
        private IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult List()
        {
            var model = new ContactListViewModel
            {
                Contact = _contactService.GetAll()
            };

            return View(model);
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

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}
