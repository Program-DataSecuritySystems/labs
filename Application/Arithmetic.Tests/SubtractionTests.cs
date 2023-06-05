using Arithmetic;
using System.Numerics;
using NUnit.Framework;

[TestFixture]
public class SubtractionTests
{
    private Operations _op;

    public SubtractionTests()
    {
        _op = new Operations();
    }

    [Test]
    public void TestSubtraction()
    {
        string a = "987654321";
        string b = "123456789";
        string expected = StringSubtraction(a, b);

        string result = _op.StringSubtraction(a, b);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void TestSubtractionWithNegativeResult()
    {
        string a = "123";
        string b = "200";
        string expected = StringSubtraction(a, b);

        string result = _op.StringSubtraction(a, b);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void TestSubtractionWithZero()
    {
        string a = "123456789";
        string b = "0";
        string expected = StringSubtraction(a, b);

        string result = _op.StringSubtraction(a, b);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void TestSubtractionWithLargeNumbers()
    {
        string a = "1000000000000000000000000000";
        string b = "999999999999999999999999999";
        string expected = StringSubtraction(a, b);

        string result = _op.StringSubtraction(a, b);
        Assert.AreEqual(expected, result);
    }

    private string StringSubtraction(string a, string b)
    {
        BigInteger numA = BigInteger.Parse(a);
        BigInteger numB = BigInteger.Parse(b);
        BigInteger difference = numA - numB;

        return difference.ToString();
    }
}