namespace DelegatePractices
{
    internal class Program
    {
        public delegate double Operation(double num1, double num2);

        public static void ReadNumbersAndPrint(Operation operation)
        {
            Console.WriteLine("Enter first and second number you wanted to {0}", operation.Method.Name);

            Console.Write("First num: ");
            bool firstNumValid = double.TryParse(Console.ReadLine(), out double num1);
            Console.WriteLine("Second num: ");
            bool secondNumValid = double.TryParse(Console.ReadLine(), out double num2);

            if (firstNumValid && secondNumValid)
            {
                Console.WriteLine("Answer {0}", operation(num1, num2));
            }
            else
            {
                throw new Exception("Enter valid numbers");
            }
        }
        static void Main(string[] args)
        {

            try
            {
                bool isOperationsDone = false;
                while (!isOperationsDone)
                {

                    Console.WriteLine($"1. Sum.\n" + $"2. Subtract\n" + $"3. Multiply\n" + $"4. Divide\n" + $"5. Exit");

                    if (int.TryParse(Console.ReadLine(), out int userChoice))
                    {
                        switch (userChoice)
                        {
                            case 1:
                                ReadNumbersAndPrint(Sum);
                                break;
                            case 2:
                                ReadNumbersAndPrint(Subtract);
                                break;
                            case 3:
                                ReadNumbersAndPrint(Multiply);
                                break;
                            case 4:
                                ReadNumbersAndPrint(Divide);
                                break;
                            case 5:
                                isOperationsDone = true;
                                break;
                            default:
                                throw new Exception("Enter the valid operator");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static double Sum(double num1, double num2)
        {
            return num1 + num2;
        }

        public static double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }

        public static double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        public static double Divide(double num1, double num2)
        {
            if (num2 == 0) throw new DivideByZeroException();
            return num1 / num2;
        }
    }
}
