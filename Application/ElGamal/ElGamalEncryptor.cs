using System.Numerics;
using Generator;

namespace ElGamal;

public class ElGamalEncryptor
{
    private BigInteger _p; // Велике просте число
    private BigInteger _g; // Примітивний корінь по модулю p
    private BigInteger _x; // Секретний ключ
    private BigInteger _y; // Відкритий ключ

    public ElGamalEncryptor(BigInteger p, BigInteger g, BigInteger x)
    {
        _p = p;
        _g = g;
        _x = x;

        _y = BigInteger.ModPow(g, x, p);
    }

    public BigInteger[] Encrypt(BigInteger message)
    {
        BigInteger k = RandomGenerator.GenerateRandomNumber(2, _p - 1);
        BigInteger c1 = BigInteger.ModPow(_g, k, _p);
        BigInteger c2 = (BigInteger.ModPow(_y, k, _p) * message) % _p;

        return new[] { c1, c2 };
    }

    public BigInteger GetPublicKey()
    {
        return _y;
    }
}