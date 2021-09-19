
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

namespace BookCatalog.Controllers
{
    public class AuthorController : Controller
    {
        private IAuthorService _authorService;
        private IContactService _contactService;

        public AuthorController(IAuthorService authorService, IContactService contactService)
        {
            _authorService = authorService;
            _contactService = contactService;
        }
        
        public IActionResult List(int page=1)
        {
            var model = _authorService.GetAll().ToList();
            
            return View(model.ToPagedList(page, 5));
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<SelectListItem> contactItems = (from x in _contactService.GetAll().ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.ID.ToString()
                                                   }).ToList();
            ViewBag.v1 = contactItems;

            return View();
        }

        [HttpPost]
        public IActionResult Add(Author author )
        {
            if (author.ID == 0)
            {
                _authorService.Add(author);
            }
            else
            {
                _authorService.Update(author);
            }
            return RedirectToAction("List");
        }

        

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var obj = _authorService.GetById(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Detail(Author author)
        {
            _authorService.Update(author);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var obj = _authorService.GetById(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            var obj = _authorService.GetById(id);
            _authorService.Delete(obj);
            return RedirectToAction("List");
        }

        public IActionResult edit(int? id)
        {
            Author author;
            if (id.HasValue)
            {
                author = _authorService.GetByID(id);
            }
            else
            {
                author = new Author();
            }
            return View(author);
        }
    }
}
