using OOP.Entities;

namespace OOP
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
            try
            {
                //Car car = new Car();
                //car.name = "Audi";

                //Car car2 = new Car();
                //car2.name = "Mercedes";

                //Console.WriteLine(car.name);
                //Console.WriteLine(car2.name);

                //Teacher teacher1 = new Teacher();
                //teacher1.Name = "Isa";
                //teacher1.Age = -10;
                //Console.WriteLine(teacher1.Name);
                //Console.WriteLine(teacher1.Age);

                //Teacher teacher2 = new Teacher();
                //teacher2.Name = "Nemet";
                //teacher2.Age = 24;
                //Console.WriteLine(teacher2.Name);
                //Console.WriteLine(teacher2.Age);

                //Person person1 = new Person();
                // Cannot create an instance of an abstract class

                //Teacher teacher = new Teacher("Isa");
                //Teacher teacher2 = new Teacher("Nemet", "Quliyev");
                //Teacher teacher3 = new Teacher();

                //teacher3.Name = "Shamil";
                //teacher3.Surname = "Memmedov";
                //teacher3.Salary = 200.40M;
                //teacher3.Age = 25;

                //Console.WriteLine(teacher3.Name, teacher3.Surname, teacher3.Salary);

                #region Task1
                Circle circle = new Circle();
                Console.WriteLine(circle.CalculateCircle());
                #endregion

            }
            catch (Exception ex)
            {
                LogException(ex.Message);
            }

        }
    }
}
