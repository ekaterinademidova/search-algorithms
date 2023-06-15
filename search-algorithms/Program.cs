using BenchmarkDotNet.Running;
using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    // Проверка ввода пользовательских данных
    public static double DoubleNumber()
    {
        while (true)
        {
            bool isCorrect = double.TryParse(Console.ReadLine(), out double dec);
            if (isCorrect) return dec;
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введено некорректное значение, повторите ввод.");
                Console.ResetColor();
            }
        }
    }

    private static readonly LinearSearchAlgorithm Linear = new LinearSearchAlgorithm();
    private static readonly BinarySearchAlgorithm Binary = new BinarySearchAlgorithm();
    static void Main(string[] args)
    {
#if RELEASE
    BenchmarkRunner.Run<SearchAlgorithmsBenchmarks>();
#else

        ConsoleKeyInfo keyPressed;
        string rule = "[0-1]";
        string? path = null;

        while (true)
        {
            //Выбор источника обрабатываемых данных
            Console.WriteLine("Выберите вариант выбора файла с данными с помощью меню:" +
                "\n0 - файл по умолчанию \"sample.txt\"" +
                "\n1 - указать другой путь к файлу\n");
            while (true)
            {
                keyPressed = Console.ReadKey(true);
                if (Regex.IsMatch(keyPressed.KeyChar.ToString(), rule)) break;
            }
            if (int.Parse(keyPressed.KeyChar.ToString()) == 1)
            {
                Console.Write("\nВведите путь к файлу:\t");
                path = Console.ReadLine();
            }
            else path = "data/sample.txt";

            // Проверка существования файла с исходными данными
            if (File.Exists(path))
            {
                string[] data = File.ReadAllLines(path);
                // Проверка наличия данных в указанном файле
                if (data.Length != 0)
                {
                    double[][] array = new double[data.Length][];
                    for (int i = 0; i < array.Length; i++)
                    {
                        // Формированние массива данных (string[] -> double[][])
                        string str = Regex.Replace(data[i], @"\s{2,}", " ");
                        // Преобразование типов данных из файла (string -> double)
                        array[i] = Array.ConvertAll(str.Trim().Split(' '), s => double.Parse(s));
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        // Вывод исходного массива данных
                        for (int j = 0; j < array[i].Length; j++)
                            Console.Write("{0, 14}", array[i][j]);
                        Console.WriteLine();
                    }
                    Console.ResetColor();

                    // Ввод искомого значения
                    Console.Write("\nВведите значение, которое необходимо найти в данном массиве:\t");
                    double key = DoubleNumber();
                    // Ввод приемлемой погрешности
                    Console.Write("\nУкажите приемлемое относительное поле разности между двумя значениями для установления равенства вещественных чисел: ");
                    double difference;
                    do
                    {
                        difference = DoubleNumber();
                        // Проверка корректности пользовательских данных (значение погрешности должно быть в диапазоне [0,1))
                        if (difference >= 0 && difference < 1) break;
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Поле должно иметь значение в диапазоне [0,1). Повторите ввод.");
                            Console.ResetColor();
                        }
                    } while (true);
                    // Ввывод результата работы алгоритма линейного поиска
                    Console.WriteLine("\nРезультат поиска элемента линейным поиском:");
                    Console.WriteLine(Linear.LinearSearch(array, key, difference));
                    Console.ResetColor();
                    // Ввывод результата работы бинарного линейного поиска
                    Console.WriteLine("\nДля поиска элемента бинарным поиском необходимо отсортировать исходный массив.\nПолученный массив и результат:");
                    Console.WriteLine(Binary.BinarySearch(array, key, difference));
                    Console.ResetColor();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Файл пуст.\n");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Файл не существует.\n");
                Console.ResetColor();
            }
        }

#endif
    }
}