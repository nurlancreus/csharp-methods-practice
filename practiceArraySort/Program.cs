

using System.Collections.Generic;

List<int> arrList = new List<int>();

int currentInputNum;
int currentInputIndex = 0;
bool finishArray = false;
bool startMenu = true;

try
{
    while (startMenu)
    {
        Console.WriteLine("Array daxil etmek uchun 1.\nArtan sira ile sort etmek uchun 2.\nAzalan sira ile sort etmek uchun 3. u basin");
        int userInput = Convert.ToInt32(Console.ReadLine());

        switch (userInput)
        {
            case 1:
                Console.WriteLine("Arrayi daxil edin, chixmaq uchun reqem olmayan ededlerden birine clickleyin");
                while (!finishArray)
                {
                    Console.WriteLine($"Arraydaki {currentInputIndex}. index daxil edin");

                    finishArray = !(int.TryParse(Console.ReadLine(), out currentInputNum));
                    Console.WriteLine($"Arraydaki {currentInputIndex++}. index: {currentInputNum}");
                    arrList.Add(currentInputNum);
                }
                break;

            case 2:
                if (!arrList.Any()) throw new NullReferenceException();
                Console.WriteLine("bubble sort ile artan sira: " + string.Join(", ", BubbleSortArray([.. arrList])));
                startMenu = false;
                break;

            case 3:
                if (!arrList.Any()) throw new NullReferenceException();
                Console.WriteLine("bubble sort ile azalan sira: " + string.Join(", ", BubbleSortArray([.. arrList], "desc")));
                startMenu = false;
                break;
            default:
                throw new ArgumentException("Zehmet olmasa 1, 2 ve 3 sechimlerinden birini sechin.");

        }
    }
}
catch (ArgumentException ex)
{
    LogConsole(ex.Message);
}
catch (NullReferenceException)
{
    LogConsole("Array boshdur evvelce deyer daxil edin");
}
catch (FormatException)
{
    LogConsole("Istifadechi duzgun formatda eded daxil etmeyib.");
}


#region Utilities
void LogConsole(string msg)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.BackgroundColor = ConsoleColor.Red;
    Console.WriteLine(msg);
    Console.ResetColor();
}


int[] BubbleSortArray(int[] array, string type = "asc")
{
    int arrayLength = array.Length;
    int modifier = type == "asc" ? 1 : -1;
    bool isSwapped;

    for (int i = 0; i < arrayLength; i++)
    {
        isSwapped = false;

        for (int j = 0; j < arrayLength - i - 1; j++)
        {
            if (array[j] * modifier > array[j + 1] * modifier)
            {
                // Swap elements
                (array[j], array[j + 1]) = (array[j + 1], array[j]);
                isSwapped = true;
            }
        }

        // If no two elements were swapped in the inner loop, array is sorted
        if (!isSwapped)
            break;
    }

    return array;
};

#endregion;