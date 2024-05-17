using System;
using System.Text;

namespace FIleSystemPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region - Task 1
            //. Aşağıdakı ifadəyə əsasən faylın mövcud olub olmadığını təyin edin.Əgər mövcuddursa "fayl tapıldı", deyilsə "fayl mövcud deyil" yazıb ekrana çıxarın.
            Console.WriteLine("*******TASK1*******\n");

            string fileName = "file.txt";

            try
            {
                if (File.Exists(fileName))
                {
                    Console.WriteLine("fayl tapildi");
                }
                else Console.WriteLine("fayl movcud deyil");

            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }

            #endregion;

            #region - Task2
            //Aşağıda verilmiş string dəyişəni əgər sistemdə mövcuddursa silsin, əks halda "fayl tapılmadı" yazısını ekrana çıxarın.

            Console.WriteLine("*******TASK2*******\n");
            string testfile = "test.txt";

            try
            {

                if (File.Exists(testfile))
                {
                    File.Delete(testfile);
                }
                else Console.WriteLine("fayl tapilmadi");
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }

            #endregion;

            #region - Task3
            //Mövcud olan faylın nüsxəsini çıxaran proqram yazın.
            Console.WriteLine("*******TASK3*******\n");
            string sourceFilePath = @$"C:{Path.DirectorySeparatorChar}Users{Path.DirectorySeparatorChar}ASUS{Path.DirectorySeparatorChar}Desktop{Path.DirectorySeparatorChar}test.txt";
            string destinationFilePath = @$"C:{Path.DirectorySeparatorChar}Users{Path.DirectorySeparatorChar}ASUS{Path.DirectorySeparatorChar}Desktop{Path.DirectorySeparatorChar}test_copy.txt";

            // Ensure the source file exists before creating or copying
            if (!File.Exists(sourceFilePath))
            {
                // Create the source file if it does not exist
                using (FileStream fs = File.Create(sourceFilePath))
                {
                    // You can write some data to the file if needed
                    byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                    fs.Write(info, 0, info.Length);
                }
            }

            try
            {
                // Check if the source file exists and the destination file does not exist before copying
                if (File.Exists(sourceFilePath) && !File.Exists(destinationFilePath))
                {
                    // Copy the file to the destination path
                    File.Copy(sourceFilePath, destinationFilePath);
                    Console.WriteLine("File copied successfully.");
                }
                else if (File.Exists(destinationFilePath))
                {
                    Console.WriteLine("Destination file already exists.");
                }
                else
                {
                    Console.WriteLine("Source file does not exist.");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }

            #endregion;

            #region - Task4
            Console.WriteLine("*******TASK4*******\n");

            //Mövcud faylın adını dəyişən proqram yazın.

            string newFileName = @$"C:{Path.DirectorySeparatorChar}Users{Path.DirectorySeparatorChar}ASUS{Path.DirectorySeparatorChar}Desktop{Path.DirectorySeparatorChar}newName.txt";

            if (File.Exists(sourceFilePath))
            {
                if (File.Exists(newFileName))
                {
                    Console.WriteLine("New file name is already exists.");
                }
                else
                {
                    File.Move(sourceFilePath, newFileName);
                    Console.WriteLine("File renamed successfully!");
                }
            }
            else
            {
                Console.WriteLine("Source file does not exist.");
            }
            #endregion;

            #region - Task5
            Console.WriteLine("*******TASK5*******\n");
            // Mövcud faylın həcmini ekrana çıxaran proqram yazın.

            string testFile = "TestFile.txt";

            // Ensure the file does not exist
            if (File.Exists(testFile))
            {
                File.Delete(testFile);
            }

            // Create and write to the file
            using (StreamWriter sw = new StreamWriter(testFile))
            {
                sw.WriteLine("Hello, I am a test file.");
            }

            // Ensure the file exists and get its size
            if (File.Exists(testFile))
            {
                FileInfo testFileInfo = new FileInfo(testFile);
                Console.WriteLine($"The size of the file '{testFile}' is: {testFileInfo.Length} bytes");
            }

            #endregion

            #region Task6
            Console.WriteLine("*******TASK6*******\n");

            //Downloads folderində olan bütün faylları ekrana çıxarın.
            string downloadsDirectoryPath = $@"C{Path.VolumeSeparatorChar}{Path.DirectorySeparatorChar}Users{Path.DirectorySeparatorChar}ASUS{Path.DirectorySeparatorChar}Downloads";
            DirectoryInfo downloadsDirInfo = new DirectoryInfo(downloadsDirectoryPath);

            if (downloadsDirInfo.Exists)
            {
                int fileCount = 0;
                foreach (FileInfo file in downloadsDirInfo.GetFiles())
                {
                    Console.WriteLine($"File {++fileCount}: {file.Name}");
                }
            }

            #endregion;

            #region Task7
            Console.WriteLine("*******TASK7*******\n");

            //Mövcud faylın yaradılma tarixini ekrana çıxarın.

            if(File.Exists(testFile))
            {
                FileInfo testFIleInfo = new FileInfo(testFile);
                DateTime fileCreationDate = testFIleInfo.CreationTime;
                Console.WriteLine($"Fayl yaranma tarixi: {fileCreationDate}");
            }
            #endregion;

            #region Task8
            Console.WriteLine("*******TASK8*******\n");

            //Bir folderdə yalnız "*.txt" uzantılı olan faylları ekrana çıxarın.

            string desktopDirPath = @$"C:{Path.DirectorySeparatorChar}Users{Path.DirectorySeparatorChar}ASUS{Path.DirectorySeparatorChar}Desktop";

            DirectoryInfo desktopDirInfo = new DirectoryInfo(desktopDirPath);

            if (desktopDirInfo.Exists)
            {
                int fileCount = 0;
                foreach (FileInfo file in desktopDirInfo.GetFiles("*.txt"))
                {
                    Console.WriteLine($"Text File {++fileCount}: {file.Name}");
                }
            }

            #endregion;
        }

    }

}
