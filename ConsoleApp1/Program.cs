
#region Utility functions
static int ReadInteger()
{
    while (true)
    {
        try
        {
            return Convert.ToInt32(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Zehmet olmasa, dogru tipde eded daxil edin.");
            Console.ResetColor();
        }
    }
}

static string ReadStringNotEmpty()
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

#endregion;


#region Task1
int getMax(int number1, int number2, int number3)
{
    int[] numArr = { number1, number2, number3 };

    int max = int.MinValue;

    foreach (int num in numArr)
    {
        if (num > max) max = num;
    }
    return max;
};

try
{
    Console.WriteLine("3 eded daxil edin ve en boyuyunu alin");

    int num1 = ReadInteger();
    int num2 = ReadInteger();
    int num3 = ReadInteger();

    Console.WriteLine("{0}, {1}, {2} ededlerinden en boyuyu: {3}", num1, num2, num3, getMax(num1, num2, num3));

    Console.WriteLine("*******************************************************************");
    Console.WriteLine("*******************************************************************");
    Console.WriteLine("*******************************************************************");
    Console.WriteLine("");
    Console.WriteLine("");
}
catch (FormatException)
{
    Console.WriteLine("Zehmet olmasa, dogru tipde eded daxil edin.");
}
#endregion;

#region Task2

try
{
    Console.WriteLine("2 eded daxil edin ve deyerlerini deyishin");
    int number1 = ReadInteger();
    int number2 = ReadInteger();

    Console.WriteLine("1-ci eded {0}, 2-ci eded {1}", number1, number2);

    void ChangeValues(ref int num1, ref int num2)
    {
        (num2, num1) = (num1, num2);
        Console.WriteLine("Funksiya cagirilir..");
        Thread.Sleep(1000);
    };

    ChangeValues(ref number1, ref number2);

    Console.WriteLine("1-ci eded {0}, 2-ci eded {1}", number1, number2);

    Console.WriteLine("*******************************************************************");
    Console.WriteLine("*******************************************************************");
    Console.WriteLine("*******************************************************************");
    Console.WriteLine("");
    Console.WriteLine("");
}

catch (FormatException)
{
    Console.WriteLine("Zehmet olmasa, dogru tipde eded daxil edin.");
}

#endregion;


#region Task3
try
{
    void ConsoleSum()
    {
        Console.WriteLine("2 eded daxil edin ve cemlerini alin");

        int num1 = ReadInteger();

        int num2 = ReadInteger();

        Console.WriteLine($"2 daxil etdiyiniz ededin cemi {num1 + num2}");
    }

    ConsoleSum();

    Console.WriteLine("*******************************************************************");
    Console.WriteLine("*******************************************************************");
    Console.WriteLine("*******************************************************************");
    Console.WriteLine("");
    Console.WriteLine("");
}
catch (FormatException)
{
    Console.WriteLine("Zehmet olmasa, dogru tipde eded daxil edin.");
}
#endregion;

#region Task4

int[] numArr = { 10, 5, 8, 20, 15 };

void GetMaxFromArr(int[] numArr)
{
    string numArrString = string.Join(", ", numArr);
    Console.WriteLine($"{numArrString} ededlerinden en boyuyunu tapin");
    int max = int.MinValue;

    foreach (int num in numArr)
    {
        if (num > max) max = num;
    }
    Console.WriteLine("Funksiya cagirilir..");
    Thread.Sleep(1000);

    Console.WriteLine($"{numArrString} ededlerinden en boyuyu {max}");
}

GetMaxFromArr(numArr);

Console.WriteLine("*******************************************************************");
Console.WriteLine("*******************************************************************");
Console.WriteLine("*******************************************************************");
Console.WriteLine("");
Console.WriteLine("");
#endregion;

#region Task5
int GetSquare(int num1 = 2)
{
    return num1 * num1;
}

Console.WriteLine("16 nin kvadrati {0}", GetSquare(16));
Console.WriteLine("default ededin (2) kvadrati {0}", GetSquare());

Console.WriteLine("*******************************************************************");
Console.WriteLine("*******************************************************************");
Console.WriteLine("*******************************************************************");
Console.WriteLine("");
Console.WriteLine("");
#endregion;

#region Task6

Console.WriteLine("Text daxil edin ve uzunlugunu oyrenin");
string text = ReadStringNotEmpty();

int GetLengthOfText(string text)
{
    Console.WriteLine("Funksiya cagirilir..");
    Thread.Sleep(1000);
    return text.Length;
}

Console.WriteLine("\"{0}\" uzunlugu {1}", text, GetLengthOfText(text));


#endregion;