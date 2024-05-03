using OOP_part2.Entities;

namespace OOP_part2
{
    internal class Program
    {
        #region UtilityFunctions
        static decimal ReadDecimal()
        {
            while (true)
            {
                try
                {
                    if (decimal.TryParse(Console.ReadLine(), out var value)) return value;

                    else throw new FormatException("Zehmet olmasa duzgun melumat daxil edin");
                }
                catch (FormatException)
                {
                    throw;
                }
            }
        }

        static string ReadString()
        {
            while (true)
            {
                try
                {
                    string text = Console.ReadLine().Trim();

                    if (string.IsNullOrEmpty(text))
                    {
                        throw new FormatException("Zehmet olmasa, bosh text daxil etmeyin.");
                    }
                    return text;
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                }
            }
        }
        static void CustomLog(string msg, bool exception = true)
        {
            Console.BackgroundColor = exception ? ConsoleColor.Red : ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        #endregion

        static void Main(string[] args)
        {
            #region Task1
            try
            {
                Person person1 = new Person();

                person1.SetName("Nurlan");
                person1.SetAge(25);

                Console.WriteLine($"ID {person1.GetId()}Ad {person1.GetName()} - Yash {person1.GetAge()}");

                Person person2 = new Person("Yusif", 40);
                Console.WriteLine($"ID {person2.GetId()}Ad {person2.GetName()} - Yash {person2.GetAge()}");
            }
            catch (Exception ex)
            {

                CustomLog(ex.Message);
            }

            #endregion;

            #region Task2
            try
            {
                Truck truck = new Truck(VehicleStatus.UnderRepair);
                Console.WriteLine($"{truck.GetStatus()}");
            }
            catch (Exception ex)
            {

                CustomLog(ex.Message);
            }

            #endregion;

            #region Task3
            try
            {
                Console.Write("En: ");
                if (!Decimal.TryParse(Console.ReadLine(), out decimal width)) throw new Exception("Input dogru formatda daxil edilmeyib.");


                Console.Write("Hundurluk: ");
                if (!Decimal.TryParse(Console.ReadLine(), out decimal height)) throw new Exception("Input dogru formatda daxil edilmeyib.");

                Romb romb1 = new Romb(width, height);

                Console.WriteLine($"Sahe: {romb1.GetArea()}");
            }
            catch (Exception ex)
            {

                CustomLog(ex.Message);
            }

            #endregion;

            #region Task4
            try
            {
                Customer customer = new Customer();
                customer.LogCustomerInfo();

            }
            catch (Exception ex)
            {

                CustomLog(ex.Message);
            }

            #endregion;

            #region Task5
            try
            {
                Console.WriteLine("3 bucagin terefini daxil edin.");
                int side = Convert.ToInt32(Console.ReadLine());

                Triangle triangle1 = new Triangle(side);

                Console.WriteLine("Kvadratin terefini daxil edin.");
                int sideSquare = Convert.ToInt32(Console.ReadLine());

                Square square1 = new Square(sideSquare);

                Console.WriteLine($"{nameof(triangle1)} perimetri {triangle1.CalculatePerimeter()}");
                Console.WriteLine($"{nameof(square1)} perimetri {square1.CalculatePerimeter()}");
            }
            catch (Exception ex)
            {

                CustomLog(ex.Message);
            }

            #endregion;

            #region Task6

            try
            {
                Teacher teacher1 = new Teacher();
                Driver driver1 = new Driver();
                Console.WriteLine($"{nameof(teacher1)} ayliq maashi {teacher1.CalculateSalaryPerMonth()}");
                Console.WriteLine($"{nameof(driver1)} ayliq maashi {driver1.CalculateSalaryPerMonth()}");

                Teacher teacher2 = new Teacher(20.5F, 120);
                Driver driver2 = new Driver(12.8f, 200);
                Console.WriteLine($"{nameof(teacher2)} ayliq maashi {teacher2.CalculateSalaryPerMonth()}");
                Console.WriteLine($"{nameof(driver2)} ayliq maashi {driver2.CalculateSalaryPerMonth()}");

            }
            catch (Exception ex)
            {

                CustomLog(ex.Message);
            }
            #endregion

            #region Task7

            try
            {
                _ = new Student();
            }
            catch (Exception ex)
            {

                CustomLog(ex.Message);
            }

            #endregion

            #region Task8
            try
            {
                BankAccount account1 = new BankAccount();

                bool finishOperation = false;

                while (!finishOperation)
                {
                    Console.WriteLine($"\n\n\nBalansi oyrenmek uchun 1.\nHesaba medaxil etmek uchun 2.\nHesabdan mexaric etmek uchun 3.\nKredit goturmek uchun 4.\nKrediti baglamaq uchun 5.\nEmeliyyatlari sonlandirmaq uchun 0.\n\n sechimlerinden birinden istifade edin.");
                    int userChoice = (int)ReadDecimal();

                    switch (userChoice)
                    {
                        case 1:
                            CustomLog($"Sizin cari hesab balansiniz {account1.Balance}", false);
                            break;
                        case 2:
                            Console.Write($"Zehmet olmasa medaxil meblegini daxil edin: ");
                            decimal amountDeposit = ReadDecimal();
                            account1.Deposit(amountDeposit);
                            CustomLog($"{amountDeposit} mebleginde \"medaxil\" emeliyyati ugurla icra oldu. Balans: {account1.Balance}", false);

                            break;
                        case 3:
                            Console.Write($"Zehmet olmasa mexaric meblegini daxil edin: ");
                            decimal amountWithdraw = ReadDecimal();
                            account1.WithDraw(amountWithdraw);
                            CustomLog($"{amountWithdraw} mebleginde \"mexaric\" emeliyyati ugurla icra oldu. Balans: {account1.Balance}", false);

                            break;
                        case 4:
                            Console.WriteLine($"Kreditin meqsedi ve meblegini yazin. Eger evvelki kreditiniz varsa, yeni kredit goture bilmeyeceksiniz.");

                            if (account1.Loan > 0) CustomLog($"Sizin artiq \"{account1.LoanPurpose}\" meqsedi uchun istifade olunan {account1.Loan} mebleginde kredit borcunuz var.");
                            else
                            {
                                Console.Write("Meqsed: ");
                                string loanPurpose = ReadString();
                                Console.Write("Mebleg: ");
                                decimal amountLoan = ReadDecimal();

                                account1.GetLoan(amountLoan, loanPurpose);
                                CustomLog($"Kredit emeliyyati ugurla icra oldu. Cari kreditniz ${account1.Loan}. Balans: {account1.Balance}", false);
                            }
                            break;
                        case 5:
                            account1.PayLoan();
                            CustomLog($"Siz kredit borcunuzu odediniz yeni kredit goture bilersiniz.\nCari balans {account1.Balance}", false);

                            break;
                        default:
                        case 0:
                            finishOperation = true;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {

                CustomLog(ex.Message);
            }
            #endregion;
        }
    }
}
