using Microsoft.VisualStudio.TestTools.UnitTesting;

// ����� ������ ��� ��������� ��������� ������
[TestClass]
public class LinearSearchTests
{
    private static readonly LinearSearchAlgorithm Linear = new LinearSearchAlgorithm();

    // ���� ��� �������� ������������ ������ ��������, ������� ���� � �������.
    // � ���� ������ ���������, ��� ����� ����� ���������� ������ ���������� ��������.
    [TestMethod]
    public void LinearSearch_ElementExists_ReturnsCorrectIndex()
    {
        double[][] array = new double[5][];
        array[0] = new double[4] { 5, 6.87, 2, -10 };
        array[1] = new double[6] { 92.345, 51.03, -7.005, -36.99, 0.551, 4.758 };
        array[2] = new double[3] { 4.44, 5, 0 };
        array[3] = new double[4] { 12.33, -17.02, 0.999, 8 };
        array[4] = new double[4] { 31.22, -54.813, 8.09, -47 };

        double key = -36.99;
        double difference = 0;

        string actual = Linear.LinearSearch(array, key, difference);
        string expected = "������ �������� � ������� ��������� -36,99 - [2,4].";

        Assert.AreEqual(expected, actual);
    }

    // ���� ��� �������� ������������ ������ ��������, ������� ���� � �������, �������� ���������� �������� �����������.
    // � ���� ������ ���������, ��� ����� ����� ���������� ������ ���������� �������� � ������ �����������.
    [TestMethod]
    public void LinearSearch_ElementExists_ReturnsCorrectIndex2()
    {
        double[][] array = new double[5][];
        array[0] = new double[4] { 5, 6.87, 2, -10 };
        array[1] = new double[6] { 92.345, 51.03, -7.005, -36.99, 0.551, 4.758 };
        array[2] = new double[3] { 4.44, 5, 0 };
        array[3] = new double[4] { 12.33, -17.02, 0.999, 8 };
        array[4] = new double[4] { 31.22, -54.813, 8.09, -47 };

        double key = 92.34;
        double difference = 0.01;

        string actual = Linear.LinearSearch(array, key, difference);
        string expected = "������ �������� � ������� ��������� 92,34 - [2,1].";

        Assert.AreEqual(expected, actual);
    }


    // ���� ��� �������� ������������ ������ ��������, ������� ����������� � ������� ����� ������ ����.
    // � ���� ������ ���������, ��� ����� ����� ���������� ������ ������� ���������� ��������.
    [TestMethod]
    public void LinearSearch_ElementExists_ReturnsCorrectIndex3()
    {
        double[][] array = new double[5][];
        array[0] = new double[4] { 5, 6.87, 2, -10 };
        array[1] = new double[6] { 92.345, 51.03, -7.005, -36.99, 0.551, 4.758 };
        array[2] = new double[3] { 4.44, 5, 0 };
        array[3] = new double[4] { 12.33, -17.02, 0.999, 8 };
        array[4] = new double[4] { 31.22, -54.813, 8.09, -47 };

        double key = 5;
        double difference = 0;

        string actual = Linear.LinearSearch(array, key, difference);
        string expected = "������ �������� � ������� ��������� 5 - [1,1].";

        Assert.AreEqual(expected, actual);
    }

    // ���� ��� �������� ������������ ������ ��������, ������� ����������� � �������.
    // � ���� ������ ���������, ��� ����� �������, ��� ������� �� ������.
    [TestMethod]
    public void LinearSearch_ElementDoesNotExist_ReturnsErrorMessage()
    {
        double[][] array = new double[5][];
        array[0] = new double[4] { 5, 6.87, 2, -10 };
        array[1] = new double[6] { 92.345, 51.03, -7.005, -36.99, 0.551, 4.758 };
        array[2] = new double[3] { 4.44, 5, 0 };
        array[3] = new double[4] { 12.33, -17.02, 0.999, 8 };
        array[4] = new double[4] { 31.22, -54.813, 8.09, -47 };

        double key = 6;
        double difference = 0;

        string actual = Linear.LinearSearch(array, key, difference);
        string expected = "������� �� ������.";

        Assert.AreEqual(expected, actual);
    }

    // ���� ��� �������� ������������ ������ ��������� �������������� ������������ �����������.
    // � ���� ������ ���������, ��� ����� �������, ��� ������� �� ������.
    [TestMethod]
    public void LinearSearch_ElementDoesNotExist_ReturnsErrorMessage2()
    {
        double[][] array = new double[5][];
        array[0] = new double[4] { 5, 6.87, 2, -10 };
        array[1] = new double[6] { 92.345, 51.03, -7.005, -36.99, 0.551, 4.758 };
        array[2] = new double[3] { 4.44, 5, 0 };
        array[3] = new double[4] { 12.33, -17.02, 0.999, 8 };
        array[4] = new double[4] { 31.22, -54.813, 8.09, -47 };

        double key = 0.99;
        double difference = 0.0001;

        string actual = Linear.LinearSearch(array, key, difference);
        string expected = "������� �� ������.";

        Assert.AreEqual(expected, actual);
    }
}
