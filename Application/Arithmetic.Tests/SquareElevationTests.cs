using Arithmetic;
using System.Numerics;
using NUnit.Framework;

[TestFixture]
public class SquareElevationTests
{
    private Operations _op;

    public SquareElevationTests()
    {
        _op = new Operations();
    }

    [Test]
    public void TestSquareElevation()
    {
        string a = "123456789";
        string expected = SquareElevation(a);

        string result = _op.SquareElevation(a);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void TestSquareElevationWithZero()
    {
        string a = "0";
        string expected = SquareElevation(a);

        string result = _op.SquareElevation(a);
        Assert.AreEqual(expected, result);
    }

    private string SquareElevation(string a)
    {
        BigInteger numA = BigInteger.Parse(a);
        BigInteger square = BigInteger.Pow(numA, 2);

        return square.ToString();
    }
}
