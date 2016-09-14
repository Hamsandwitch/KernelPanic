﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ShoppingList_Team2_Master.Controllers
{
    public class HomeController : Controller
    {
        //GET 
        public ActionResult Index()
        {
            if(Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "ListModels");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

    }
}