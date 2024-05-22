using E_Commerce.Core.Enums;
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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository = new OrderRepository();
        private readonly ICustomerRepository _customerRepository = new CustomerRepository();
        private readonly IOrderProductRepository _orderProductRepositoy = new OrderProductRepositoy();
        private readonly IProductRepository _productRepository = new ProductRepository();
        public void Add()
        {
            int id = (int)Utilities.ReadNumber("Enter customer Id: ");

            Customer? customer = _customerRepository.GetById(id);

            Order order = new Order()
            {
                Customer = customer,
                Status = (OrderStatus)5,
                CreatedAt = DateTime.Now,
            };

            bool isContinue = true;

            while (isContinue)
            {
                int productId = (int)Utilities.ReadNumber("Add product id you want to add to the order");
                Product? product = _productRepository.GetById(productId);
                if (product is not null)
                {
                    int count = (int)Utilities.ReadNumber("Enter the count");
                    if (count <= product.Stock)
                    {
                        OrderProduct orderProduct = new OrderProduct()
                        {
                            Product = product,
                            Count = count,
                            Order = order,
                            CreatedAt = DateTime.Now
                        };
                        order.OrderProducts.Add(orderProduct);
                        _orderProductRepositoy.Add(orderProduct);
                        product.Stock -= count;
                        product.UpdatedAt = DateTime.Now;
                        _productRepository.Update(product);
                    }
                }

                Console.WriteLine("Do you want to continue? (y/n)");
                char.TryParse(Console.ReadLine(), out char answer);

                if (answer != 'y')
                {
                    isContinue = false;
                }
            }

            _orderRepository.Add(order);
        }

        public void ChangeStatus()
        {
            int id = (int)Utilities.ReadNumber("Enter the id of the order you'd like to change status");
            Order? order = _orderRepository.GetById(id);

            if (order is not null)
            {
                Console.WriteLine("Order statuses:");
                foreach (OrderStatus status in Enum.GetValues(typeof(OrderStatus)))
                {
                    Console.WriteLine($"{(int)status}. {status}");
                }

                OrderStatus orderStatus;

                while (true)
                {

                    if (int.TryParse(Utilities.ReadNumber("Choose the status").ToString(), out int orderStatusNum) && Enum.IsDefined(typeof(OrderStatus), orderStatusNum))
                    {
                        orderStatus = (OrderStatus)orderStatusNum;
                        break;
                    }
                    else Logger.ExceptionConsole("You choose wrong status number");
                }

                order.Status = orderStatus;
                order.UpdatedAt = DateTime.Now;
                _orderRepository.Update(order);
            }
        }

        public void Delete()
        {
            int id = (int)Utilities.ReadNumber("Enter the id of the order you'd like to delete");

            Order? order = _orderRepository.GetById(id);

            if (order is not null)
            {
                foreach (OrderProduct orderProduct in order.OrderProducts)
                {
                    Product product = orderProduct.Product;
                    product.Stock += orderProduct.Count;
                    product.UpdatedAt = DateTime.Now;
                    _productRepository.Update(product);
                    _orderProductRepositoy.Delete(orderProduct.Id);
                }
            }
            _orderRepository.Delete(id);
        }

        public void GetAll()
        {
            int id = (int)Utilities.ReadNumber("Enter the id of the customer you'd like to get orders of");
            List<Order> customerOrders = _orderRepository.GetAll().Where(o => o.Customer.Id == id).ToList();

            foreach (Order customerOrder in customerOrders)
            {
                OrderDetails(customerOrder);
            }
        }

        public void GetById()
        {
            int id = (int)Utilities.ReadNumber("Enter the id of the order you'd like to get");
            Order? order = _orderRepository.GetById(id);

            if (order is not null)
            {
                OrderDetails(order);
            }
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        private void OrderDetails(Order order)
        {
            foreach (var orderProduct in order.OrderProducts)
            {
                Console.WriteLine(orderProduct.Product.Name + ": " +
                    orderProduct.Count + "\n Total Price: " +
                    orderProduct.Count + orderProduct.Product.Price);
            }

            double totalPrice = order.OrderProducts.Sum(op => op.Product.Price * op.Count);
            Console.WriteLine("Orders' total price: " + totalPrice);
        }
    }
}
