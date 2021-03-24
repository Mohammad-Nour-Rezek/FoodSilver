using FoodSilver.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSilver.Data.Services
{
    // 1) public to use out side 2) CRUD: first just a list
    public interface IRestaurantData
    {
        // need import cuz in different namespaces
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        void Add(Restaurant restaurant);
        void Update(Restaurant restaurant);
    }
}
