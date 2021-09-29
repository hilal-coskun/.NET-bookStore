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
    public class BookPublisherController : Controller
    {
        private IBookPublisherService _bookPublisherService;

        public BookPublisherController(IBookPublisherService bookPublisherService)
        {
            _bookPublisherService = bookPublisherService;
        }

        public IActionResult List(int page = 1)
        {
            var model = _bookPublisherService.GetAll().ToList();

            return View(model.ToPagedList(page, 5));
        }


        [HttpGet]
        public IActionResult Add()
        {
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
            var obj = _bookPublisherService.GetById(id);
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
            var obj = _bookPublisherService.GetById(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            var obj = _bookPublisherService.GetById(id);
            _bookPublisherService.Delete(obj);
            return RedirectToAction("List");
        }


        public IActionResult Edit()
        {
            return View();
        }
    }
}
