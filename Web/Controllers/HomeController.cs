using Business.Services;
using DataAcces.Interfaces;
using Entity.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly LoginServices _loginServices;
        private readonly ProductServices _productServices;
        private readonly LanguageServices _languageServices;

        public HomeController(LoginServices loginServices, ProductServices productServices, LanguageServices languageServices)
        {
            _loginServices = loginServices;
            _productServices = productServices;
            _languageServices = languageServices;

        }

        public ActionResult Index()
        {

            var user = Session["user"];
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var usernames = _loginServices.GetFindUser(user.ToString());
            if (user == usernames.UserName)
            {

                ViewBag.language = TempData["Language"];

                ViewBag.product = _productServices.GetProducts();

           


                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }

        public ActionResult GetLanguage(string id)
        {
            var user = Session["user"];
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var name = _languageServices.GetLanguages(id);
                Session["languageName"] = name.MyBasket;


                TempData["Language"] = _languageServices.GetLanguages(id);

                return RedirectToAction("Index");
            }
         
        }




    }
}