using Arithmetic;
using System.Numerics;
using NUnit.Framework;

[TestFixture]
public class ModPowerStringsTests
{
    private Operations _op;

    public ModPowerStringsTests()
    {
        _op = new Operations();
    }

    [Test]
    public void TestPowerModulo()
    {
        string sa = "123";
        string sb = "456";
        string smod = "789";
        string expected = ModPowerStrings(sa, sb, smod);

        string result = _op.ModPowerStrings(sa, sb, smod);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void TestPowerModuloWithZeroExponent()
    {
        string sa = "123";
        string sb = "0";
        string smod = "789";
        string expected = ModPowerStrings(sa, sb, smod);

        string result = _op.ModPowerStrings(sa, sb, smod);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void TestPowerModuloWithLargeNumbers()
    {
        string sa = "524569954858548965486965";
        string sb = "125145641525624152241524";
        string smod = "1000007";
        string expected = ModPowerStrings(sa, sb, smod);

        string result = _op.ModPowerStrings(sa, sb, smod);
        Assert.AreEqual(expected, result);
    }

    private string ModPowerStrings(string sa, string sb, string smod)
    {
        BigInteger a = BigInteger.Parse(sa);
        BigInteger b = BigInteger.Parse(sb);
        BigInteger mod = BigInteger.Parse(smod);

        BigInteger result = BigInteger.ModPow(a, b, mod);

        return result.ToString();
    }
}
