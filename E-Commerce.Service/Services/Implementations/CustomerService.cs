using E_Commerce.Core.Models;
using E_Commerce.Data.Repositories.Implementations;
using E_Commerce.Data.Repositories.Interfaces;
using E_Commerce.Service.Helpers;
using E_Commerce.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository = new CustomerRepository();
        public void Add()
        {
            (string name, string surname, string address, string phone) = GetFields();

            Customer customer = new() { Name = name, Surname = surname, Address = address, Phone = phone, CreatedAt = DateTime.Now };

            _customerRepository.Add(customer);
        }

        public void Delete()
        {

            int id = (int)Utilities.ReadNumber("Enter Customer Id");
            try
            {
                _customerRepository.Delete(id);
            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }

        }

        public void GetAll()
        {
            List<Customer> customers = _customerRepository.GetAll();
            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
        }

        public void GetById()
        {
            int id = (int)Utilities.ReadNumber("Enter Customer Id");
            try
            {
                Customer? customer = _customerRepository.GetById(id);

                if (customer is not null)
                    Console.WriteLine(customer);

            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }
        }

        public void Update()
        {
            int id = (int)Utilities.ReadNumber("Enter Customer Id");
            try
            {
                Customer? customer = _customerRepository.GetById(id);

                (string name, string surname, string address, string phone) = GetFields();

                if (customer is not null)
                {
                    customer.Name = name;
                    customer.Surname = surname;
                    customer.Address = address;
                    customer.Phone = phone;
                    customer.UpdatedAt = DateTime.Now;

                    _customerRepository.Update(customer);
                }

            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }

        }

        private static (string name, string surname, string address, string phone) GetFields()
        {
            string name = Utilities.ReadString("Enter Name");
            string surname = Utilities.ReadString("Surname");
            string address = Utilities.ReadString("Address");
            string phone = Utilities.ReadString("Phone");

            return (name, surname, address, phone);
        }
    }
}
