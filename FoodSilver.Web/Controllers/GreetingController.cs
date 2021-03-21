using FoodSilver.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodSilver.Web.Controllers
{
    public class GreetingController : Controller
    {
        // GET: Greeting
        public ActionResult Index()
        {
            var viewModel = new GreetingMessage();
            viewModel.Message = ConfigurationManager.AppSettings["message"];

            return View(viewModel);
        }
    }
}