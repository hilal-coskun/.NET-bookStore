using Business.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace BookCatalog.Controllers
{
    public class AccountController : Controller
    {
        IUserService _userService;
        private string code = null;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("id").HasValue)
            {
                return Redirect("/Home/Index");
            }
            return View();
        }
        
        
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var userItem = _userService.LoginProcess(username, password);

            if(userItem != null)
            {
                HttpContext.Session.SetInt32("id", userItem.Id);
                HttpContext.Session.SetString("fullname", userItem.Name + userItem.Surname);
                return Redirect("/Home/Index");
            }
            return Redirect("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/Account/Index");
        }

        public IActionResult SignUp()
        {
            if (HttpContext.Session.GetInt32("id").HasValue)
            {
                return Redirect("/Home/Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("SignUp");
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            _userService.Add(user);
            return Redirect("Index");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        public IActionResult SendCode(string email)
        {
            var user = _userService.SendCodeProcess(email);


            return View();
        }

        public string getCode()
        {
            if(code == null)
            {
                Random rand = new Random();
                code = "";
                for (int i = 0; i < 6; i++)
                {
                    char tmp = Convert.ToChar( rand.Next(48,58));
                    code += tmp;  
                }
            }
            return code;
        }

    }
}
