using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP_part2.Entities
{
    internal class Customer
    {
        private string? _id;
        private string? _name;
        private string? _surname;
        private string? _email;

        public Customer()
        {
            _id = GenerateId();
            Console.Write("Ad: ");
            string name = ReadStringNotEmpty();
            Name = name;

            Console.Write("Soyad: ");
            string surname = ReadStringNotEmpty();
            Surname = surname;

            Console.Write("Email: ");
            string email = ReadStringNotEmpty();
            Email = email;
        }

        public string Name
        {
            get => _name;
            set
            {

                if (string.IsNullOrWhiteSpace(value.Trim())) throw new ArgumentNullException("Name should not be empty");
                _name = value;
            }
        }

        public string Surname
        {
            get => _surname;

            set
            {

                if (string.IsNullOrWhiteSpace(value.Trim())) throw new ArgumentNullException("Surname should not be empty");
                _surname = value;
            }
        }

        public string Email
        {
            get => _email;

            set
            {
                if (!IsEmailValid(value.Trim())) throw new FormatException("Email is not in a valid format");
                _email = value;
            }
        }

        public void LogCustomerInfo()
        {
            Console.WriteLine($"ID {_id} - Name: {Name} - Surname: {Surname} - Email: {Email}");
        }

        private static bool IsEmailValid(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return true;
            else
                return false;
        }


        private static string GenerateId()
        {

            Guid guid = Guid.NewGuid();
            return guid.ToString();

        }

        private static string ReadStringNotEmpty()
        {
            while (true)
            {
                try
                {
                    string text = Console.ReadLine().Trim();

                    if (string.IsNullOrEmpty(text))
                    {
                        throw new FormatException("Zehmet olmasa, bosh melumat daxil etmeyin.");
                    }
                    return text;
                }
                catch (FormatException)
                {
                    throw;
                }
            }
        }
    }
}
