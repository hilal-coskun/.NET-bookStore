
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
        
        public IActionResult List(string searchString, int page=1)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                var seFi = _authorService.SearchFilter(searchString);
                return View(seFi.ToPagedList(page, 10));
            }

            var model = _authorService.GetAll().ToList();
            
            return View(model.ToPagedList(page, 5));
        }

        [HttpGet]
        public IActionResult Add()
        {
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
        /*
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
        }*/

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var authorItem = _authorService.GetById(id);
            if (authorItem == null)
            {
                return RedirectToAction("List", "BookCategory");
            }
            return View(authorItem);
        }

        [HttpPost]
        public IActionResult Edit(Author author)
        {
            var model = _authorService.GetById(author.ID);
            model.ID = author.ID;
            model.Name = author.Name;
            model.About = author.About;
            _authorService.Update(model);
            return RedirectToAction("List");

        }
    }
}
