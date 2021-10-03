using BookCatalog.Models;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace BookStore.Controllers
{
    public class BookPublisherController : Controller
    {
        private IBookPublisherService _bookPublisherService;
        private IContactService _contactService;

        public BookPublisherController(IBookPublisherService bookPublisherService, IContactService contactService)
        {
            _bookPublisherService = bookPublisherService;
            _contactService = contactService;
        }

        public IActionResult List(string searchString, int page = 1)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                var seFi = _bookPublisherService.SearchFilter(searchString);
                return View(seFi.ToPagedList(page, 10));
            }
            var model = _bookPublisherService.GetListWithBookCategories().ToList();
            return View(model.ToPagedList(page, 5));
        }


        [HttpGet]
        public IActionResult Add()
        {
            List<SelectListItem> contactValues = (from x in _contactService.GetAll().ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.ID.ToString()
                                                 }).ToList();
            ViewBag.v1 = contactValues;

            return View();
        }

        [HttpPost]
        public IActionResult Add(BookPublisher bookPublisher)
        {
            if (bookPublisher.ID == 0)
            {
                _bookPublisherService.Add(bookPublisher);
            }
            else
            {
                _bookPublisherService.Update(bookPublisher);
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var obj = _bookPublisherService.GetByIdCategories(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Detail(BookPublisher bookPublisher)
        {
            _bookPublisherService.Update(bookPublisher);
            return RedirectToAction("List");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var obj = _bookPublisherService.GetByIdCategories(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            var obj = _bookPublisherService.GetByIdCategories(id);
            _bookPublisherService.Delete(obj);
            return RedirectToAction("List");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var type = _bookPublisherService.GetByIdCategories(id);
            if (type == null)
            {
                return RedirectToAction("List");
            }
            return View(type);
        }

        [HttpPost]
        public IActionResult Edit(BookPublisher b)
        {
            var x = _bookPublisherService.GetByIdCategories(b.ID);
            x.ID = b.ID;
            x.About = b.About;
            _bookPublisherService.Update(x);

            return RedirectToAction("List");
        }
    }
}
