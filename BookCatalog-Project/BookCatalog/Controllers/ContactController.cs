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

        public IActionResult List(int page = 1)
        {
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

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete(int id, Contact contact)
        {
            _contactService.Delete(contact);
            return RedirectToAction("List");
        }
    }
}
