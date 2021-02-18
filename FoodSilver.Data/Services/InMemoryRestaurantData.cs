﻿using FoodSilver.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace FoodSilver.Data.Services
{
    // in memory means without using database 
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Nour's Pizza", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 2, Name = "Shawerma", Cuisine = CuisineType.Arabian },
                new Restaurant { Id = 3, Name = "Masala Rise", Cuisine = CuisineType.Indian }
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            // using Linq ns
            return restaurants.OrderBy(r => r.Name);
        }
    }
}
