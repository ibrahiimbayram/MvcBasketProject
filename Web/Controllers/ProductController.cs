using Business.Services;
using Entity.Tables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductServices _productServices;

        public ProductController(ProductServices productServices)
        {
            _productServices = productServices;
        }


        // GET: Product
        public ActionResult Index()
        {
            var user = Session["user"];
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }
                
        }
        [HttpPost]
        public ActionResult Index(Products products, System.Web.HttpPostedFileBase photo)
        {
            var user = Session["user"];
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                string resimAd = Path.GetFileName(photo.FileName);
                var yuklenecekyer = Path.Combine(Server.MapPath("~/Resimler"), resimAd);
                string resimyol = "~/Resimler/" + resimAd;
                photo.SaveAs(yuklenecekyer);

                products.ProductPicture = resimyol;

                _productServices.Add(products);


                return RedirectToAction("Index","Home");
            }
        }
    }
}