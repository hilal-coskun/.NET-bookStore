using BookCatalog.Models;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.WebPages;
using X.PagedList;

namespace BookStore.Controllers
{
    public class BookTypeController : Controller
    {
        private IBookTypeService _bookTypeService;
        public IBookCategoryService _bookCategoryService;

        public BookTypeController(IBookTypeService bookTypeService, IBookCategoryService bookCategoryService)
        {
            _bookTypeService = bookTypeService;
            _bookCategoryService = bookCategoryService;
        }

        public IActionResult List(string searchcateories, string searchname, int page=1)
        {
            if (!string.IsNullOrEmpty(searchcateories) || !string.IsNullOrEmpty(searchname)) 
            {
                var seFi = _bookTypeService.SearchFilter(searchcateories, searchname);
                return View(seFi.ToPagedList(page, 10));
            }
            var model = _bookTypeService.GetListWithBookCategories().ToList();

            return View(model.ToPagedList(page,5));
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<SelectListItem> categoryValues = (from x in _bookCategoryService.GetAll().ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.ID.ToString()
                                                   }).ToList();
            ViewBag.v1 = categoryValues;

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
            var obj = _bookTypeService.GetByIdCategories(id);
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
            var obj = _bookTypeService.GetByIdCategories(id);
            _bookTypeService.Delete(obj);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var type = _bookTypeService.GetByIdCategories(id);
            if(type == null)
            {
                return RedirectToAction("List", "BookType");
            }
            return View(type);
        }

        [HttpPost]
        public IActionResult Edit(BookType b)
        {
            var x = _bookTypeService.GetByIdCategories(b.ID);
            x.ID = b.ID;
            x.Name = b.Name;
            x.BookCategoryID = b.BookCategoryID;
            _bookTypeService.Update(x);
            return RedirectToAction("List");
        }
    }
}
