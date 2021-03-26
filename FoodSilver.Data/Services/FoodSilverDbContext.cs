using FoodSilver.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSilver.Data.Services
{
    // we may have a single dbcontext or multiple if we want to classify the entities like: accounting, stores, ...
    // with DbContext we need a connection string to point the db
    public class FoodSilverDbContext : DbContext
    {
        // there is a table exist in db that can populate restuarants objects so when i query from that table i can map to restuarant object type
        // if i named this prop Resturants EF will assume there is table with that name in db
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
