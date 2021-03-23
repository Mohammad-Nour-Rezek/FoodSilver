using FoodSilver.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodSilver.Web.Controllers
{
    public class HomeController : Controller
    {
        IRestaurantData db;

        public HomeController(IRestaurantData restaurantData)
        {
            this.db = restaurantData;
        }

        public ActionResult Index()
        {
            var model = db.GetAll();

            return View(model);
        }

        public ActionResult About(string name)
        {
            ViewBag.Message = "Your application description page.";

            // handel a query string, tell me if there is a value for query string named 'name'
            // but we dont need to access like this we can get its value througth the parameter About(string name), mvc will look to query string
            //var name = HttpContext.Request.QueryString["name"];

            // string null-collation operator if the value come null 'no value'
            // https://localhost:44373/Home/About?name=nour
            // https://localhost:44373/Home/About?name=<script>alert("hi!");</script> , will return an error, and even if my app accept tags Razor view will display it as ienrt text, mvc has built-in protection agints XSS 'cross-site scripting'
            ViewBag.name = name ?? "no name";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}