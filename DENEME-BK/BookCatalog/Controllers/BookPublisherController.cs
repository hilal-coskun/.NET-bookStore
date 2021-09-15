using BookCatalog.Models;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BookPublisherController : Controller
    {
        private IBookPublisherService _bookPublisherService;

        public BookPublisherController(IBookPublisherService bookPublisherService)
        {
            _bookPublisherService = bookPublisherService;
        }

        public IActionResult List()
        {
            var model = new BookPublisherListViewModel
            {
                BookPublisher = _bookPublisherService.GetAll()
            };
            return View(model);
        }
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
