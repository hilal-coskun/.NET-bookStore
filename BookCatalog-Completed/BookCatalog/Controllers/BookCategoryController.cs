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
using BookCatalog.Filter;
using Microsoft.AspNetCore.Authorization;

namespace BookStore.Controllers
{
    [UserFilter]
    public class BookCategoryController : Controller
    {
        private IBookCategoryService _bookCategoryService;

        public BookCategoryController(IBookCategoryService bookCategoryService)
        {
            _bookCategoryService = bookCategoryService;
        }

        
        public IActionResult List(string searchString,int page = 1)
        {
            
            if (!string.IsNullOrEmpty(searchString))
            {
                var seFi = _bookCategoryService.SearchFilter(searchString);
                return View(seFi.ToPagedList(page, 10));
            }
            var model = _bookCategoryService.GetAll().ToList();

            return View(model.ToPagedList(page, 5));
        }


        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _bookCategoryService.GetById(id);
            if(category == null)
            {
                return RedirectToAction("List", "BookCategory");
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(BookCategory bookCategory)
        {
            var model = _bookCategoryService.GetById(bookCategory.ID);
            model.ID = bookCategory.ID;
            model.Name = bookCategory.Name;
            model.BookType = bookCategory.BookType;
            _bookCategoryService.Update(model);
            return RedirectToAction("List");
            
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
            try
            {
                _bookCategoryService.Update(bookCategory);
                return RedirectToAction("List");
            }
            catch (Exception)
            {
                return View("ErrorView");
                throw;
            }

            
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
            try
            {
                obj = _bookCategoryService.GetById(id);
                _bookCategoryService.Delete(obj);
                return RedirectToAction("List");
            }
            catch (Exception)
            {
                ViewBag.ErrorTitle = $"{obj.Name} rolü kullanılmaktadır.";
                ViewBag.ErrorMessage = $"{obj.Name} kitap kategorisine ait kitap türü olduğu için kategori silinemez. Bu kategoriyi silmek istiyorsanız, lütfen kitap türlerinden bu kategoriyi kaldırın ve ardından silmeyi tekrar deneyin.";
                return View("ErrorView");
                throw;
            }
        }

    }
}
