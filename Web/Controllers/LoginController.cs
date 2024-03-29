﻿using AutoMapper;
using Business.Services;
using DataAcces.Interfaces;
using Entity.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.DTOS;

namespace Web.Controllers
{
    public class LoginController : Controller
    {

        private readonly LoginServices loginServices;

        public LoginController(LoginServices loginServices)
        {
            this.loginServices = loginServices;
       
        }
  
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        private class LoginUser
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        [HttpPost]
        public ActionResult Index(Users users)
        {
            
            var user=loginServices.Login(users);

            if (user != null)
            {

                Session.Add("User", user.UserName);


                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Kayıtlı hesabınız bulunmamaktadır.");
            }

            return View();
        }


        public ActionResult SignUp()
        {
         
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(Users signUpDto)
        {
            var findUser = loginServices.GetFindUser(signUpDto.UserName);

            if (findUser == null)
            {
                loginServices.SignUp(signUpDto);

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "UserName zaten kullanılıyor");
            }
            

            return View(signUpDto);
        }
    }
}