using BookCatalog.Models;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        
        public ViewResult Add()
        {
            return View();
        }

       
        public IActionResult List()
        {
            var model = new BookListViewModel
            {
                Book = _bookService.GetAll()
            };

            return View(model);
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
