using FoodSilver.Data.Models;
using FoodSilver.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodSilver.Web.Api
{
    public class RestaurantsController : ApiController
    {
        private readonly IRestaurantData db;

        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;
        }
        
        // by default the request come is Get req so the action is Get and the url has the controller name and the action is Get by default
        // we need a dependency resolver for web api
        public IEnumerable<Restaurant> Get()
        {
            var model = db.GetAll();

            return model;
        }
    }
}
