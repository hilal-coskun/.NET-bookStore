using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using BookCatalog.Models;
using X.PagedList;

namespace BookStore.Controllers
{
    public class BookCategoryController : Controller
    {
        private IBookCategoryService _bookCategoryService;

        public BookCategoryController(IBookCategoryService bookCategoryService)
        {
            _bookCategoryService = bookCategoryService;
        }

        
        public IActionResult List(int page = 1)
        {

            var model = _bookCategoryService.GetAll().ToList();

            /*const int pageSize = 10;
            if(pg < 1) 
            {
                pg = 1;
            }
            int recsCount = model.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = model.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;*/

            return View(model.ToPagedList(page, 5));
        }

        
        public IActionResult edit(int? id)
        {
            BookCategory bookCategory;
            if (id.HasValue)
            {
                bookCategory = _bookCategoryService.GetByID(id);
            }
            else
            {
                bookCategory = new BookCategory();
            }
            return View(bookCategory);
        }



        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(BookCategory bookCategory)
        {
            if(bookCategory.ID == 0)
            {
                _bookCategoryService.Add(bookCategory);
            }
            else
            {
                _bookCategoryService.Update(bookCategory);
            }
            return RedirectToAction("List");
        }



        [HttpGet]
        public IActionResult Detail(int id)
        {
            var obj = _bookCategoryService.GetById(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Detail(BookCategory bookCategory)
        {
            _bookCategoryService.Update(bookCategory);
            return RedirectToAction("List");
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            var obj = _bookCategoryService.GetById(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            var obj = _bookCategoryService.GetById(id);
            _bookCategoryService.Delete(obj);
            return RedirectToAction("List");
        }


    }
}
