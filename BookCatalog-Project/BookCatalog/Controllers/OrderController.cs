using BookCatalog.Filter;
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
    [UserFilter]
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        private IContactService _contactService;
        private IPaymentChannelService _paymentChannelService;
        private IBookService _bookService;
        private IOrderStatusService _orderStatusService;

        public OrderController(IOrderService orderService,  IContactService contactService, IPaymentChannelService paymentChannelService, IBookService bookService, IOrderStatusService orderStatusService)
        {
            _orderService = orderService;
            _contactService = contactService;
            _paymentChannelService = paymentChannelService;
            _bookService = bookService;
            _orderStatusService = orderStatusService;
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
            ViewBag.v2 = contactItems;

            List<SelectListItem> paymentChannelValues = (from x in _paymentChannelService.GetAll().ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.ID.ToString()
                                                 }).ToList();
            ViewBag.v3 = paymentChannelValues;

            List<SelectListItem> bookValues = (from x in _bookService.GetAll().ToList()
                                                         select new SelectListItem
                                                         {
                                                             Text = x.Name,
                                                             Value = x.ID.ToString()
                                                         }).ToList();
            ViewBag.v4 = bookValues;

            List<SelectListItem> orderStatussValues = (from x in _orderStatusService.GetAll().ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.ID.ToString()
                                               }).ToList();
            ViewBag.v5 = orderStatussValues;

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
            var model = _orderService.GetListWithItems().ToList();

            return View(model.ToPagedList(page, 5));
        }


        [HttpGet]
        public IActionResult Detail(int id)
        {
            var obj = _orderService.GetByIdCategories(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Detail(Order order)
        {
            _orderService.Update(order);
            return RedirectToAction("List");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _orderService.GetByIdCategories(id);
            if (category == null)
            {
                return RedirectToAction("List");
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Order order)
        {

            var model = _orderService.GetByIdCategories(order.ID);
            model.ID = order.ID;
            model.BookID = order.BookID;
            model.PaymentChannelID = order.PaymentChannelID;
            model.OrderStatusID = order.OrderStatusID;
            model.NumberOfBook = order.NumberOfBook;
            model.ContactID = order.ContactID;
            _orderService.Update(model);
            return RedirectToAction("List");

        }




        [HttpGet]
        public IActionResult Delete(int id)
        {
            var obj = _orderService.GetByIdCategories(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            var obj = _orderService.GetByIdCategories(id);
            _orderService.Delete(obj);
            return RedirectToAction("List");
        }

        
    }
}
