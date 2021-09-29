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
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        private IOrderStatusService _orderStatusService;
        private IContactService _contactService;

        public OrderController(IOrderService orderService, IOrderStatusService orderStatusService, IContactService contactService)
        {
            _orderService = orderService;
            _orderStatusService = orderStatusService;
            _contactService = contactService;
        }


        [HttpGet]
        public IActionResult Add()
        {
            List<SelectListItem> orderStatusItem = (from x in _orderStatusService.GetAll().ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.ID.ToString()
                                                 }).ToList();
            ViewBag.v1 = orderStatusItem;

            List<SelectListItem> contactItems = (from x in _contactService.GetAll().ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.ID.ToString()
                                                 }).ToList();
            ViewBag.v2 = contactItems;

            return View();
        }

        [HttpPost]
        public IActionResult Add(Order order)
        {
            if (order.ID == 0)
            {
                _orderService.Add(order);
            }
            else
            {
                _orderService.Update(order);
            }
            return RedirectToAction("List");
        }



        public IActionResult List(int page = 1)
        {
            var model = _orderService.GetAll().ToList();

            return View(model.ToPagedList(page, 5));
        }


        [HttpGet]
        public IActionResult Detail(int id)
        {
            var obj = _orderService.GetById(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Detail(Order order)
        {
            _orderService.Update(order);
            return RedirectToAction("List");
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            var obj = _orderService.GetById(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            var obj = _orderService.GetById(id);
            _orderService.Delete(obj);
            return RedirectToAction("List");
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
