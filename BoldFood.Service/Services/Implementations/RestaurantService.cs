using BoltFood.CoreModels;
using BoltFood.Data.Repositories.Implementations;
using BoltFood.Service.Helpers.Extensions;
using BoltFood.Service.Helpers.Utilities;
using BoltFood.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Service.Services.Implementations
{
    public class RestaurantService : IRestaurantService
    {
        private readonly RestaurantRepository _repository = new RestaurantRepository();
        public void Add()
        {
            //Console.Write("Add Restaurant Name: ");
            //string name = Console.ReadLine();
            //Console.Write("Address: ");
            //string address = Console.ReadLine();
            //Console.Write("Phone: ");
            //string phone = Console.ReadLine();

            string name = "".ReadString($"Add Product Name: ");
            string address = "".ReadString("Address: ");
            string phone = "".ReadString("Phone: ");

            Restaurant restaurant = new Restaurant() { Name = name, Address = address, Phone = phone };
            _repository.Add(restaurant);
        }

        public void Delete()
        {

            try
            {
                int id = (int)((double)0).ReadNumber("Enter Restaurant id you want to delete: ");
                _repository.Delete(id);
            }
            catch (Exception ex)
            {
                Utilities.ExceptionConsole(ex.Message);
            }
        }

        public void GetAll()
        {

            List<Restaurant> restaurants = _repository.GetAll();

            foreach (Restaurant restaurant in restaurants)
            {
                Console.WriteLine(restaurant.ToString());
            }
        }

        public void GetById()
        {
            try
            {
                int id = (int)((double)0).ReadNumber("Enter Restaurant id you want to get: ");
                Restaurant restaurant = _repository.GetById(id);
                Console.WriteLine(restaurant.ToString());
            }
            catch (Exception ex)
            {
                Utilities.ExceptionConsole(ex.Message);
            }
        }

        public void Update()
        {
            try
            {
                int id = (int)((double)0).ReadNumber("Enter Restaurant id you want to update: ");

                if (_repository.GetById(id) != null)
                {

                    string name = "".ReadString("Add Restaurant Name: ");
                    string address = "".ReadString("Address: ");
                    string phone = "".ReadString("Phone: ");

                    //Restaurant restaurant = new Restaurant() { Name = name, Address = address, Phone = phone};

                    Restaurant findedRestaurant = _repository.GetById(id);

                    findedRestaurant.Name = name;
                    findedRestaurant.Address = address;
                    findedRestaurant.Phone = phone;

                    _repository.Update(id, findedRestaurant);

                }
                else throw new Exception("Restaurant not found");
            }
            catch (Exception ex)
            {
                Utilities.ExceptionConsole(ex.Message);
            }
        }
    }
}
