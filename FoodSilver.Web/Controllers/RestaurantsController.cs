using FoodSilver.Data.Models;
using FoodSilver.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodSilver.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData db;

        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;
        }

        // GET: Restaurants
        [HttpGet]
        public ActionResult Index()
        {
            var model = db.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restuarant)
        {
            // ModelState is a collection inherit from controller and it's job to track model binding and then the html validation helper will work
            //ModelState["Name"].Value // the value related to the field
            //ModelState["Name"].Errors // error related to the field type
            // the validation helpers use this props

            // 1 way to do this, this is what happen behined the scene
            // 2 way is to use data annotation
            //if (String.IsNullOrEmpty(restuarant.Name))
            //{
            //    ModelState.AddModelError(nameof(restuarant.Name), "The name is required");
            //}

            if (ModelState.IsValid)
            {
                db.Add(restuarant);

                // RedirectToAction("Details", ROUTE OBJECT is information to be passed in request like query string or ...)
                return RedirectToAction("Details", new { id = restuarant.Id }); // here after adding it will see the id value
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Update(restaurant);

                TempData["Message"] = "You have saved the restaurant !";

                return RedirectToAction("Details", new { id = restaurant.Id });
            }

            return View(restaurant);
        }

        // we dont want to modify any data using get req so will ask for confirm here and if confirmed will send a post req
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);

            if (model == null)
            {
                return View("NotFound");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]        
        public ActionResult Delete(int id, FormCollection formCollection) // we use FormCollection cuz we have two methods with the same signiture, form collection contain form vlue as key-value pairs, we will not use it but mvc will generate it
        //public ActionResult Delete(Restaurant restaurant)
        {
            db.Delete(id);

            return RedirectToAction("Index");
        }
    }
}