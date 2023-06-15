using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class SearchAlgorithmsBenchmarks
{
    // Исходные тестовые данные
    private readonly double[][] array = new[]
    {
        new double[] { 5, 6.87, 2, -10 },
        new double[] { 92.345, 51.03, -7.005, -36.99, 0.551, 4.758 },
        new double[] { 92.345, 45, -7.03, -36.99, 0.57, 4.708 },
        new double[] { 345, 51.03, 5, -36.99, 0.61, 158 },
        new double[] { 4.44, 5, 0 },
        new double[] { 92.345, 51.03, -7.005, -36.99, 0.551, 4.758 },
        new double[] { 76, 73, 9805, 9.99, 0.751, -4.758 },
        new double[] { 12.33, -17.02, 0.999, 8 },
        new double[] { 2.35, 57.03, -45.005, -36.99 },
        new double[] { 51.03, -36.99, 0.551, 4.758 },
        new double[] { 5, -36.99, 0.5, 475.8 },
        new double[] { 37.345, 51.03, -36.99, 0.551, 4.758 },
        new double[] { 31.22, -54.813, 8.09, -47 },
    };
    private readonly double key = 92.34;
    private readonly double difference = 0.01;

    private static readonly LinearSearchAlgorithm Linear = new LinearSearchAlgorithm();
    private static readonly BinarySearchAlgorithm Binary = new BinarySearchAlgorithm();

    // Метод для анализа производительности алгоритма линейного поиска
    [Benchmark] 
    public void GetKeyByLinearAlgorithm()
    {
        Linear.LinearSearch(array, key, difference);
    }

    // Метод для анализа производительности алгоритма бинарного поиска
    [Benchmark]
    public void GetKeyByBinaryAlgorithm()
    {
        Binary.BinarySearch(array, key, difference);
    }
}
