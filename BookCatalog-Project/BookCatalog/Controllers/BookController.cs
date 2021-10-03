using BookCatalog.Models;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private IBookService _bookService;
        public ILanguageService _languageService;
        public IPaperTypeService _paperTypeService;
        public IBookPublisherService _bookPublisherService;
        public IAuthorService _authorService;
        public IBookCategoryService _bookCategoryService;
        public IBookTypeService _bookTypeService;
        public ITranslatorService _translatorService;
        private IWebHostEnvironment _hostEnviroment;

        public BookController(IBookService bookService, ILanguageService languageService, IPaperTypeService paperTypeService, IBookPublisherService bookPublisherService, IAuthorService authorService, IBookCategoryService bookCategoryService, IBookTypeService bookTypeService, ITranslatorService translatorService, IWebHostEnvironment hostEnviroment)
        {
            _bookService = bookService;
            _languageService = languageService;
            _paperTypeService = paperTypeService;
            _bookPublisherService = bookPublisherService;
            _authorService = authorService;
            _bookCategoryService = bookCategoryService;
            _bookTypeService = bookTypeService;
            _translatorService = translatorService;
            _hostEnviroment = hostEnviroment;
        }


        public IActionResult List(string stringCategory, string stringType, string stringPublisher, string language, string stringName, int page = 1)
        {
            if (!string.IsNullOrEmpty(stringCategory) || !string.IsNullOrEmpty(stringType) || !string.IsNullOrEmpty(stringPublisher) || !string.IsNullOrEmpty(language) || !string.IsNullOrEmpty(stringName))
            {
                var SeFi = _bookService.SearchFilter(stringCategory, stringType, stringPublisher, language, stringName);
                return View(SeFi.ToPagedList(page, 10));    
            }
            var model = _bookService.GetListWithBookCategories().ToList();

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
            List<SelectListItem> authorValues = (from x in _authorService.GetAll().ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.ID.ToString()
                                                    }).ToList();
            ViewBag.v4 = authorValues;

            List<SelectListItem> categoryValues = (from x in _bookCategoryService.GetAll().ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.ID.ToString()
                                                 }).ToList();
            ViewBag.v5 = categoryValues;

            List<SelectListItem> typeValues = (from x in _bookTypeService.GetAll().ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.ID.ToString()
                                                   }).ToList();
            ViewBag.v6 = typeValues;

            List<SelectListItem> translatorValues = (from x in _translatorService.GetAll().ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.ID.ToString()
                                               }).ToList();
            ViewBag.v7 = translatorValues;


            return View();

        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            if (book.ID == 0)
            {
                var dosyayolu = Path.Combine(_hostEnviroment.WebRootPath, "images");
                _bookService.Add(book, dosyayolu);
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
            var obj = _bookService.GetByIdCategories(id);
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
            var obj = _bookService.GetByIdCategories(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            var obj = _bookService.GetByIdCategories(id);
            _bookService.Delete(obj);
            return RedirectToAction("List");
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var bookItems = _bookService.GetByIdCategories(id);
            if (bookItems == null)
            {
                return RedirectToAction("List");
            }
            return View(bookItems);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            var model = _bookService.GetByIdCategories(book.ID);
            model.ID = book.ID;
            model.Name = book.Name;
            model.ISBN = book.ISBN;
            model.LanguageID = book.LanguageID;
            model.PagesOfNumber = book.PagesOfNumber;
            model.PaperTypeID = book.PaperTypeID;
            model.Price = book.Price;
            model.Size = book.Size;
            model.TranslatorID = book.TranslatorID;
            model.AmountOfStock = book.AmountOfStock;
            model.AuthorID = book.AuthorID;
            model.Blurb = book.Blurb;
            model.BookCategoryID = book.BookCategoryID;
            model.BookPublisherID = book.BookPublisherID;
            model.BookTypeID = book.BookTypeID;
            _bookService.Update(model);
            return RedirectToAction("List");

        }

        
        [HttpGet]
        public IActionResult InvokeAuthor(int id, int page = 1)
        {
            var values = _bookService.GetBookListByAuthor(id);
            return View("authorBookList", values.ToPagedList(page, 5));
        }

        [HttpGet]
        public IActionResult InvokeTranslator(int id, int page = 1)
        {
            var values = _bookService.GetBookListByAuthor(id);
            return View("TranslatorBookList", values.ToPagedList(page, 5));
        }

    }
}
