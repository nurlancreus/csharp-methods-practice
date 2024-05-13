using E_Commerce.Core.Models;
using E_Commerce.Data.Repositories.Implementations;
using E_Commerce.Data.Repositories.Interfaces;
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
        private readonly CustomerRepository _customerRepository = new CustomerRepository();
        public void Add()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Surname: ");
            string surname = Console.ReadLine();

            Console.Write("Addres: ");
            string address = Console.ReadLine();

            Console.Write("Phone: ");
            string phone = Console.ReadLine();

            _customerRepository.Add(new() { Name = name, Surname = surname, Address = address, Phone = phone, CreatedAt = DateTime.Now });
        }

        public void Delete()
        {
            Console.WriteLine("Enter Customer Id: ");

            try
            {
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    _customerRepository.Delete(id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void GetAll()
        {
            List<Customer> customers = _customerRepository.GetAll();
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.ToString());
            }
        }

        public void GetById()
        {
            Console.WriteLine("Enter Customer Id: ");

            try
            {
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    Customer? customer = _customerRepository.GetById(id);

                    if (customer != null)
                        Console.WriteLine(customer.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Update()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Surname: ");
            string surname = Console.ReadLine();

            Console.Write("Addres: ");
            string address = Console.ReadLine();

            Console.Write("Phone: ");
            string phone = Console.ReadLine();

            Console.WriteLine("Enter Customer Id: ");

            try
            {
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    Customer? customer = _customerRepository.GetById(id);

                    if (customer != null)
                    {
                        customer.Name = name;
                        customer.Surname = surname;
                        customer.Address = address;
                        customer.Phone = phone;
                        customer.UpdatedAt = DateTime.Now;

                        _customerRepository.Update(customer);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
