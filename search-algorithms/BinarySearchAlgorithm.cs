using System;

public class BinarySearchAlgorithm
{
    public string BinarySearch(double[][] a, double key, double difference)
    {
        // Сортировка и вывод массива данных
        for (int i = 0; i < a.Length; i++)
        {
            Array.Sort(a[i]);
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int j = 0; j < a[i].Length; j++)
                Console.Write("{0, 14}", a[i][j]);
            Console.WriteLine();
        }
        // Последовательный перебор строк массива
        for (int i = 0; i < a.Length; i++)
        {
            // Установление границ поиска
            int low = 0, high = a[i].Length - 1;
            while (low <= high)
            {
                // Определение среднего элемента поиска
                int mid = (low + high) / 2;
                double midValue = a[i][mid];

                // Проверка равенства искомого элемента с текущим
                if (Math.Abs(key - midValue) <= difference)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    return $"Индекс элемента с искомым значением {key} - [{i + 1},{mid + 1}].";
                }
                else if (key < midValue)
                    high = mid - 1;
                else
                    low = mid + 1;
            }
        }
        Console.ForegroundColor = ConsoleColor.Red;
        return "Элемент не найден.";
    }
}
