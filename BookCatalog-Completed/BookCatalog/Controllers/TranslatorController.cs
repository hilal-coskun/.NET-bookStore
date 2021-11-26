using BookCatalog.Filter;
using BookCatalog.Models;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace BookStore.Controllers
{
    [UserFilter]
    public class TranslatorController : Controller
    {
        private ITranslatorService _translatorService;
        private IWebHostEnvironment _hostEnviroment;

        
        public TranslatorController(ITranslatorService translatorService, IWebHostEnvironment hostEnviroment)
        {
            _translatorService = translatorService;
            _hostEnviroment = hostEnviroment;
        }

        
        public IActionResult List(string searchString, int page = 1)
        {

            if (!string.IsNullOrEmpty(searchString))
            {
                var seFi= _translatorService.SearchFilter(searchString);
                return View(seFi.ToPagedList(page, 10));
            }
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
                var uzanti = Path.GetExtension(translator.LogoFile.FileName);
                var yeniresim = Guid.NewGuid() + uzanti;
                var yer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/" + yeniresim);

                var stream = new FileStream(yer, FileMode.Create);
                translator.LogoFile.CopyTo(stream);

                translator.Logo = yeniresim;
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
            try
            {
                _translatorService.Update(translator);
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
            var obj = _translatorService.GetById(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            var obj = _translatorService.GetById(id);
            try
            {
                obj = _translatorService.GetById(id);
                _translatorService.Delete(obj);
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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var translatorItem = _translatorService.GetById(id);
            if(translatorItem == null)
            {
                return RedirectToAction("List");
            }

            return View(translatorItem);
        }

        [HttpPost]
        public IActionResult Edit(Translator translator)
        {
            var model = _translatorService.GetById(translator.ID);

            if (translator.LogoFile != null)
            {
                var uzanti = Path.GetExtension(translator.LogoFile.FileName);
                var yeniresim = Guid.NewGuid() + uzanti;
                var yer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/" + yeniresim);

                var stream = new FileStream(yer, FileMode.Create);
                translator.LogoFile.CopyTo(stream);

                model.Logo = yeniresim;
            }


            model.ID = translator.ID;
            model.About = translator.About;
            model.Name = translator.Name;
            _translatorService.Update(model);
            return RedirectToAction("List");

        }
    }
}
