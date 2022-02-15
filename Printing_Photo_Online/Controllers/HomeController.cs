﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Printing_Photo_Online;

namespace Printing_Photo_Online.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home

        Digital_Photo_PrintEntities db = new Digital_Photo_PrintEntities();




        //==============================================================
        //              INDEX
        //==============================================================
        public ActionResult Index()
        {
            ViewBag.let = 3;
            ViewBag.reg = "555";

            var user = db.users.ToList();
            return View(user);
        }




        //==============================================================
        //              REGISTER
        //==============================================================
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(FormCollection fc, HttpPostedFileBase image)
        {
            user data = new user();

            var eemail = Request.Form["email"];
            var epass = Request.Form["pass"];
            var mylogin = db.users.FirstOrDefault(a => a.Email == eemail && a.Pass == epass);

            if (mylogin == null)
            {
                if (image != null)
                {
                    var filename = Path.GetFileNameWithoutExtension(image.FileName);
                    var exten = Path.GetExtension(image.FileName);
                    Random rnd = new Random();

                    var myimg = filename + rnd.Next() + exten;

                    image.SaveAs(@"D:\E-Project\2nd_Sem_E-Project 2022\Printing_Photo_Online\profile_img\" + myimg);

                    data.First_Name = Request.Form["firstname"];
                    data.Last_Name = Request.Form["lastname"];
                    data.Email = Request.Form["email"];
                    data.Pass = Request.Form["pass"];
                    data.Date_Of_Birth = Request.Form["birth"];
                    data.Gender = Request.Form["gender"];
                    data.Phone = Request.Form["phone"];
                    data.User_Profile = myimg;
                    data.User_Type = 1;
                    

                    db.users.Add(data);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Account");
                }
                else if (image == null)
                {
                    ViewBag.error = "Please Fill Everything";
                    return View();
                }
            }
            else
            {
                ViewBag.error = "Email Already Exists";
                return View();
            }
            return View();
        }




        //==============================================================
        //              PROFILE
        //==============================================================

        public ActionResult Profile(int id)
        {
            id = (int)Session["id"];

            if (Session["name"] != null)
            {
                ViewBag.USERS = db.users.FirstOrDefault(u => u.id == id);
                ViewBag.ORDERS = db.orders.FirstOrDefault(o => o.UserId == id);
                ViewBag.PHOTO = db.Photographs.FirstOrDefault(p => p.UserId == id);
                ViewBag.CAT = db.categories;
                ViewBag.PRICE = db.Price_Info;

                user daat1 = new user();

                var data2 = "llll";
                var data3 = "lkkkk";

                return View(data1, data2, data3);                
            }
            else if (Session["name"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();

        }



    }
}