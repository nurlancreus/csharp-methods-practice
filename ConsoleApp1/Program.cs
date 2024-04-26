
#region Utility functions
static int? ReadInteger(bool acceptEmptyValue = false)
{
    while (true)
    {
        try
        {
            string input = Console.ReadLine().Trim();
            if (acceptEmptyValue)
            {

                if (string.IsNullOrEmpty(input))
                {
                    return null; // return null if value is empty
                }

            }

            return Convert.ToInt32(input);
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
try
{
    Thread.Sleep(1000);
    Console.WriteLine("Task 1");
    Console.WriteLine("3 eded daxil edin ve en boyuyunu alin");

    Console.Write("Eded 1: ");
    int num1 = (int)ReadInteger();

    Console.Write("Eded 2: ");
    int num2 = (int)ReadInteger();

    Console.Write("Eded 3: ");
    int num3 = (int)ReadInteger();

    Console.WriteLine("{0}, {1}, {2} ededlerinden en boyuyu: {3}", num1, num2, num3, GetMax(num1, num2, num3));

}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

int GetMax(int number1, int number2, int number3)
{
    int[] numArr = { number1, number2, number3 };

    int max = int.MinValue;

    foreach (int num in numArr)
    {
        if (num > max) max = num;
    }
    return max;
};

Console.WriteLine("*******************************************************************");
Console.WriteLine("*******************************************************************");
Console.WriteLine("*******************************************************************");
Console.WriteLine("");
Console.WriteLine("");
#endregion;


#region Task2

try
{
    Thread.Sleep(1000);
    Console.WriteLine("Task 2");
    Console.WriteLine("2 eded daxil edin ve deyerlerini deyishin");

    Console.Write("Eded 1: ");
    int number1 = (int)ReadInteger();

    Console.Write("Eded 2: ");
    int number2 = (int)ReadInteger();

    Console.WriteLine("1-ci eded {0}, 2-ci eded {1}", number1, number2);

    ChangeValues(ref number1, ref number2);

    Console.WriteLine("1-ci eded {0}, 2-ci eded {1}", number1, number2);

}

catch (Exception e)
{
    Console.WriteLine(e.Message);
}

void ChangeValues(ref int num1, ref int num2)
{
    (num2, num1) = (num1, num2);
    Console.WriteLine("Funksiya cagirilir..");
    Thread.Sleep(1000);
};

Console.WriteLine("*******************************************************************");
Console.WriteLine("*******************************************************************");
Console.WriteLine("*******************************************************************");
Console.WriteLine("");
Console.WriteLine("");
#endregion;


#region Task3
try
{
    Thread.Sleep(1000);
    Console.WriteLine("Task 3");
    void ConsoleSum()
    {
        Console.WriteLine("2 eded daxil edin ve cemlerini alin");

        Console.Write("Eded 1: ");
        int num1 = (int)ReadInteger();

        Console.Write("Eded 2: ");
        int num2 = (int)ReadInteger();

        Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
    }

    ConsoleSum();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine("*******************************************************************");
Console.WriteLine("*******************************************************************");
Console.WriteLine("*******************************************************************");
Console.WriteLine("");
Console.WriteLine("");
#endregion;

#region Task4
Thread.Sleep(1000);
Console.WriteLine("Task 4");
int[] numArr = { 10, 5, 8, 20, 15 };

GetMaxFromArr(numArr);

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

Console.WriteLine("*******************************************************************");
Console.WriteLine("*******************************************************************");
Console.WriteLine("*******************************************************************");
Console.WriteLine("");
Console.WriteLine("");
#endregion;

#region Task5
Thread.Sleep(1000);
Console.WriteLine("Task 5");

Console.WriteLine("Bir eded daxil edin ve kvadratini oyrenin, eger daxil etmesez default deyerin (2) kvadrati tapilacaq.");

Console.Write("Eded: ");
int? reqem = ReadInteger(true);

if (reqem == null) Console.WriteLine("default ededin (2) kvadrati {0}", GetSquare());
else Console.WriteLine("{0}^2 = {1}", reqem, GetSquare((int)reqem));

int GetSquare(int num1 = 2)
{
    return num1 * num1;
}

Console.WriteLine("*******************************************************************");
Console.WriteLine("*******************************************************************");
Console.WriteLine("*******************************************************************");
Console.WriteLine("");
Console.WriteLine("");
#endregion;

#region Task6
Thread.Sleep(1000);
Console.WriteLine("Task 6");
Console.WriteLine("Text daxil edin ve uzunlugunu oyrenin");

Console.Write("Text: ");
string text = ReadStringNotEmpty();

Console.WriteLine("\"{0}\" uzunlugu {1}", text, GetLengthOfText(text));

int GetLengthOfText(string text)
{
    Console.WriteLine("Funksiya cagirilir..");
    Thread.Sleep(1000);
    return text.Length;
}

Console.WriteLine("*******************************************************************");
Console.WriteLine("*******************************************************************");
Console.WriteLine("*******************************************************************");
Console.WriteLine("");
Console.WriteLine("");
#endregion;

#region Task7
Thread.Sleep(1000);
Console.WriteLine("Task 7");

Console.WriteLine("Daxil etdiyiniz ededler arasinda qalan ededlerin cemi {0}", GetSumOfRange());

int GetSumOfRange()
{
    Console.WriteLine("2 eded daxil edin ve onlar arasinda qalan ededlerin cemini elde edin");

    Console.Write("Eded 1: ");
    int num1 = (int)ReadInteger();
    Console.Write("Eded 2: ");
    int num2 = (int)ReadInteger();

    if (num1 > num2) (num2, num1) = (num1, num2);

    int sum = 0;
    int start = num1 + 1;

    for (int i = start; i < num2; i++)
    {
        sum += i;
    }

    Console.WriteLine("Cem hesablanir..");
    Thread.Sleep(1000);
    return sum;
}

Console.WriteLine("*******************************************************************");
Console.WriteLine("*******************************************************************");
Console.WriteLine("*******************************************************************");
Console.WriteLine("");
Console.WriteLine("");
#endregion;

#region Task8
Thread.Sleep(1000);
Console.WriteLine("Task 8");

Console.WriteLine("Eded ve Quvveti daxil ederek yekun neticeni hesablayin");

Console.Write("Eded: ");
int baseNum = (int)ReadInteger();
Console.Write("Quvvet: ");
int exponent = (int)ReadInteger();

try
{
    int result = GetPower(baseNum, exponent);

    Console.WriteLine($"{baseNum}^{exponent} = {result}");
}
catch (ArgumentException e)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.BackgroundColor = ConsoleColor.Red;
    Console.WriteLine(e.Message);
    Console.ResetColor();
}

int GetPower(int baseNum, int exponent)
{
    if (exponent < 0) throw new ArgumentException("Quvvet menfi ola bilmez");
    if (exponent == 0) return 1;

    return baseNum * GetPower(baseNum, --exponent);
}

Console.WriteLine("*******************************************************************");
Console.WriteLine("*******************************************************************");
Console.WriteLine("*******************************************************************");
Console.WriteLine("");
Console.WriteLine("");
#endregion;

#region Task9

try
{
    Thread.Sleep(1000);
    Console.WriteLine("Task 9");

    Console.WriteLine("Eded daxil edin ve o edede qeder olan fibonacci ardicilligini elde edin");

    Console.Write("Eded: ");
    int fibNum = (int)ReadInteger();

    List<int> fibList = [];

    if (fibNum < 0)
    {
        throw new ArgumentException("Fibonacci ardicilligi menfi ola bilmez");
    }

    for (int i = 0; i < fibNum; i++)
    {
        fibList.Add(GetFibonacci(i));
    }

    int[] fibSequence = [.. fibList];

    Thread.Sleep(1000);
    Console.WriteLine("Deyerler elde olunur ve cem hesablanir...");

    Console.WriteLine($"Fibonacci ededleri: {string.Join(", ", fibSequence)}");
}
catch (ArgumentException e)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.BackgroundColor = ConsoleColor.Red;
    Console.WriteLine(e.Message);
    Console.ResetColor();
}

int GetFibonacci(int num)
{
    if (num < 2) return num;

    return GetFibonacci(num - 1) + GetFibonacci(num - 2);
}

Console.WriteLine("*******************************************************************");
Console.WriteLine("*******************************************************************");
Console.WriteLine("*******************************************************************");
Console.WriteLine("");
Console.WriteLine("");
#endregion;