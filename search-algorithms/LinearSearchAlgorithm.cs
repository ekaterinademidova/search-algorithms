using System;

public class LinearSearchAlgorithm
{
    public string LinearSearch(double[][] a, double key, double difference)
    {
        // Последовательный перебор всех элементов массива
        for (int i = 0; i < a.Length; i++)
        {
            for (int j = 0; j < a[i].Length; j++)
            {
                // Проверка равенства искомого элемента с текущим
                if (Math.Abs(a[i][j] - key) <= difference)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    return $"Индекс элемента с искомым значением {key} - [{i + 1},{j + 1}].";
                }
            }
        }
        Console.ForegroundColor = ConsoleColor.Red;
        return "Элемент не найден.";
    }
}
