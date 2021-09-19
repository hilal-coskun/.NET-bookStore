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
    public class BookController : Controller
    {
        private IBookService _bookService;
        private ILanguageService _languageService;
        private IPaperTypeService _paperTypeService;

        public BookController(IBookService bookService, ILanguageService languageService, IPaperTypeService paperTypeService)
        {
            _bookService = bookService;
            _languageService = languageService;
            _paperTypeService = paperTypeService;
        }


        public IActionResult List(int page = 1)
        {
            var model = _bookService.GetAll().ToList();

            return View(model.ToPagedList(page, 5));
        }

        

        [HttpGet]
        public ViewResult Add()
        {
            List<SelectListItem> languageValues = (from x in _languageService.GetAll().ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.ID.ToString()
                                                   }).ToList();
            ViewBag.v1 = languageValues;

            List<SelectListItem> paperTypeItems = (from x in _paperTypeService.GetAll().ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.ID.ToString()
                                                   }).ToList();
            ViewBag.v2 = paperTypeItems;
            return View();
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            if (book.ID == 0)
            {
                _bookService.Add(book);
            }
            else
            {
                _bookService.Update(book);
            }
            return RedirectToAction("List");
        }


        [HttpGet]
        public IActionResult Detail(int id)
        {
            var obj = _bookService.GetById(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Detail(Book book)
        {
            _bookService.Update(book);
            return RedirectToAction("List");
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            var obj = _bookService.GetById(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            var obj = _bookService.GetById(id);
            _bookService.Delete(obj);
            return RedirectToAction("List");
        }



        public IActionResult Edit()
        {
            return View();
        }
    }
}
