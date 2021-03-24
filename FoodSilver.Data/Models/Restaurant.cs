using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSilver.Data.Models
{
    // add public modifier to use the class outside of the project
    // we add a folder named 'Model' as classification in terms of namespaces in c#

    // Restaurant is an Entity becuase it's represent the information that will be persisted into a db
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // to enforce a limited number of choices to user we use a 'enum' type
        public CuisineType Cuisine { get; set; }
    }
}
