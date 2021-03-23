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
        // by default the request come is Get req so the action is Get and the url has the controller name and the action is Get by default
        public string Get()
        {
            return "Hello World!";
        }
    }
}
