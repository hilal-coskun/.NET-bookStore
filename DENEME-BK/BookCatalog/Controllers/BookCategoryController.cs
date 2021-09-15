using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using BookCatalog.Models;

namespace BookStore.Controllers
{
    public class BookCategoryController : Controller
    {
        private IBookCategoryService _bookCategoryService;

        public BookCategoryController(IBookCategoryService bookCategoryService)
        {
            _bookCategoryService = bookCategoryService;
        }

        
        public IActionResult List(int pg=1)
        {
            
            var model = new BookCategoryListViewModel
            {
                BookCategory = _bookCategoryService.GetAll()
            };

            const int pageSize = 10;
            if(pg < 1)
            {
                pg = 1;
            }
            int recsCount = model.BookCategory.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = model.BookCategory.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(BookCategory bookCategory)
        {
            _bookCategoryService.Add(bookCategory);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Detail(int bookCategoryId)
        {
            return View(_bookCategoryService.GetById(bookCategoryId));
        }

        [HttpPost]
        public IActionResult Detail(BookCategory bookCategory)
        {
            _bookCategoryService.Update(bookCategory);
            return RedirectToAction("List");
        }

        public IActionResult Delete(BookCategory bookCategoryId)
        {
            _bookCategoryService.Delete(bookCategoryId);
            return RedirectToAction("List");
        }

    }
}
