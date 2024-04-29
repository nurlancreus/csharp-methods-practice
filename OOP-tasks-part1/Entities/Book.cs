using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_tasks_part1.Entities
{
    internal class Book
    {
        private string _name;
        private string _author;
        private int _pageCount;

        public Book(string name, string author, int pageCount)
        {
            this.Name = name;
            this.Author = author;
            this.PageCount = pageCount;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("Give proper book name");
                _name = value;
            }
        }
        public string Author
        {
            get { return _author; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("Give proper author name");
                _author = value;
            }
        }

        public int PageCount
        {
            get => _pageCount;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("PageCount cannot be negative.");
                }
                _pageCount = value;
            }
        }
    }
}
