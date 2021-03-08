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
            var user = Session["user"];
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                basket.UserName = Session["user"].ToString();
                basket.Order = "NotCompleted";

                _userBasket.Add(basket);

                return RedirectToAction("Index", "Home");
            }
      
        }


        public ActionResult List(string user)
        {
            var usersesion = Session["user"];
            if (usersesion == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {

                ViewBag.language = TempData["Languageliste"];
                string username = Session["user"].ToString();

                var userbasketlist= _userBasket.List(username);
                ViewBag.userbasket = userbasketlist;

                if (userbasketlist.Count != 0)
                {
                    ViewBag.quantity = _userBasket.GetQuantity(username);
                }
                else
                {
                    ViewBag.quantity = 0;
                }
            }

            return View();
        }


        public ActionResult GetLanguage(string id)
        {
            var usersesion = Session["user"];
            if (usersesion == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var name = _languageServices.GetLanguages(id);
                Session["languageNameMyBaket"] = name.MyBasket;



                TempData["Languageliste"] = _languageServices.GetLanguages(id);

                return RedirectToAction("List");
            }
        
        }

        public ActionResult LogOut(string id)
        {
            string username = Session["user"].ToString();
            Session.Remove(username);

            return RedirectToAction("Index","Login");
        }


        public ActionResult Order(int id)
        {
            var usersesion = Session["user"];
            if (usersesion == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                string username = Session["user"].ToString();

                _userBasket.OrderCompleted(username, id);

                return RedirectToAction("List");
            }
        }

        public ActionResult ComletedList(string user)
        {
            var usersesion = Session["user"];
            if (usersesion == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.language = TempData["Languageorder"];
                string username = Session["user"].ToString();
                ViewBag.userbasket = _userBasket.GetListOrderCompleted(username);

                return View();
            }
        }


        public ActionResult GetLanguageOrder(string id)
        {
            var usersesion = Session["user"];
            if (usersesion == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
         

                var name = _languageServices.GetLanguages(id);
                Session["languageNameComlpleted"] = name.OrderCompleted;


                TempData["Languageorder"] = _languageServices.GetLanguages(id);

                return RedirectToAction("ComletedList");
            }
        }


        public ActionResult Delete(int id)
        {
            var usersesion = Session["user"];
            if (usersesion == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                _userBasket.Delete(id);



                return RedirectToAction("List");
            }
        }


        public ActionResult Edit(UserBasket userBasket)
        {
            var usersesion = Session["user"];
            if (usersesion == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                _userBasket.Update(userBasket);


                return RedirectToAction("List");
            }
        }


    }
}