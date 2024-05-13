using BoltFood.CoreModels;
using BoltFood.Data.Repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Data.Repositories.Implementations
{
    public class RestaurantRepository : GenericRepository<Restaurant>
    {
        //    private static List<Restaurant> _restaurants = new List<Restaurant>();
        //    public void Add(Restaurant restaurant)
        //    {
        //        _restaurants.Add(restaurant);
        //    }

        //    public void Delete(int id)
        //    {
        //        Restaurant restaurant = GetById(id);

        //        if (restaurant != null)
        //        {
        //            _restaurants.Remove(restaurant);
        //        }
        //    }

        //    public List<Restaurant> GetAll()
        //    {
        //        return _restaurants;
        //    }

        //    public Restaurant GetById(int id)
        //    {
        //        //foreach (var restaurant in _restaurants)
        //        //{
        //        //    if (restaurant.Id == id) return restaurant;
        //        //}

        //        // Find a restaurant with Id == id (similar to Array.find in JavaScript)
        //        Restaurant foundRestaurant = _restaurants.FirstOrDefault(r => r.Id == id);

        //        if(foundRestaurant != null)  return foundRestaurant; 
        //        else throw new Exception("Restaurant not found");
        //    }

        //    public void Update(int id, Restaurant restaurant)
        //    {
        //        Restaurant foundRestaurant = GetById(id);
        //        if (foundRestaurant != null)
        //        {
        //            //foundRestaurant = restaurant;
        //            //_restaurants[_restaurants.IndexOf(foundRestaurant)] = restaurant;

        //            foundRestaurant.Name = restaurant.Name;
        //            foundRestaurant.Address = restaurant.Address;
        //            foundRestaurant.Phone = restaurant.Phone;
        //            foundRestaurant.UpdatedAt = restaurant.UpdatedAt;

        //            //_restaurants[_restaurants.IndexOf(foundRestaurant)] = foundRestaurant;

        //        }

        //    }
        //}
    }
}
