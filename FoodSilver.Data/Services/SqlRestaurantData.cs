using FoodSilver.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSilver.Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly FoodSilverDbContext db;

        public SqlRestaurantData(FoodSilverDbContext db)
        {
            this.db = db;
        }
        
        public void Add(Restaurant restaurant)
        {
            db.Restaurants.Add(restaurant); // unit of work design patteren: means at this point nothing added to the db, unit of work records what changes want to apply to the db
            db.SaveChanges(); // here when we commit changes happens, DbContext use this statement to construct insert statement
        }

        public void Delete(int id)
        {
            var restaurant = db.Restaurants.Find(id); //Find will get a record based on PK given with the best performance (it eill look at the cach version first) or return null
            
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
        }

        public Restaurant Get(int id)
        {
            return db.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            //return db.Restaurants; // here we return the DbSet and it's implement IEnumerable
            //return db.Restaurants.OrderBy(r => r.Name);

            // or use linq syntax:
            return from r in db.Restaurants
                   orderby r.Name
                   select r;

              
        }

        public void Update(Restaurant restaurant)
        {
            // EF will know when any edit on object prop happen and whan do SaveChanges it will generate update statement and push a db transaction
            // here the last user hit save button will be the last person will do the update
            //var r = Get(restaurant.Id);
            //r.Name = restaurant.Name;
            //r.Cuisine = restaurant.Cuisine;

            // the best approach if i have multiple user in the app (that maybe updating the same restaurant)
            // so we will implement a feature 'Optimistic Concurrency'
            // see the restaurant change since the user read the data (prevent one user overwrite another user changes)
            var entry = db.Entry(restaurant); // object to be track by the context
            entry.State = EntityState.Modified;

            db.SaveChanges();
        }
    }
}
