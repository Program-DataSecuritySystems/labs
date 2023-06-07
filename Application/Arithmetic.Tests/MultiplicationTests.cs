using Arithmetic;
using System.Numerics;
using NUnit.Framework;

[TestFixture]
public class MultiplicationTests
{
    private Operations _op;

    public MultiplicationTests()
    {
        _op = new Operations();
    }

    [Test]
    public void TestMultiplication()
    {
        string a = "123456789";
        string b = "987654321";
        string expected = Multiply(a, b);

        string result = _op.Multiply(a, b);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void TestMultiplicationWithZero()
    {
        string a = "123456789";
        string b = "0";
        string expected = Multiply(a, b);

        string result = _op.Multiply(a, b);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void TestMultiplicationWithLargeNumbers()
    {
        string a = "999999999999999999999999999";
        string b = "111111111111111111111111111";
        string expected = Multiply(a, b);

        string result = _op.Multiply(a, b);
        Assert.AreEqual(expected, result);
    }

    private string Multiply(string first, string second)
    {
        BigInteger numA = BigInteger.Parse(first);
        BigInteger numB = BigInteger.Parse(second);
        BigInteger product = numA * numB;

        return product.ToString();
    }
}
