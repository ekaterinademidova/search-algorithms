using Microsoft.VisualStudio.TestTools.UnitTesting;

// Набор тестов для алгоритма бинарного поиска
[TestClass]
public class BinarySearchTests
{
    private static readonly BinarySearchAlgorithm Binary = new BinarySearchAlgorithm();

    // Тест для проверки корректности поиска элемента, который есть в массиве.
    // В этом случае ожидается, что метод вернёт корректный индекс найденного элемента.
    [TestMethod]
    public void BinarySearch_ElementExists_ReturnsCorrectIndex()
    {
        double[][] array = new double[5][];
        array[0] = new double[4] { 5, 6.87, 2, -10 };
        array[1] = new double[6] { 92.345, 51.03, -7.005, -36.99, 0.551, 4.758 };
        array[2] = new double[3] { 4.44, 5, 0 };
        array[3] = new double[4] { 12.33, -17.02, 0.999, 8 };
        array[4] = new double[4] { 31.22, -54.813, 8.09, -47 };

        double key = -36.99;
        double difference = 0;

        string actual = Binary.BinarySearch(array, key, difference);
        string expected = "Индекс элемента с искомым значением -36,99 - [2,1].";

        Assert.AreEqual(expected, actual);
    }

    // Тест для проверки корректности поиска элемента, который есть в массиве, учитывая приемлемое значение погрешности.
    // В этом случае ожидается, что метод вернёт корректный индекс найденного элемента с учётом погрешности.
    [TestMethod]
    public void BinarySearch_ElementExists_ReturnsCorrectIndex2()
    {
        double[][] array = new double[5][];
        array[0] = new double[4] { 5, 6.87, 2, -10 };
        array[1] = new double[6] { 92.345, 51.03, -7.005, -36.99, 0.551, 4.758 };
        array[2] = new double[3] { 4.44, 5, 0 };
        array[3] = new double[4] { 12.33, -17.02, 0.999, 8 };
        array[4] = new double[4] { 31.22, -54.813, 8.09, -47 };

        double key = 92.34;
        double difference = 0.01;

        string actual = Binary.BinarySearch(array, key, difference);
        string expected = "Индекс элемента с искомым значением 92,34 - [2,6].";

        Assert.AreEqual(expected, actual);
    }

    // Тест для проверки корректности поиска элемента, который встречается в массиве более одного раза.
    // В этом случае ожидается, что метод вернёт корректный индекс первого найденного элемента.
    [TestMethod]
    public void BinarySearch_ElementExists_ReturnsCorrectIndex3()
    {
        double[][] array = new double[5][];
        array[0] = new double[4] { 5, 6.87, 2, -10 };
        array[1] = new double[6] { 92.345, 51.03, -7.005, -36.99, 0.551, 4.758 };
        array[2] = new double[3] { 4.44, 5, 0 };
        array[3] = new double[4] { 12.33, -17.02, 0.999, 8 };
        array[4] = new double[4] { 31.22, -54.813, 8.09, -47 };

        double key = 5;
        double difference = 0;

        string actual = Binary.BinarySearch(array, key, difference);
        string expected = "Индекс элемента с искомым значением 5 - [1,3].";

        Assert.AreEqual(expected, actual);
    }

    // Тест для проверки корректности поиска элемента, который отсутствует в массиве.
    // В этом случае ожидается, что метод сообщит, что элемент не найден.
    [TestMethod]
    public void BinarySearch_ElementDoesNotExist_ReturnsErrorMessage()
    {
        double[][] array = new double[5][];
        array[0] = new double[4] { 5, 6.87, 2, -10 };
        array[1] = new double[6] { 92.345, 51.03, -7.005, -36.99, 0.551, 4.758 };
        array[2] = new double[3] { 4.44, 5, 0 };
        array[3] = new double[4] { 12.33, -17.02, 0.999, 8 };
        array[4] = new double[4] { 31.22, -54.813, 8.09, -47 };

        double key = 6;
        double difference = 0;

        string actual = Binary.BinarySearch(array, key, difference);
        string expected = "Элемент не найден.";

        Assert.AreEqual(expected, actual);
    }

    // Тест для проверки корректности поиска элементас использованием недопустимой погрешности.
    // В этом случае ожидается, что метод сообщит, что элемент не найден.
    [TestMethod]
    public void BinarySearch_ElementDoesNotExist_ReturnsErrorMessage2()
    {
        double[][] array = new double[5][];
        array[0] = new double[4] { 5, 6.87, 2, -10 };
        array[1] = new double[6] { 92.345, 51.03, -7.005, -36.99, 0.551, 4.758 };
        array[2] = new double[3] { 4.44, 5, 0 };
        array[3] = new double[4] { 12.33, -17.02, 0.999, 8 };
        array[4] = new double[4] { 31.22, -54.813, 8.09, -47 };

        double key = 0.99;
        double difference = 0.0001;

        string actual = Binary.BinarySearch(array, key, difference);
        string expected = "Элемент не найден.";

        Assert.AreEqual(expected, actual);
    }
}
