using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace OOP_part2.Entities
{

    public enum StudentSpecialty
    {
        Arts,
        Science,
        Engineering,
        Humanities,
        Business,
        Medicine
    }
    internal class Student
    {
        private string _studentId;
        private string _firstName;
        private string _lastName;
        private StudentSpecialty _specialty;

        public Student()
        {
            Console.Write("Enter Student name: ");
            string firstName = ReadStringNotEmpty();

            Console.Write("Enter Student last name: ");
            string lastName = ReadStringNotEmpty();
            StudentSpecialty studentSpecialty = GetStudentSpecialty();

            StudentId = GenerateStudentId();
            FirstName = firstName;
            LastName = lastName;
            Specialty = studentSpecialty;

            Console.WriteLine($"{StudentId} - {FullName} - {Specialty}");
        }


        public string StudentId
        {
            get => _studentId;

            private set
            {
                _studentId = value;
            }
        }

        public string FirstName
        {
            get => _firstName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("User's firstname input cannot be empty");
                _firstName = value;
            }
        }

        public string LastName
        {
            get => _lastName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("User's lastname input cannot be empty");
                _lastName = value;
            }
        }

        public string FullName
        {
            get => FirstName + " " + LastName;
        }

        public StudentSpecialty Specialty
        {
            get => _specialty;
            private set
            {
                if (!Enum.IsDefined(typeof(StudentSpecialty), value))
                {
                    throw new ArgumentException("Invalid student specialty");
                }

                _specialty = value;
            }
        }

        private static StudentSpecialty GetStudentSpecialty()
        {
            Console.WriteLine("Enter student specialty:");
            string input = ReadStringNotEmpty();
            if (Enum.TryParse(input, true, out StudentSpecialty specialty))
            {
                return specialty;
            }
            else
            {
                throw new ArgumentException("Invalid student specialty entered.");
            }
        }

        private static string ReadStringNotEmpty()
        {

            try
            {
                string text = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(text))
                {
                    throw new FormatException("Please, do not put empty input");
                }
                return text;
            }
            catch (FormatException)
            {
                throw;
            }

        }

        private static string GenerateStudentId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }

    }
}
