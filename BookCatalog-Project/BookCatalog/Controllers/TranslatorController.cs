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
    public class TranslatorController : Controller
    {
        private ITranslatorService _translatorService;

        public TranslatorController(ITranslatorService translatorService)
        {
            _translatorService = translatorService;
        }

        public IActionResult List(int page = 1)
        {
            var model = _translatorService.GetAll().ToList();

            return View(model.ToPagedList(page, 5));
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Translator translator)
        {
            if (translator.ID == 0)
            {
                _translatorService.Add(translator);
            }
            else
            {
                _translatorService.Update(translator);
            }
            return RedirectToAction("List");
        }


        [HttpGet]
        public IActionResult Detail(int id)
        {
            var obj = _translatorService.GetById(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Detail(Translator translator)
        {
            _translatorService.Update(translator);
            return RedirectToAction("List");
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            var obj = _translatorService.GetById(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            var obj = _translatorService.GetById(id);
            _translatorService.Delete(obj);
            return RedirectToAction("List");
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
