using OOP_tasks_part1.Entities;

namespace OOP_tasks_part1
{
    internal class Program
    {
        static void LogException(string msg)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            #region Task1
            try
            {

                Circle circle = new Circle();
                Console.WriteLine(circle.CalculateCircle());

            }
            catch (Exception ex)
            {
                LogException(ex.Message);
            };
            #endregion

            #region Task2
            try
            {

                Person person1 = new Person("Nurlan", "Shukurov", 25);
                Console.WriteLine($"{person1.Name} - {person1.Surname} - {person1.Age}");

            }
            catch (Exception ex)
            {
                LogException(ex.Message);
            };
            #endregion;

            #region Task3
            try
            {
                Car car = new Car("Auid", "A3", 1996);
                Console.WriteLine($"{car.Brand} - {car.Model} - {car.Year}");

            }
            catch (Exception ex)
            {
                LogException(ex.Message);
            };
            #endregion;

            #region Task4
            try
            {
                Book book = new Book("A Dance with Dragons", "George R. R. Martin", 1510);
                Console.WriteLine($"{book.Name} - {book.Author} - {book.PageCount}");
            }
            catch (Exception ex)
            {
                LogException(ex.Message);
            };
            #endregion

            #region Task5
            try
            {
                Asus asus = new Asus("S15", 16, "i9");
                Hp hp = new Hp("TPN-Q222", 32, "i3");
                Acer acer = new Acer("Swift Go 14", 16, "i7");
                Lenovo lenovo = new Lenovo("Ideapad 3i", 8, "i5");

                Console.WriteLine($"{asus.Brand} - {asus.Model} - {asus.Ram} - {asus.Cpu}");
                Console.WriteLine($"{hp.Brand} - {hp.Model} - {hp.Ram} - {hp.Cpu}");
                Console.WriteLine($"{acer.Brand} - {acer.Model} - {acer.Ram} - {acer.Cpu}");
                Console.WriteLine($"{lenovo.Brand} - {lenovo.Model} - {lenovo.Ram} - {lenovo.Cpu}");
            }
            catch (Exception ex)
            {
                LogException(ex.Message);
            };
            #endregion
        }
    }
}
