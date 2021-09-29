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
    public class BookTypeController : Controller
    {
        private IBookTypeService _bookTypeService;

        public BookTypeController(IBookTypeService bookTypeService)
        {
            _bookTypeService = bookTypeService;
        }



        public IActionResult List(int page=1)
        {

            var model = _bookTypeService.GetAll().ToList();

            return View(model.ToPagedList(page,5));
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(BookType bookType)
        {
            _bookTypeService.Add(bookType);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var obj = _bookTypeService.GetById(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Detail(BookType bookType)
        {
            _bookTypeService.Update(bookType);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var obj = _bookTypeService.GetById(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            var obj = _bookTypeService.GetById(id);
            _bookTypeService.Delete(obj);
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult Edit(BookType b)
        {
            var x = _bookTypeService.GetById(b.ID);
            x.BookCategoryID = b.BookCategoryID;
            x.Name = b.Name;
            _bookTypeService.Update(x);
            return RedirectToAction("Edit");
        }
    }
}
