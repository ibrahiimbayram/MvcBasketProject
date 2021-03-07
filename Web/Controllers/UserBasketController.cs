using Business.Services;
using Entity.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class UserBasketController : Controller
    {
        private readonly UserBasketServices _userBasket;
        private readonly LanguageServices _languageServices;

        public UserBasketController(UserBasketServices userBasket, LanguageServices languageServices)
        {
            _userBasket = userBasket;
            _languageServices = languageServices;
        }
        // GET: MyBasket

        [HttpPost]
        public ActionResult Index(UserBasket basket)
        {
            //var products = _userBasket.GetById(id);

            //UserBasket basket = new UserBasket();
            //basket.ProductCode = products.ProductCode;
            //basket.ProductName = products.ProductName;
            //basket.ProductPicture = products.ProductPicture;
            //basket.Quantity = 1;
            //basket.UserName = Session["user"].ToString();
            //basket.Order = "Not Completed";

            _userBasket.Add(basket);

            return RedirectToAction("Index", "Home");
        }



        //public ActionResult Index(int id)
        //{
        //    var products = _userBasket.GetById(id);

        //    UserBasket basket = new UserBasket();
        //    basket.ProductCode = products.ProductCode;
        //    basket.ProductName = products.ProductName;
        //    basket.ProductPicture = products.ProductPicture;
        //    basket.Quantity =1;
        //    basket.UserName = Session["user"].ToString();
        //    basket.Order = "Not Completed";

        //    _userBasket.Add(basket);

        //    return RedirectToAction("Index","Home");
        //}


        public ActionResult List(string user)
        {

            ViewBag.language = TempData["Language"];
            string username= Session["user"].ToString();
            ViewBag.userbasket = _userBasket.List(username);

            ViewBag.quantity = _userBasket.GetQuantity(username);
            return View();
        }


        public ActionResult GetLanguage(string id)
        {

            var name = _languageServices.GetLanguages(id);
            Session["languageName"] = name.MyBasket;


            TempData["Language"] = _languageServices.GetLanguages(id);

            return RedirectToAction("List");
        }

        public ActionResult LogOut(string id)
        {
            string username = Session["user"].ToString();
            Session.Remove(username);

            return RedirectToAction("Index","Login");
        }


        public ActionResult Order(int id)
        {
            string username = Session["user"].ToString();

            _userBasket.OrderCompleted(username, id);

            return RedirectToAction("List");
        }

        public ActionResult ComletedList(string user)
        {

            ViewBag.language = TempData["Language"];
            string username = Session["user"].ToString();
            ViewBag.userbasket = _userBasket.GetListOrderCompleted(username);

            return View();
        }


        public ActionResult GetLanguageOrder(string id)
        {

            var name = _languageServices.GetLanguages(id);
            Session["languageName"] = name.MyBasket;


            TempData["Language"] = _languageServices.GetLanguages(id);

            return RedirectToAction("ComletedList");
        }


        public ActionResult Delete(int id)
        {

            _userBasket.Delete(id);



            return RedirectToAction("List");
        }


        public ActionResult Edit(int id)
        {



            return View();
        }


        [HttpPost]
        public ActionResult Edit(UserBasket userBasket)
        {



            return View();
        }
    }
}