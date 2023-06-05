using System.Numerics;
using NUnit.Framework;
using Arithmetic;

[TestFixture]
public class AdditionTests
{
    private Operations _op;

    public AdditionTests()
    {
        _op = new Operations();
    }

    [Test]
    public void TestAddition()
    {
        string a = "123456789";
        string b = "987654321";
        string expected = _op.StringAddtion(a, b);

        string result = _op.StringAddtion(a, b);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void TestAdditionWithZero()
    {
        string a = "123456789";
        string b = "0";
        string expected = AddNumbers(a, b);

        string result = _op.StringAddtion(a, b);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void TestAdditionWithLargeNumbers()
    {
        string a = "999999999999999999999999999";
        string b = "1";
        string expected = AddNumbers(a, b);

        string result = _op.StringAddtion(a, b);
        Assert.AreEqual(expected, result);
    }

    private string AddNumbers(string a, string b)
    {
        BigInteger numA = BigInteger.Parse(a);
        BigInteger numB = BigInteger.Parse(b);
        BigInteger sum = numA + numB;

        return sum.ToString();
    }
}