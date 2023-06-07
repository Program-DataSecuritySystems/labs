using Arithmetic;
using System.Numerics;
using NUnit.Framework;

[TestFixture]
public class ModuloTests
{
    private Operations _op;

    public ModuloTests()
    {
        _op = new Operations();
    }

    [Test]
    public void TestModulo()
    {
        string a = "123456789";
        string m = "7";
        string expected = Modulo(a, m);

        string result = _op.Modulo(a, m);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void TestModuloWithZero()
    {
        string a = "0";
        string m = "123456789";
        string expected = Modulo(a, m);

        string result = _op.Modulo(a, m);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void TestModuloWithLargeNumbers()
    {
        string a = "999999999999999999999999999";
        string m = "1000000000";
        string expected = Modulo(a, m);

        string result = _op.Modulo(a, m);
        Assert.AreEqual(expected, result);
    }

    private string Modulo(string a, string m)
    {
        BigInteger numA = BigInteger.Parse(a);
        BigInteger numM = BigInteger.Parse(m);
        BigInteger modulo = BigInteger.Remainder(numA, numM);

        return modulo.ToString();
    }
}
